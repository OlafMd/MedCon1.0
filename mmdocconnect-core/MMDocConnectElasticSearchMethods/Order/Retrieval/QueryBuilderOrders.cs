using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Order.Retrieval
{
    public static class QueryBuilderOrders
    {
        private static readonly string elasticType = "order";

        public static string BuildGetOrderQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string sort_by_second_key, string sort_by_third_key)
        {
            var query = new QueryBuilder<Order_Model>()
            .From(start_row_index)
                .Size(page_size).Sort(s => s
                                .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                      .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        );

            return query.BuildBeautified();
        }

        public static string BuildGetSearchOrderQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string sort_by_second_key, string sort_by_third_key, string search_params, string date_from, string date_to, Filter filter_by)
        {
            if (filter_by.filter_status == null || !filter_by.filter_status.Any())
            {
                filter_by.filter_status = new string[]
                {
                    "mo1",
                    "mo2",
                    "mo3",
                    "mo4",
                    "mo6",
                    "mo10"
                };
            }

            var query = new QueryBuilder<Order_Model>()
            .From(start_row_index)
                .Size(page_size)
                .Query(q => q
                .Bool(b => b
                .Should(sh => sh
                    .Match(m => m
                        .Field("patient_name")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("hip")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("patient_insurance_number")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("patient_birthdate_string")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("treatment_doctor_name")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("drug")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("lanr")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("bsnr")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                ).MinimumNumberShouldMatch(1)
                    .Must(mu => mu
                    .Terms(t => t.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1)))
                ))
                 .Filter(flt => flt.Range(dt => dt.Field(f => f.treatment_date).Lte(string.IsNullOrEmpty(date_to) ? "" : date_to + "T00:00:00").Gte(string.IsNullOrEmpty(date_from) ? "" : date_from + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                .Sort(s => s
                                .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                      .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        );

            return query.BuildBeautified();
        }

        public static IEnumerable<Order_Model> GetPracticeOrders(int start_row_index, int page_size, string practice_id, string index_name, string hip_name, string search_params, DateTime orders_from_date, DateTime orders_to_date)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string query = string.Empty;

            if (Elastic_Utils.IfIndexOrTypeExists(index_name, connection) && Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + elasticType, connection))
            {
                query = QueryBuilderOrders.BuildGetPracticeOrdersQuery(start_row_index, page_size, practice_id, search_params, hip_name, orders_from_date, orders_to_date);

                string search_command = Commands.Search(index_name, elasticType).Pretty();
                string result = connection.Post(search_command, query);

                return serializer.ToSearchResult<Order_Model>(result).Documents;
            }

            return Enumerable.Empty<Order_Model>();
        }

        public static string BuildGetPracticeOrdersQuery(int start_row_index, int page_size, string practice_id, string search_params, string hip_name, DateTime orders_from_date, DateTime orders_to_date, IEnumerable<string> deslected_ids = null)
        {
            var ordinals = new List<string>() {
                "patient_name",
                "hip",
                "patient_insurance_number",
                "patient_birthdate_string",
                "treatment_doctor_name",
                "drug",
                "lanr",
                "bsnr",
                "diagnose"
            };

            orders_to_date = orders_to_date.Date != DateTime.MinValue.Date ? orders_to_date : DateTime.MaxValue;

            var query = new QueryBuilder<Order_Model>()
                .Query(q => q
                    .Bool(b => b
                        .Should(sh =>
                        {
                            ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(Operator.AND)));
                            return sh;
                        })
                        .MinimumNumberShouldMatch(1)
                        .Must(m => m
                            .Range(rng => rng.Field("treatment_date").Gte(orders_from_date.ToString("yyyy-MM-dd")).Lte(orders_to_date.ToString("yyyy-MM-dd")))
                            .Term(t => t
                                .Field("practice_id")
                                .Value(practice_id))
                            .Term(t => t
                                .Field("status_drug_order.lower_case_sort")
                                .Value("mo0"))
                            .Term(t => t
                                .Field("hip.lower_case_sort")
                                .Value(hip_name)))
                        .MustNot(mn => mn.Terms(tr => tr.Field("id").Values(deslected_ids)))
                        ));

            if (page_size != 0)
            {
                query = query.Size(page_size)
                             .From(start_row_index)
                             .Sort(s => s
                                 .Field("treatment_date", SortDirection.asc)
                                 .Field("patient_name.lower_case_sort", SortDirection.asc)
                                 .Field("patient_birthdate", SortDirection.asc));
            }

            return query.BuildBeautified();
        }

        public static string BuildGetAllPracticeOrdersQuery(ElasticParameterObject sort_parameter, string practice_id, IEnumerable<string> order_ids_eligible_for_settlement)
        {
            var ordinals = new List<string>() {
                "patient_name",
                "hip",
                "patient_insurance_number",
                "patient_birthdate_string",
                "treatment_doctor_name",
                "drug",
                "lanr",
                "bsnr",
                "diagnose"
            };

            var status_list = sort_parameter.filter_by.filter_status.ToList();

            var include_ordered = sort_parameter.filter_by.ordered_drugs;
            var include_not_available = status_list.Any(t => t == "mo4");
            var include_canceled = status_list.Any(t => t == "mo6");
            var include_deleted = status_list.Any(t => t == "mo9");
            var show_only_orders = sort_parameter.filter_by.orders == true;

            var hip_name = !String.IsNullOrEmpty(sort_parameter.hip_name) ? sort_parameter.hip_name.ToLower() : null;

            var ordered_statuses = new List<String>();
            if (include_ordered)
            {
                ordered_statuses = new List<string>()
                {
                    "mo1",
                    "mo2",
                    "mo3", 
                    "mo10",
                };
            }

            var excluded_statuses = new List<String>();
            if (show_only_orders)
            {
                excluded_statuses = new List<string>()
                {
                    "mo0",
                    "mo6",
                    "mo9",
                };
            }
            var overdue_date = DateTime.Now.AddDays(sort_parameter.default_shipping_date_offset).Date;
            var orders_to_date = sort_parameter.orders_to_date.Date != DateTime.MinValue.Date ? sort_parameter.orders_to_date : DateTime.MaxValue;

            var query = new QueryBuilder<Order_Model>()
                .Query(q => q
                    .Bool(b => b
                        .Should(sh =>
                        {
                            ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(sort_parameter.search_params).Operator(Operator.AND)));
                            return sh;
                        })
                        .MinimumNumberShouldMatch(1)
                        .Must(must =>
                        {
                            must.Term(t => t.Field("practice_id").Value(practice_id));
                            must.Term(t => t.Field("hip.lower_case_sort").Value(hip_name));
                            must.Term(t => t.Field("diagnose.lower_case_sort").Value(show_only_orders ? "-" : null));

                            must.Range(rng => rng.Field("treatment_date").Gte(sort_parameter.orders_from_date.ToString("yyyy-MM-dd")).Lte(orders_to_date.ToString("yyyy-MM-dd")));

                            must.Bool(bl => bl.Should(sh =>
                            {
                                if (include_ordered)
                                {
                                    sh.Bool(shb => shb.Must(shm => shm.Terms(t1 => t1.Field("status_drug_order.lower_case_sort").Values(ordered_statuses))));
                                }

                                if (include_canceled)
                                {
                                    sh.Bool(shb => shb.Must(shm => shm.Terms(t1 => t1.Field("status_drug_order.lower_case_sort").Values("mo6"))));
                                }

                                if (include_not_available)
                                {
                                    sh.Bool(shb => shb.Must(shm => shm.Terms(t1 => t1.Field("status_drug_order.lower_case_sort").Values("mo4"))));
                                }

                                if (include_deleted)
                                {
                                    sh.Bool(shb => shb.Must(shm => shm.Terms(t1 => t1.Field("status_drug_order.lower_case_sort").Values("mo9"))));
                                }

                                if (show_only_orders && order_ids_eligible_for_settlement != null)
                                {
                                    sh.Bool(bl1 =>
                                    {
                                        bl1.Must(must1 =>
                                        {
                                            must1.Terms(t => t.Field("id").Values(order_ids_eligible_for_settlement));
                                            return must1;

                                        });
                                        return bl1;
                                    });
                                }

                                return sh;
                            })
                            .MinimumNumberShouldMatch(1));


                            return must;
                        })
                        .MustNot(mustNot =>
                            {
                                mustNot.Terms(t => t.Field("status_drug_order.lower_case_sort").Values(excluded_statuses));

                                return mustNot;
                            })
                    )
                );

            if (sort_parameter.page_size != 0)
            {
                var sort_direction = sort_parameter.isAsc ? SortDirection.asc : SortDirection.desc;
                var sort_by_first_key = "";
                var sort_by_second_key = "";
                var sort_by_third_key = "";

                switch (sort_parameter.sort_by)
                {
                    case "treatment_date":
                        sort_by_first_key = "treatment_date";
                        sort_by_second_key = "patient_name.lower_case_sort";
                        sort_by_third_key = "patient_birthdate";
                        break;

                    case "patient_name":
                        sort_by_first_key = "patient_name.lower_case_sort";
                        sort_by_second_key = "patient_birthdate";
                        sort_by_third_key = "treatment_date";
                        break;

                    case "status_drug_order":
                        sort_by_first_key = "status_drug_order.lower_case_sort";
                        sort_by_second_key = "treatment_date";
                        sort_by_third_key = "patient_name";
                        break;

                    default:
                        sort_by_first_key = sort_parameter.sort_by + ".lower_case_sort";
                        sort_by_second_key = "patient_name.lower_case_sort";
                        sort_by_third_key = "patient_birthdate";
                        break;
                }

                query = query.Size(sort_parameter.page_size)
                             .From(sort_parameter.start_row_index)
                             .Sort(s => s
                                 .Field(sort_by_first_key, sort_direction)
                                 .Field(sort_by_second_key, sort_direction)
                                 .Field(sort_by_third_key, sort_direction));
            }

            return query.BuildBeautified();
        }

        public static string BuildGetSearchOrderQueryWithOverdue(int start_row_index, int page_size, string sort_by, bool isAsc, string sort_by_second_key, string sort_by_third_key, string search_params, string date_from, string date_to, Filter filter_by)
        {
            var query = new QueryBuilder<Order_Model>()
            .From(start_row_index)
                .Size(page_size)
                .Query(q => q
                .Bool(b => b
                .Should(sh => sh
                    .Match(m => m
                        .Field("patient_name")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("hip")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("patient_insurance_number")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("patient_birthdate_string")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("treatment_doctor_name")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                     .Match(m => m
                        .Field("treatment_doctor_name")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("drug")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("lanr")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field("bsnr")
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))//isOverdue
                ).MinimumNumberShouldMatch(1)
                    .Must(ma => ma
                        .Term(te => te.Field(fi => fi.isOverdue).Value("true")))
                    .Must(mu => mu
                    .Terms(t => t.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1)))
                ))
                .Filter(flt => flt.Range(dt => dt.Field(f => f.treatment_date).Lte(date_to).Gte(date_from)))
                .Sort(s => s
                                .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                      .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        );

            return query.BuildBeautified();
        }

        public static string BuildGetOrderMO1Query(string order_status, string sort_by, bool isAsc)
        {
            var query = new QueryBuilder<Order_Model>()
            .From(0)
                .Size(1000).Query(q => q
                      .Bool(b => b
                          .Must(sh => sh
                              .Match(m => m
                                  .Field("status_drug_order.lower_case_sort")
                                  .Query(order_status)
                                  )
                        )
                       )
                      ).
                      Sort(s => s
                                .Field("treatment_date", PlainElastic.Net.SortDirection.asc)
                                  );

            return query.BuildBeautified();
        }

        public static string BuildGetOrdersWhereIDPresent(string id, string ordinal)
        {
            return new QueryBuilder<Order_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id))).MustNot(mn => mn.Terms(t => t.Field("status_drug_order.lower_case_sort").Values(new string[] { "mo3", "mo4", "mo6" })))))
                    .BuildBeautified();
        }


        public static string BuildGetOrdersForIdAndOrdinal(string id, string ordinal)
        {
            return new QueryBuilder<Order_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)))))
                    .BuildBeautified();
        }
    }
}