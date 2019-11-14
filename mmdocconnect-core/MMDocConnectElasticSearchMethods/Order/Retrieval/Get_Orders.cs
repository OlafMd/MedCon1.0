using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Order.Retrieval
{
    public class Get_Orders
    {
        private static string elasticType = "order";

        public static List<Order_Model> Get_All_Orders(ElasticParameterObject sort_parameter, SessionSecurityTicket securityTicket)
        {
            var TenantID = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string queryS = string.Empty;
            var order_list = new List<Order_Model>();

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

                if (string.IsNullOrEmpty(sort_parameter.search_params) && sort_parameter.filter_by.filter_status == null && string.IsNullOrEmpty(sort_parameter.date_from) && string.IsNullOrEmpty(sort_parameter.date_to))
                {
                    queryS = QueryBuilderOrders.BuildGetOrderQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_by_second_key, sort_by_third_key);
                }
                else
                {
                    bool isOverdueParam = false;
                    sort_parameter.search_params = string.IsNullOrEmpty(sort_parameter.search_params) ? "" : sort_parameter.search_params.ToLower();
                    if (sort_parameter.filter_by.filter_status != null)
                    {
                        isOverdueParam = sort_parameter.filter_by.filter_status.Contains("overdue");
                        sort_parameter.filter_by.filter_status = sort_parameter.filter_by.filter_status.Where(i => i != "overdue").ToArray();

                    }

                    if (!isOverdueParam)
                        queryS = QueryBuilderOrders.BuildGetSearchOrderQuery(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_by_second_key, sort_by_third_key, sort_parameter.search_params, sort_parameter.date_from, sort_parameter.date_to, sort_parameter.filter_by);
                    else
                        queryS = QueryBuilderOrders.BuildGetSearchOrderQueryWithOverdue(sort_parameter.start_row_index, 100, sort_parameter.sort_by, sort_parameter.isAsc, sort_by_second_key, sort_by_third_key, sort_parameter.search_params, sort_parameter.date_from, sort_parameter.date_to, sort_parameter.filter_by);
                }

                string searchCommand_Orders = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand_Orders, queryS);
                Dictionary<string, int> PracticeOrdersCount = new Dictionary<string, int>();
                var foundResults_Orders = serializer.ToSearchResult<Order_Model>(result);
                try
                {
                    foreach (var item in foundResults_Orders.Documents)
                    {
                        Order_Model order_model = new Order_Model();
                        order_model.case_id = item.case_id;
                        order_model.delivery_time_from = item.delivery_time_from;
                        order_model.delivery_time_string = item.delivery_time_string;
                        order_model.delivery_time_to = item.delivery_time_to;
                        order_model.diagnose = item.diagnose;
                        order_model.drug = item.drug;
                        order_model.id = item.id;
                        order_model.is_orders_drug = item.is_orders_drug;
                        order_model.localization = item.localization;
                        order_model.order_modification_timestamp = item.order_modification_timestamp;
                        order_model.order_modification_timestamp_string = item.order_modification_timestamp_string;
                        order_model.patient_id = item.patient_id;
                        order_model.patient_birthdate = item.patient_birthdate;
                        order_model.patient_birthdate_string = item.patient_birthdate_string;
                        order_model.patient_name = item.patient_name;
                        order_model.practice_id = item.practice_id;
                        order_model.status_drug_order = item.status_drug_order;
                        order_model.treatment_date = item.treatment_date;
                        order_model.treatment_date_day_month = item.treatment_date.ToString("dd.MM.yyyy");
                        order_model.treatment_date_month_year = item.treatment_date_month_year;
                        order_model.treatment_doctor_name = item.treatment_doctor_name;
                        order_model.treatment_doctor_practice_name = item.treatment_doctor_practice_name;
                        order_model.delivery_date_month = item.treatment_date.ToString("dd.MM.");
                        order_model.pharmacy_id = item.pharmacy_id;
                        order_model.pharmacy_name = item.pharmacy_name;

                        switch (sort_parameter.sort_by)
                        {
                            case "treatment_date": order_model.group_name = order_model.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)).ToUpper(); break;
                            case "patient_name": order_model.group_name = item.patient_name.Substring(0, 1).ToUpper(); break;
                            case "diagnose": order_model.group_name = item.diagnose; break;
                            case "drug": order_model.group_name = item.drug; break;
                            case "localization": order_model.group_name = item.localization; break;
                            case "treatment_doctor_name": order_model.group_name = item.treatment_doctor_practice_name; break;
                            case "status_drug_order": order_model.group_name = item.status_drug_order; break;
                            default: order_model.group_name = item.treatment_date_month_year; break;
                        }

                        order_list.Add(order_model);
                    }


                }
                catch (Exception ex) { }
            }
            return order_list;
        }

        public static IEnumerable<Order_Model> GetPracticeOrders(int start_row_index, int page_size, string practice_id, string index_name, string search_params, string hip_name, DateTime orders_from_date, DateTime orders_to_date, IEnumerable<string> deslected_ids = null)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(index_name, connection) && Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + elasticType, connection))
            {
                query = QueryBuilderOrders.BuildGetPracticeOrdersQuery(start_row_index, page_size, practice_id, search_params, hip_name, orders_from_date, orders_to_date, deslected_ids);

                string search_command = Commands.Search(index_name, elasticType).Pretty();
                string result = connection.Post(search_command, query);

                return serializer.ToSearchResult<Order_Model>(result).Documents;
            }

            return Enumerable.Empty<Order_Model>();
        }


        public static IEnumerable<Order_Model> GetAllPracticeOrders(string practice_id, ElasticParameterObject sort_parameter, IEnumerable<string> order_ids_eligible_for_settlement, string index_name)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(index_name, connection) && Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + elasticType, connection))
            {
                query = QueryBuilderOrders.BuildGetAllPracticeOrdersQuery(sort_parameter, practice_id, order_ids_eligible_for_settlement);

                string search_command = Commands.Search(index_name, elasticType).Pretty();
                string result = connection.Post(search_command, query);
                return serializer.ToSearchResult<Order_Model>(result).Documents;
            }

            return Enumerable.Empty<Order_Model>();
        }



        public static Order_Model GetOrderforOrderID(string order_id, SessionSecurityTicket securityTicket)
        {
            try
            {
                var connection = Elastic_Utils.ElsaticConnection();
                var serializer = new JsonNetSerializer();
                string searchCommand = Commands.Index(index: securityTicket.TenantID.ToString(), type: elasticType, id: order_id);

                return serializer.ToGetResult<Order_Model>(connection.Get(searchCommand).Result).Document;
            }
            catch
            {
                return null;
            }
        }

        public static IEnumerable<Order_Model> GetOrdersWhereIDPresent(string id, string ordinal, string tenant_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elasticType, connection))
            {
                query = QueryBuilderOrders.BuildGetOrdersWhereIDPresent(id, ordinal);

                string searchCommand_Cases = Commands.Search(tenant_id, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<Order_Model>(result).Documents;
            }

            return new List<Order_Model>();
        }

        public static long GetOrderCount(string search_params, string hip_name, Guid practice_id, string elastic_index_name, DateTime orders_from_date, DateTime orders_to_date)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            var serializer = new JsonNetSerializer();

            var command = Commands.Count(elastic_index_name, elasticType).Pretty();

            var query = QueryBuilderOrders.BuildGetPracticeOrdersQuery(0, 0, practice_id.ToString(), search_params, !String.IsNullOrEmpty(hip_name) ? hip_name.ToLower() : null, orders_from_date, orders_to_date);

            var result = connection.Post(command, query);
            var count = serializer.ToCountResult(result).count;
            return count;
        }

        public static IEnumerable<Order_Model> GetOrdersWhereForIdAndOrdinal(string id, string ordinal, string tenant_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(tenant_id, connection) && Elastic_Utils.IfIndexOrTypeExists(tenant_id + "/" + elasticType, connection))
            {
                query = QueryBuilderOrders.BuildGetOrdersForIdAndOrdinal(id, ordinal);

                string searchCommand_Cases = Commands.Search(tenant_id, elasticType).Pretty();
                string result = connection.Post(searchCommand_Cases, query);

                return serializer.ToSearchResult<Order_Model>(result).Documents;
            }

            return new List<Order_Model>();
        }


        #region Support classes
        public class PotentialPatients
        {
            public IEnumerable<PotentialPatients_ParticipationConsent> ParticipationConsent { get; set; }
            public Guid HEC_Patient_RefID { get; set; }
        }

        public class PotentialPatients_ParticipationConsent
        {
            public IEnumerable<PotentialPatients_ParticipationConsent_Drugs> CoveredDrugs { get; set; }

            public Guid InsuranceToBrokerContract_ParticipatingPatientID { get; set; }
            public DateTime ValidThrough { get; set; }
            public DateTime ValidFrom { get; set; }
        }

        public class PotentialPatients_ParticipationConsent_Drugs
        {
            public Guid HealthcareProduct_RefID { get; set; }
        }
        #endregion
    }
}
