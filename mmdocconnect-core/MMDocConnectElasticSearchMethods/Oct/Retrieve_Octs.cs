using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Oct.Entity;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Case.Retrieval
{
    public class Retrieve_Octs
    {
        private static string elasticType = "oct";

        public static long GetOctCount(ElasticParameterObject parameter, Guid practice_id, string index, List<OctHipParameter> rangeParameters)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();

            var command = Commands.Search(index, elasticType).SearchType(SearchType.count);

            parameter.omit_withdrawn = true;
            if (parameter.filter_by.filter_status.Length == 1 && parameter.filter_by.filter_status.First() == "oct4")
            {
                return 0;
            }

            var query = QueryBuilderOct.BuildGetOctsQuery(0, Int32.MaxValue, null, parameter.hip_name, parameter.search_params, false, practice_id.ToString(),
                null, null, parameter.filter_by, rangeParameters, omit_withdrawn: parameter.omit_withdrawn);

            var result = connection.Post(command, query);
            var count = serializer.ToSearchResult<Oct_Model>(result).hits.total;
            return count;
        }

        public static List<Oct_Model> GetAllOcts(Guid practice_id, ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket, List<OctHipParameter> rangeParameters)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            List<Oct_Model> case_list = new List<Oct_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var sort_by_second_key = "";
                var sort_by_third_key = "";

                switch (sort_parameter.sort_by)
                {
                    case "treatment_date":
                        sort_by_second_key = "patient_name";
                        sort_by_third_key = "patient_birthdate";
                        break;
                    case "patient_name":
                        sort_by_second_key = "patient_birthdate";
                        sort_by_third_key = "treatment_date";
                        break;
                    default:
                        sort_by_second_key = "treatment_date";
                        sort_by_third_key = "patient_name";
                        break;
                }

                var hip_name = !String.IsNullOrEmpty(sort_parameter.hip_name) ? sort_parameter.hip_name.ToLower() : null;

                sort_parameter.search_params = string.IsNullOrEmpty(sort_parameter.search_params) ? "" : sort_parameter.search_params.ToLower();

                var query = QueryBuilderOct.BuildGetOctsQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, hip_name,
                    sort_parameter.search_params, sort_parameter.isAsc, practice_id.ToString(), sort_by_second_key, sort_by_third_key, sort_parameter.filter_by, rangeParameters,
                    deselected_ids: sort_parameter.deselected_ids != null ? sort_parameter.deselected_ids.Select(t => t.ToString()) : null);

                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);
                var foundResults_Cases = serializer.ToSearchResult<Oct_Model>(result);

                case_list = foundResults_Cases.Documents.ToList();
            }

            return case_list;
        }

        public static Oct_Model GetOctForID(string id, string index)
        {
            var oct = Elastic_Utils.GetItemForID<Oct_Model>(index, elasticType, id);
            return oct;
        }

        public static IEnumerable<Oct_Model> GetOctsWhereFieldsHaveValues(IEnumerable<FieldValueParameter> parameters, string practice_id, string index, FieldValueParameter rangeParameter = null)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();

            var searchCommand = Commands.Search(index, elasticType).Pretty();
            var query = QueryBuilderOct.BuildGetOctsWhereFieldsHaveValuesQuery(parameters.ToList(), practice_id, rangeParameter);
            var result = connection.Post(searchCommand, query);

            return serializer.ToSearchResult<Oct_Model>(result).Documents;
        }
    }
}
