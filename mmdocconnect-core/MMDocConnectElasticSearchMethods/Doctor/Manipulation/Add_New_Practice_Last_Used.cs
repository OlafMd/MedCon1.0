using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Doctor.Manipulation
{
    public static class Add_New_Practice_Last_Used
    {
        public static string BuildPracticeLastUsedMapping(string doctor_account_id, string elastic_type)
        {
            return new MapBuilder<Practice_Doctor_Last_Used_Model>()
               .RootObject(elastic_type + doctor_account_id, ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("practice_id", mfp => mfp.Fields(f => f
                                        .String("practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("display_name", mfp => mfp.Fields(f => f
                                        .String("display_name", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                      .MultiField("date_of_use", mfp => mfp.Fields(f => f
                                        .Date("date_of_use")
                                      )))

                     ).BuildBeautified();
        }

        public static void Import_Practice_Last_Used_Data_to_ElasticDB(List<Practice_Doctor_Last_Used_Model> model_list, string index_name, string doctor_account_id, string elastic_type = null)
        {
            if (String.IsNullOrEmpty(elastic_type))
            {
                elastic_type = "user_";
            }

            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            bool index_exists = Elastic_Utils.IfIndexOrTypeExists(index_name, connection);

            if (!index_exists)
            {
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(index_name, settings);
            }

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(String.Format("{0}/{1}{2}", index_name, elastic_type, doctor_account_id), connection);

            if (!type_exists)
            {
                string jsonProductMapping = BuildPracticeLastUsedMapping(doctor_account_id, elastic_type);
                string resultProductMapping = connection.Put(new PutMappingCommand(index_name, elastic_type + doctor_account_id), jsonProductMapping);
            }

            Elastic_Utils.BulkType<Practice_Doctor_Last_Used_Model>(model_list, connection, serializer, index_name, elastic_type + doctor_account_id);

        }

        public static void Delete_Practice_Last_Used(string index_name, string type, string id)
        {
            var command = Commands.Delete(index_name, type, id);
            var connection = Elastic_Utils.ElsaticConnection();

            connection.Delete(command);
        }

    }
}
