using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Case.Retrieval
{
    public class Get_Submitted_Cases
    {
        public static List<Submitted_Case_Model> GetAllCases(ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "submitted_case";

            List<Submitted_Case_Model> case_list = new List<Submitted_Case_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var sort_by_second_key = "";
                var sort_by_third_key = "";
                var sort_by_fourth_key = "";
                var sort_by_fifth_key = "";

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
                    case "management_status":
                        sort_by_second_key = "practice_name";
                        sort_by_third_key = "doctor_name";
                        sort_by_fourth_key = "treatment_date";
                        sort_by_fifth_key = "patient_name";
                        break;
                    default:
                        sort_by_second_key = "treatment_date";
                        sort_by_third_key = "patient_name";
                        break;
                }
                if (string.IsNullOrEmpty(sort_parameter.search_params) && sort_parameter.filter_by.filter_status.Length == 0 && sort_parameter.filter_by.filter_type.Length == 0 && string.IsNullOrEmpty(sort_parameter.date_from) && string.IsNullOrEmpty(sort_parameter.date_to))
                {
                    queryS = QueryBuilderCase.BuildGetSubmittedCaseQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_by_second_key, sort_by_third_key, sort_by_fourth_key, sort_by_fifth_key);
                }
                else
                {
                    sort_parameter.search_params = string.IsNullOrEmpty(sort_parameter.search_params) ? "" : sort_parameter.search_params.ToLower();
                    queryS = QueryBuilderCase.BuildGetSubmittedCasesSearchAsYouTypeQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_parameter.search_params, sort_parameter.filter_by, sort_by_second_key, sort_by_third_key, sort_by_fourth_key, sort_by_fifth_key, sort_parameter.date_from, sort_parameter.date_to);
                }

                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, queryS);
                Dictionary<string, int> PracticeDoctorsCount = new Dictionary<string, int>();
                var foundResults_Cases = serializer.ToSearchResult<Submitted_Case_Model>(result);

                foreach (var item in foundResults_Cases.Documents)
                {
                    switch (sort_parameter.sort_by)
                    {
                        case "treatment_date": item.group_name = item.treatment_date_month_year.ToUpper(); break;
                        case "patient_name": item.group_name = item.patient_name.Substring(0, 1).ToUpper(); break;
                        case "hip_name": item.group_name = item.hip_name; break;
                        case "type": item.group_name = item.type.Equals("op") ? "LABEL_TREATMENT" : "LABEL_AFTERCARE"; break;
                        case "diagnose": item.group_name = item.diagnose; break;
                        case "localization": item.group_name = item.localization; break;
                        case "doctor_name": item.group_name = item.doctor_name; break;
                        case "management_pauschale": item.group_name = string.IsNullOrEmpty(item.management_pauschale) ? "-" : item.management_pauschale.Equals("waived") ? "LABEL_MANAGEMENT_FEE_WAIVED" : "LABEL_MANAGEMENT_FEE_DEDUCTED"; break;
                        case "status": item.group_name = item.status; break;
                        default: item.group_name = item.treatment_date_month_year; break;
                    }

                    item.treatment_date_day_month = item.treatment_date.ToString("dd.MM.yyyy");
                    item.management_pauschale = string.IsNullOrEmpty(item.management_pauschale) ? "-" : item.management_pauschale.Equals("waived") ? "LABEL_MANAGEMENT_FEE_WAIVED" : "LABEL_MANAGEMENT_FEE_DEDUCTED";
                }

                case_list = foundResults_Cases.Documents.ToList();
            }
            return case_list;
        }

        public static long GetSubmittedCasesCount(ElasticParameterObject parameter, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var result = serializer.ToCountResult(connection.Post(Commands.Count(securityTicket.TenantID.ToString(), "submitted_case"), QueryBuilderCase.BuildGetSubmittedCasesCountQuery(parameter.search_params, parameter.filter_by, parameter.date_from, parameter.date_to, null, "")).Result);

            return result.count;
        }

        public static Submitted_Case_Model[] GetSubmittedCasesFilteredIDs(ElasticParameterObject parameter, string status, SessionSecurityTicket securityTicket)
        {
            var size = GetSubmittedCasesCount(parameter, securityTicket);
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();

            string searchCommand = Commands.Search(securityTicket.TenantID.ToString(), "submitted_case").Pretty();
            var operation_result = connection.Post(searchCommand, QueryBuilderCase.BuildGetSubmittedCasesCountQuery(parameter.search_params, parameter.filter_by, parameter.date_from, parameter.date_to, (int)size, status));

            return serializer.ToSearchResult<Submitted_Case_Model>(operation_result).Documents.ToArray();
        }

        public static Submitted_Case_Model GetSubmittedCaseforSubmittedCaseID(string id, SessionSecurityTicket securityTicket)
        {
            try
            {
                var connection = Elastic_Utils.ElsaticConnection();
                var serializer = new JsonNetSerializer();
                string searchCommand = Commands.Index(index: securityTicket.TenantID.ToString(), type: "submitted_case", id: id);

                return serializer.ToGetResult<Submitted_Case_Model>(connection.Get(searchCommand).Result).Document;
            }
            catch
            {
                return null;
            }
        }

        public static Submitted_Case_Model[] GetSubmittedCaseforIDArray(string[] case_ids, string status, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "submitted_case";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                queryS = QueryBuilderCase.BuildGetSubmittedCasesinIDArrayQuery(case_ids, int.MaxValue, status);
                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, queryS);
                return serializer.ToSearchResult<Submitted_Case_Model>(result).Documents.ToArray();
            }

            return new Submitted_Case_Model[] { };
        }
    }
}
