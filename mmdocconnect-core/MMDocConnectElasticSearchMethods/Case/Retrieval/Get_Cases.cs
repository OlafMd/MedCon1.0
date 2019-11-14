using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
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
    public class Get_Cases
    {
        private static string elasticType = "case";

        public static List<Case_Model> GetAllCases(Guid practice_id, ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            List<Case_Model> case_list = new List<Case_Model>();

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

                sort_parameter.search_params = string.IsNullOrEmpty(sort_parameter.search_params) ? "" : sort_parameter.search_params.ToLower();
                var hip_name = !String.IsNullOrEmpty(sort_parameter.hip_name) ? sort_parameter.hip_name.ToLower() : null;

                queryS = QueryBuilderCase.BuildGetCaseQueryFilter(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, practice_id.ToString(), sort_by_second_key, sort_by_third_key, sort_parameter.search_params, sort_parameter.filter_by, hip_name);

                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, queryS);
                var foundResults_Cases = serializer.ToSearchResult<Case_Model>(result);

                case_list = foundResults_Cases.Documents.ToList();
            }

            return case_list;
        }

        public static IEnumerable<T> GetCasesWhereIDPresent<T>(string id, string ordinal, string tenant_id, string elastic_type)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elastic_type, connection))
            {
                query = QueryBuilderCase.BuildGetCasesWhereIDPresentQuery<T>(id, ordinal);

                string searchCommand_Cases = Commands.Search(tenant_id, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<T>(result).Documents;
            }

            return new List<T>();
        }

        public static IEnumerable<T> GetCasesForRollback<T>(List<Query_Object> parameters, string tenant_id, string elastic_type)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elastic_type, connection))
            {
                query = QueryBuilderCase.BuidlGetCasesForRollBack<T>(parameters);

                string searchCommand_Cases = Commands.Search(tenant_id, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<T>(result).Documents;
            }

            return new List<T>();
        }

        public static IEnumerable<Submitted_Case_Model> GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(string id, string ordinal, string tenant_id, string case_type = null)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;
            var elastic_type = "submitted_case";

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elastic_type, connection))
            {
                query = QueryBuilderCase.BuildGetSubmittedCasesInErrorCorrectionAndWhereIDPresentQuery(id, ordinal, case_type);

                string searchCommand_Cases = Commands.Search(tenant_id, elastic_type).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<Submitted_Case_Model>(result).Documents;
            }

            return new List<Submitted_Case_Model>();
        }


        public static Case_Model GetCaseforCaseID(string case_id, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            string searchCommand = Commands.Index(index: securityTicket.TenantID.ToString(), type: elasticType, id: case_id);
            try
            {
                return serializer.ToGetResult<Case_Model>(connection.Get(searchCommand).Result).Document;
            }
            catch
            {
                return null;
            }
        }
        public static long GetCasesCount(ElasticParameterObject parameter, string practice_id, string authorizing_doctor_id, string treatment_doctor_id, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var query = QueryBuilderCase.BuildGetCaseQueryFilter(0, 0, null, false, practice_id, null, null, parameter.search_params, parameter.filter_by, !String.IsNullOrEmpty(parameter.hip_name) ? parameter.hip_name.ToLower() : null, true);

            var command = Commands.Count(securityTicket.TenantID.ToString(), elasticType);
            var result = serializer.ToCountResult(connection.Post(command, query).Result);

            return result.count;
        }

        public static Case_Model[] GetCasesforIDArray(Guid practice_id, string[] case_ids, bool is_submit, string authorizing_doctor_id, string treatment_doctor_id, string sort_by, bool isAsc, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var query = QueryBuilderCase.BuildGetCasesinIDArrayQuery(practice_id.ToString(), case_ids, int.MaxValue, is_submit, authorizing_doctor_id, sort_by, isAsc);
                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);
                return serializer.ToSearchResult<Case_Model>(result).Documents.ToArray();
            }

            return new Case_Model[] { };
        }

        public static Case_Model[] GetCasesFilteredIDs(ElasticParameterObject parameter, string practice_id, string[] deselected_ids, bool is_submit, string authorizing_doctor_id, string treatment_doctor_id, string sort_by, bool isAsc, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();

            var searchCommand = Commands.Search(securityTicket.TenantID.ToString(), elasticType).Pretty();
            var query = QueryBuilderCase.BuildGetCaseQueryFilter(0, int.MaxValue, null, false, practice_id, null, null, parameter.search_params, parameter.filter_by, !String.IsNullOrEmpty(parameter.hip_name) ? parameter.hip_name.ToLower() : null, true, authorizing_doctor_id);

            var operation_result = connection.Post(searchCommand, query);

            var allcases = serializer.ToSearchResult<Case_Model>(operation_result).Documents.ToArray();
            return allcases.Where(x => !deselected_ids.Any(id => id == x.id)).ToArray();
        }

        public static Dictionary<string, bool> GetSettlementDownloadStatuses(IEnumerable<Guid> patient_ids, SessionSecurityTicket securityTicket)
        {
            var elasticConnection = Elastic_Utils.ElsaticConnection();
            var existingSettlementDownloadStatuses = new Dictionary<string, bool>();

            if (Elastic_Utils.IfIndexOrTypeExists(String.Format("{0}/{1}", securityTicket.TenantID.ToString(), "settlement"), elasticConnection))
            {
                var serializer = new JsonNetSerializer();
                var command = Commands.Search(securityTicket.TenantID.ToString(), "settlement").Pretty();
                var query = new QueryBuilder<Settlement_Model>().Size(int.MaxValue).Query(q => q.Bool(b => b.Must(m => m.Terms(t => t.Field(f => f.patient_id).Values(patient_ids.Select(x => x.ToString())))))).BuildBeautified();
                var result = elasticConnection.Post(command, query);
                existingSettlementDownloadStatuses = serializer.ToSearchResult<Settlement_Model>(result).Documents.Where(t => t.id != null).GroupBy(t => t.id, t => t.is_report_downloaded).ToDictionary(t => t.Key, t => t.Single());
            }

            return existingSettlementDownloadStatuses;
        }
    }
}
