﻿using DataImporter.Models;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Settlement.Manipulation
{
    public static class Add_New_HIP
    {
        public static string BuildHIPMapping()
        {
            return new MapBuilder<HIP_Model>()
               .RootObject("hip", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                      .String("id", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                   ))
                                   .MultiField("name", mfp => mfp.Fields(f => f
                                      .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                      .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                   )))
                     ).BuildBeautified();
        }


        public static void Import_HIP_Data_to_ElasticDB(List<HIP_Model> hipList, string indexName)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            bool index_exists = Elastic_Utils.IfIndexOrTypeExists(indexName, connection);
            if (!index_exists)
            {
                //create new index
                string settings = Elastic_Utils.BuildExternalDataIndexSettings();
                connection.Put(indexName, settings);
            }

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/hip", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildHIPMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "hip"), json_case_mapping);
            }

            Elastic_Utils.BulkType<HIP_Model>(hipList, connection, serializer, indexName, "hip");
        }

        public static void Delete_Case_After_Submitting(string index_name, string type, string id)
        {
            var command = Commands.Delete(index_name, type, id);
            var connection = Elastic_Utils.ElsaticConnection();

            connection.Delete(command);
            connection.Post(index_name + "/_refresh");
        }
    }
}