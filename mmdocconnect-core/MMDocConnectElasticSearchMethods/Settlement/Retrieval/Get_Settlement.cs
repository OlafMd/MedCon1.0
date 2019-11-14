using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Settlement.Retrieval
{
    public class Get_Settlement
    {
        private static string elasticType = "settlement";
        public static IEnumerable<Settlement_Model> Get_Settlement_items(ElasticParameterObject sort_parameter, string practice_id, SessionSecurityTicket securityTicket, List<AftercareHipParameter> rangeParameters = null)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var sort_by_second_key = "";
                var sort_by_third_key = "";
                var sort_by_fourth_key = "first_name.lower_case_sort";
                var sort_first = "";
                switch (sort_parameter.sort_by)
                {
                    case "surgery_date":
                        sort_by_second_key = "last_name.lower_case_sort";
                        sort_by_third_key = "first_name.lower_case_sort";
                        break;
                    case "patient_name":
                        sort_first = "last_name.lower_case_sort";
                        sort_by_second_key = "first_name.lower_case_sort";
                        sort_by_third_key = "birthday";
                        sort_by_fourth_key = "surgery_date";
                        break;
                    default:
                        sort_by_second_key = "surgery_date";
                        sort_by_third_key = "last_name.lower_case_sort";
                        break;
                }

                if (sort_parameter.sort_by == "status")
                    sort_parameter.sort_by = "status.lower_case_sort";

                var queryS = QueryBuilderSettlement.BuildGetSettlementQuery(
                    start_row_index: sort_parameter.start_row_index,
                    page_size: sort_parameter.page_size,
                    sort_by: !String.IsNullOrEmpty(sort_first) ? sort_first : sort_parameter.sort_by,
                    search_params: sort_parameter.search_params,
                    isAsc: sort_parameter.isAsc,
                    practice_id: practice_id,
                    sort_by_second_key: sort_by_second_key,
                    sort_by_third_key: sort_by_third_key,
                    sort_by_fourth_key: sort_by_fourth_key,
                    filter_by: sort_parameter.filter_by,
                    deselected_ids: sort_parameter.deselected_ids != null && sort_parameter.deselected_ids.Any() ? Array.ConvertAll(sort_parameter.deselected_ids.ToArray(), t => t.ToString()) : null,
                    rangeParameters: rangeParameters,
                    hip_name: sort_parameter.hip_name);

                string searchCommand_Settlement = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Settlement, queryS);
                var foundResults_Settlement = serializer.ToSearchResult<Settlement_Model>(result);

                return foundResults_Settlement.Documents.Select(item =>
                {
                    switch (sort_parameter.sort_by)
                    {
                        case "surgery_date": item.group_name = item.surgery_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)).ToUpper(); break;
                        case "patient_name": item.group_name = item.last_name.Substring(0, 1).ToUpper(); break;
                        case "case_type": item.group_name = item.case_type; break;
                        case "diagnose": item.group_name = item.diagnose; break;
                        case "localization": item.group_name = item.localization; break;
                        case "doctor": item.group_name = item.doctor; break;
                        case "status.lower_case_sort": item.group_name = item.status; break;
                        default: item.group_name = item.surgery_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)).ToUpper(); break;
                    }

                    item.is_submit_button_visible = item.status == "FS6";
                    item.is_cancel_button_visible = item.status != "FS8";

                    item.surgery_date_string = item.surgery_date.ToString("dd.MM.yyyy");

                    return item;
                });
            }

            return new List<Settlement_Model>();
        }

        public static Settlement_Model GetSettlementForID(string settlement_id, SessionSecurityTicket securityTicket)
        {
            try
            {
                var connection = Elastic_Utils.ElsaticConnection();
                var serializer = new JsonNetSerializer();
                string searchCommand = Commands.Index(index: securityTicket.TenantID.ToString(), type: elasticType, id: settlement_id);

                return serializer.ToGetResult<Settlement_Model>(connection.Get(searchCommand).Result).Document;
            }
            catch
            {
                return null;
            }
        }

        public static Settlement_Model GetSettelementWhereStatus(string patient_id, string localization, string status_code, string case_type, string index_name)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var query = QueryBuilderSettlement.BuildGetSettlementWhereStatus(patient_id.ToLower(), localization.ToLower(), status_code.ToLower(), case_type);

            if (Elastic_Utils.IfIndexOrTypeExists(index_name, connection) && Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + elasticType, connection))
            {
                string searchCommand = Commands.Search(index_name, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                return serializer.ToSearchResult<Settlement_Model>(result).Documents.SingleOrDefault();
            }

            return null;
        }

        public static IEnumerable<Settlement_Model> GetCasesWhereIDPresent(string id, string ordinal, string tenant_id, string case_type = null)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elasticType, connection))
            {
                query = QueryBuilderSettlement.BuildGetSettlementInErrorCorrectionAndWhereIDPresentQuery(id, ordinal, case_type);

                string searchCommand_Cases = Commands.Search(tenant_id, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<Settlement_Model>(result).Documents;
            }

            return new List<Settlement_Model>();
        }

        public static long GetNumberOfFSCasesInDoctorsPractice(string practice_id, string status, SessionSecurityTicket securityTicket)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString(), connection) && Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/" + elasticType, connection))
            {
                string result = connection.Post(Commands.Count(securityTicket.TenantID.ToString(), elasticType), QueryBuilderSettlement.BuildGetNumberOfFSCasesInDoctorsPractice(practice_id, status));
                return serializer.ToCountResult(result).count;
            }

            return 0;

        }


        public static IEnumerable<Settlement_Model> GetSettlementsforIDArray(Guid practice_id, string[] case_ids, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                queryS = QueryBuilderSettlement.BuildGetSettlementsForIDArray(practice_id, case_ids);
                string result = connection.Post(Commands.Search(TenantID, elasticType).Pretty(), queryS);
                return serializer.ToSearchResult<Settlement_Model>(result).Documents;
            }

            return new List<Settlement_Model>();
        }
        public static IEnumerable<Settlement_Model> GetAllSettlementsEligibleForSubmissionReport(Guid practice_id, SessionSecurityTicket securityTicket, string[] case_ids = null)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                queryS = QueryBuilderSettlement.BuildGetSettlementEligibleForSubmissionReport(practice_id, case_ids);
                string result = connection.Post(Commands.Search(TenantID, elasticType).Pretty(), queryS);
                return serializer.ToSearchResult<Settlement_Model>(result).Documents;
            }

            return new List<Settlement_Model>();

        }

        public static IEnumerable<Settlement_Model> GetAllSettlementsWithNonDownloadedSubmissionReport(Guid practiceId, string index, string doctorId = null)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(index, connection) && Elastic_Utils.IfIndexOrTypeExists(index + "/" + elasticType, connection))
            {
                var query = QueryBuilderSettlement.BuildGetAllSettlementsWithNonDownloadedSubmissionReport(practiceId, doctorId);
                var result = connection.Post(Commands.Search(index, elasticType).Pretty(), query);
                return serializer.ToSearchResult<Settlement_Model>(result).Documents;
            }

            return Enumerable.Empty<Settlement_Model>();
        }
    }
}
