
using DataImporter.Elastic_test.Model;
using DataImporter.Models;
using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMDocConnectElasticSearchMethods
{
    public static class Elastic_Utils
    {
        public static ElasticConnection ElsaticConnection()
        {

            string ElasticLink = ConfigurationManager.AppSettings["ElasticLink"]; //local
            string ElasticPort = ConfigurationManager.AppSettings["ElasticPort"];

            var connection = new ElasticConnection(ElasticLink, Int32.Parse(ElasticPort));

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


        public static void BulkType(List<Bic_Iban_Codes> ModelData, ElasticConnection connection, PlainElastic.Net.Serialization.JsonNetSerializer serializer, string _index)
        {
            string bulkCommand = new BulkCommand(index: _index, type: "iban_bic").Refresh();

            string bulkJson = new BulkBuilder(serializer)
                                .BuildCollection(ModelData, (builder, pro) => builder.Index(data: pro, id: pro.CodeID.ToString())
                                );

            string result = connection.Post(bulkCommand, bulkJson);
            BulkResult bulkResult = serializer.ToBulkResult(result);
            connection.Post(_index + "/_refresh");
        }



        public static void BulkType_Generic<T>(List<T> Model, ElasticConnection connection, PlainElastic.Net.Serialization.JsonNetSerializer serializer, string _index, string _type) where T : IElasticMapper
        {
            string bulkCommand = new BulkCommand(index: _index, type: _type).Refresh();

            string bulkJson = new BulkBuilder(serializer)
                           .BuildCollection(Model, (builder, pro) => builder.Index(data: pro, id: pro.id)
                           );

            string result = connection.Post(bulkCommand, bulkJson);
            BulkResult bulkResult = serializer.ToBulkResult(result);
            connection.Post(_index + "/_refresh");
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
        private static void PrintBulkCommand(string bulkCommand, string bulkJson, BulkResult bulkResult, string ObjectName)
        {
            Console.WriteLine("Parsed Bulk Results for " + ObjectName + " \r\n *************************************************************************************");
            foreach (var item in bulkResult.items)
            {
                Console.WriteLine(" operation: " + item.ResultType);
                Console.WriteLine(" _index: " + item.Result._index);
                Console.WriteLine(" _type: " + item.Result._type);
                Console.WriteLine(" _id: " + item.Result._id);
                Console.WriteLine();
            }
        }

        public static void Delete_Type(string index_name, string type)
        {
            var command = Commands.Delete(index_name, type);
            var connection = Elastic_Utils.ElsaticConnection();

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + type, connection);

            if (type_exists)
            {
                connection.Delete(command);
            }
        }
        
        public static void Delete_Entry(string index_name, string type, string id)
        {
            var command = Commands.Delete(index_name, type, id);
            var connection = Elastic_Utils.ElsaticConnection();

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + type, connection);

            if (type_exists)
            {
                connection.Delete(command);
            }
        }

        public static string GetAllTypes(string index)
        {
            var c = Commands.GetMapping(index, "_all");
            var connection = Elastic_Utils.ElsaticConnection();

            return connection.Get(c).Result;
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
