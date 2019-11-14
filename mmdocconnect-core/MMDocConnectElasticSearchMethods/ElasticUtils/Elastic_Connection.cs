using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace MMDocConnectElasticSearchMethods
{
    public static class Elastic_Utils
    {
        public static ElasticConnection ElsaticConnection()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["ElasticConnection"];
            var port = System.Configuration.ConfigurationManager.AppSettings["ElasticPort"];

            var connection = new ElasticConnection(url, Int32.Parse(port));
            connection.Credentials = new NetworkCredential("esuser", "krejbejzajbla");

            return connection;
        }

        public static bool IfIndexOrTypeExists(string indexName, ElasticConnection connection)
        {
            try
            {
                connection.Head(new IndexExistsCommand(indexName));
                return true;
            }
            catch (OperationException ex)
            {
                if (ex.HttpStatusCode == 404)
                    return false;
                throw;
            }
        }

        public static string BuildIndexSettings()
        {
            return new IndexSettingsBuilder()
                      .Analysis(anl => anl
                          .Filter(filt => filt.WordDelimiter("word_filter", wd => wd.GenerateWordParts(true)).EdgeNGram("autocomplete_filter", gr => gr.MinGram(1)
                            .MaxGram(20)))
                          .Analyzer(a => a
                              .Custom("caseinsensitive", custom => custom
                                  .Tokenizer(DefaultTokenizers.keyword)
                                  .Filter("lowercase")
                              )
                              .Custom("autocomplete", custom => custom
                                  .Tokenizer(DefaultTokenizers.standard)
                                  .Filter("lowercase", "word_filter", "autocomplete_filter")
                              ).Keyword("not_analyzed", k => k.Name("not_analyzed"))
                              )
                          )
                          .BuildBeautified();
        }

        public static string BuildExternalDataIndexSettings()
        {
            return new IndexSettingsBuilder()
                        .Analysis(anl => anl
                            .Filter(filt => filt.EdgeNGram("autocomplete_filter", gr => gr.MinGram(1)
                              .MaxGram(20)))
                            .Analyzer(a => a
                                .Custom("caseinsensitive", custom => custom
                                    .Tokenizer(DefaultTokenizers.keyword)
                                    .Filter("lowercase")
                                )
                                .Custom("autocomplete", custom => custom
                                    .Tokenizer(DefaultTokenizers.standard)
                                    .Filter("lowercase", "autocomplete_filter")
                                )
                                .Keyword("not_analyzed", k => k.Name("not_analyzed"))
                                )
                            )
                            .BuildBeautified();
        }

        public static void BulkType<T>(List<T> Model, ElasticConnection connection, PlainElastic.Net.Serialization.JsonNetSerializer serializer, string _index, string _type) where T : IElasticMapper
        {
            string bulkCommand = "";
            bulkCommand = new BulkCommand(index: _index, type: _type).Refresh();
            string bulkJson = new BulkBuilder(serializer)
                           .BuildCollection(Model, (builder, pro) => builder.Index(data: pro, id: pro.id)
                           );
            string result = connection.Post(bulkCommand, bulkJson);
            BulkResult bulkResult = serializer.ToBulkResult(result);
            connection.Post(_index + "/_refresh");
        }

        public static string GetAllTypes(string index)
        {

            var c = Commands.GetMapping(index, "_all");
            var connection = Elastic_Utils.ElsaticConnection();

            return connection.Get(c).Result;
        }

        public static void Delete_Item(string index_name, string type, object id)
        {
            try
            {
                var command = Commands.Delete(index_name, type, id.ToString());
                var connection = Elastic_Utils.ElsaticConnection();

                connection.Delete(command);
                connection.Post(index_name + "/_refresh");
            }
            catch { }
        }

        public static T GetItemForID<T>(string index, string type, string id) where T : IElasticMapper
        {
            try
            {
                var connection = ElsaticConnection();
                var serializer = new JsonNetSerializer();
                string searchCommand = Commands.Index(index: index, type: type, id: id);

                return serializer.ToGetResult<T>(connection.Get(searchCommand).Result).Document;
            }
            catch
            {
                return default(T);
            }
        }

        public static string BuildElasticMapping<T>(string elasticType, IEnumerable<ElasticMappingConfigObject> analyzerConfiguration = null)
        {
            return new MapBuilder<T>()
               .RootObject(elasticType, ro => ro
                   .Properties(pr =>
                   {
                       typeof(T).GetProperties().ToList().ForEach(ord =>
                       {
                           if (ord.PropertyType == typeof(Guid))
                           {
                               pr.MultiField(ord.Name, mfp => mfp.Fields(f => f
                                   .String(ord.Name, sp => sp.Analyzer("caseinsensitive"))));
                           }
                           else if (ord.PropertyType == typeof(String))
                           {
                               var indexAnalyzer = "autocomplete";
                               var searchAnalyzer = DefaultAnalyzers.standard;

                               if (analyzerConfiguration != null && analyzerConfiguration.Any())
                               {
                                   var fieldCfg = analyzerConfiguration.SingleOrDefault(t => t.fieldName == ord.Name);
                                   if (fieldCfg != null)
                                   {
                                       indexAnalyzer = fieldCfg.analyzerName;
                                       if (!String.IsNullOrEmpty(fieldCfg.searchAnalyzer))
                                       {
                                           searchAnalyzer = (DefaultAnalyzers)Enum.Parse(typeof(DefaultAnalyzers), fieldCfg.searchAnalyzer);
                                       }
                                   }
                               }

                               pr.MultiField(ord.Name, mfp => mfp.Fields(f => f
                                   .String(ord.Name, sp => sp.IndexAnalyzer(indexAnalyzer).SearchAnalyzer(searchAnalyzer))
                                   .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))));
                           }
                           else if (ord.PropertyType == typeof(DateTime))
                           {
                               pr.MultiField(ord.Name, mfp => mfp.Fields(f => f.Date(ord.Name)));
                           }
                           else if (ord.PropertyType == typeof(Boolean))
                           {
                               pr.MultiField(ord.Name, mfp => mfp.Fields(f => f.Boolean(ord.Name)));
                           }
                           else if (NumericTypes.Contains(ord.PropertyType))
                           {
                               pr.MultiField(ord.Name, mfp => mfp.Fields(f => f.Number(ord.Name)));
                           }
                       });

                       return pr;
                   })).BuildBeautified();

        }

        public static IEnumerable<T> GetDataForPatientID<T>(string index, string type, string patient_id)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var command = Commands.Search(index, type);
            var query = BuildGetDataForPatientIdQuery<T>(patient_id);
            var result = connection.Post(command, query);

            var data = serializer.ToSearchResult<T>(result).Documents;
            return data;
        }

        public static string BuildGetDataForPatientIdQuery<T>(string patient_id, bool delete = false, IEnumerable<string> types = null)
        {
            var query = new QueryBuilder<T>()
                .Query(q => q.Bool(b => b.Must(m => m
                    .Term(t => t.Field("patient_id").Value(patient_id))
                    .Terms(t => t.Field(GetEntityTypeProperty<T>()).Values(types))
                )));

            if (!delete)
            {
                query = query.Size(int.MaxValue);
            }

            return query.BuildBeautified();
        }

        private static string GetEntityTypeProperty<T>()
        {
            var typeName = typeof(T).Name;
            switch (typeName)
            {
                case "PatientDetailViewModel":
                    return "detail_type";

                case "Settlement_Model":
                    return "case_type";

                case "Submitted_Case_Model":
                    return "type";

                default:
                    return "type";
            }
        }

        private static string BuildGetDataForFieldQuery<T>(string field, string value)
        {
            var query = new QueryBuilder<T>()
                .Query(q => q.Bool(b => b.Must(m => m
                    .Term(t => t.Field(field).Value(value))
                )));

            return query.BuildBeautified();
        }

        public static void DeleteDataForField<T>(string index, string type, string field, string value) where T : IElasticMapper
        {
            var searchCommand = Commands.Search(index, type);
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var query = BuildGetDataForFieldQuery<T>(field, value);

            var result = connection.Post(searchCommand, query);

            var data = serializer.ToSearchResult<T>(result).Documents;
            if (data.Any())
            {
                ExplicitDelete(index, type, data.Select(t => t.id));
            }

            connection.Post(index + "/_refresh");
        }

        public static void DeleteDataForPatientID<T>(string index, string type, string patient_id, IEnumerable<string> types = null) where T : IElasticMapper
        {
            var searchCommand = Commands.Search(index, type);
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var query = BuildGetDataForPatientIdQuery<T>(patient_id, false, types);

            var result = connection.Post(searchCommand, query);

            var data = serializer.ToSearchResult<T>(result).Documents;
            if (data.Any())
            {
                ExplicitDelete(index, type, data.Select(t => t.id));
            }

            connection.Post(index + "/_refresh");
        }

        public static void ExplicitDelete(string index, string type, IEnumerable<string> ids)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            foreach (var id in ids)
            {
                try
                {
                    var command = Commands.Delete(index, type, id);
                    connection.Delete(command);
                }
                catch { }
            }

            connection.Post(index + "/_refresh");
        }

        private static HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(decimal), 
            typeof(double), 
            typeof(float),
            typeof(short), 
            typeof(ushort), 
            typeof(int), 
            typeof(uint),
            typeof(long)
        };
    }


    public class ElasticMappingConfigObject
    {
        public string fieldName { get; set; }

        public string analyzerName { get; set; }

        public string searchAnalyzer { get; set; }
    }
}
