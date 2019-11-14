using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Case.Entity;
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
    public class Get_Aftercares
    {
        public static IEnumerable<Aftercare_Model> GetAllAftercaresforPracticeID(String practice_id, bool is_practice, ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket, List<AftercareHipParameter> rangeParameters)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "aftercare";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                var sort_by_second_key = "treatment_date";
                var sort_by_third_key = "patient_name";

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
                }

                if (sort_parameter.page_size == 0)
                {
                    sort_parameter.page_size = 100;
                }

                var hip_name = !String.IsNullOrEmpty(sort_parameter.hip_name) ? sort_parameter.hip_name.ToLower() : null;

                var query = QueryBuilderCase.BuildGetAftercaresQuery(sort_parameter.start_row_index,
                    sort_parameter.page_size,
                    sort_parameter.sort_by,
                    sort_parameter.search_params,
                    sort_parameter.isAsc,
                    practice_id,
                    sort_by_second_key,
                    sort_by_third_key,
                    sort_parameter.filter_by,
                    rangeParameters,
                    hip_name);

                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                var foundResults_Aftercares = serializer.ToSearchResult<Aftercare_Model>(result);

                var aftercares = foundResults_Aftercares.Documents.Select(item =>
                {
                    switch (sort_parameter.sort_by)
                    {
                        case "treatment_date": item.group_name = item.treatment_date_month_year.ToUpper(); break;
                        case "patient_name": item.group_name = item.patient_name.Substring(0, 1).ToUpper(); break;
                        case "diagnose": item.group_name = item.diagnose; break;
                        case "localization": item.group_name = item.localization; break;
                        case "treatment_doctor_name": item.group_name = item.treatment_doctor_name; break;
                        case "aftercare_doctor_name": item.group_name = item.aftercare_doctor_name; break;
                        case "status": item.group_name = item.status; break;
                        default: item.group_name = item.treatment_date_month_year; break;
                    }

                    item.treatment_date_day_month = item.treatment_date.ToString("dd.MM.yyyy");

                    return item;
                });

                return aftercares;
            }

            return Enumerable.Empty<Aftercare_Model>();
        }

        public static List<Aftercare_Model> GetAftercaresForIDArray(Guid practice_id, bool is_practice, string[] case_ids, bool is_submit,
            string authorizing_doctor_id, string sort_by, bool isAsc, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            string elasticType = "aftercare";

            List<Aftercare_Model> case_list = new List<Aftercare_Model>();

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                queryS = QueryBuilderCase.BuildGetAftercaresinIDArrayQuery(practice_id.ToString(), case_ids, int.MaxValue, is_submit, authorizing_doctor_id, sort_by, isAsc);
                string searchCommand_Cases = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, queryS);
                Dictionary<string, int> PracticeDoctorsCount = new Dictionary<string, int>();
                case_list = serializer.ToSearchResult<Aftercare_Model>(result).Documents.ToList();
            }

            return case_list;
        }

        public static long GetAftercaresCount(ElasticParameterObject parameter, bool is_practice, string practice_id, string authorizing_doctor_id, List<AftercareHipParameter> rangeParameters, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var command = Commands.Count(securityTicket.TenantID.ToString(), "aftercare");
            var query = QueryBuilderCase.BuildGetAftercaresCountQuery(parameter.search_params, practice_id, parameter.filter_by, parameter.date_from, parameter.date_to, null, false,
                is_practice ? null : securityTicket.AccountID.ToString(), is_practice, null, authorizing_doctor_id, "", false, rangeParameters, !String.IsNullOrEmpty(parameter.hip_name) ? parameter.hip_name.ToLower() : null);

            var result = serializer.ToCountResult(connection.Post(command, query).Result);
            return result.count;
        }

        public static Aftercare_Model[] GetAftercaresFilteredIDs(ElasticParameterObject parameter, string practice_id, string[] deselected_ids, bool is_submit, bool is_practice, string authorizing_doctor_id, string sort_by, bool isAsc, List<AftercareHipParameter> rangeParameters, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            var searchCommand = Commands.Search(securityTicket.TenantID.ToString(), "aftercare").Pretty();
            var query = QueryBuilderCase.BuildGetAftercaresCountQuery(parameter.search_params, practice_id, parameter.filter_by, parameter.date_from,
                parameter.date_to, int.MaxValue, is_submit, securityTicket.AccountID.ToString(), is_practice, deselected_ids, authorizing_doctor_id, sort_by, isAsc, rangeParameters, !String.IsNullOrEmpty(parameter.hip_name) ? parameter.hip_name.ToLower() : null);

            var operation_result = connection.Post(searchCommand, query);
            return serializer.ToSearchResult<Aftercare_Model>(operation_result).Documents.ToArray();
        }

        public static Aftercare_Model GetAftercareForAftercareID(string aftercare_id, SessionSecurityTicket securityTicket)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();
            string searchCommand = Commands.Index(index: securityTicket.TenantID.ToString(), type: "aftercare", id: aftercare_id);

            return serializer.ToGetResult<Aftercare_Model>(connection.Get(searchCommand).Result).Document;
        }
    }
}
