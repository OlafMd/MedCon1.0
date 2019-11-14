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
    public static class QueryBuilderCase
    {

        #region Planning
        public static string BuildGetCaseQuery(int start_row_index, int page_size, string sort_by, string search_params, bool isAsc, string practice_id, string sort_by_second_key, string sort_by_third_key)
        {
            var query = new QueryBuilder<Case_Model>()
            .From(start_row_index)
                .Size(page_size).Query(q => q.Bool(b => b.Should(sh => sh
                           .Match(m => m
                               .Field("patient_name")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                               )
                               .Match(m => m
                               .Field("patient_hip")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )
                               .Match(m => m
                                   .Field("patient_insurance_number")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                .Match(m => m
                               .Field("patient_birthdate_string")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )
                                .Match(m => m
                               .Field("treatment_doctor_name")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )
                                .Match(m => m
                               .Field("aftercare_name")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )
                               .Match(m => m
                               .Field("aftercare_doctor_lanr")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )
                                        .Match(m => m
                               .Field("treatment_doctor_lanr")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )
                              .Match(m => m
                               .Field("aftercare_practice_bsnr")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              )).MinimumNumberShouldMatch(1)
                    .Must(m => m
                    .Term(term => term.Field(id => id.practice_id)
                        .Value(practice_id.ToString())))))
                            .Sort(s => s
                                .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                      .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        );

            return query.BuildBeautified();
        }

        public static string BuildGetCasesWhereIDPresentQuery<T>(string id, string ordinal)
        {
            return new QueryBuilder<T>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)))))
                    .BuildBeautified();
        }

        public static string BuidlGetCasesForRollBack<T>(List<Query_Object> parameters)
        {
            return
                new QueryBuilder<T>().Size(int.MaxValue).From(0)
                    .Query(q => q.Bool(b => b.Should(sh =>
                    {
                        parameters.ForEach(ord => sh.Term(t => t.Field(ord.field).Value(ord.value)));
                        return sh;
                    }).MinimumNumberShouldMatch(1))).BuildBeautified();
        }
        public static string BuildGetCaseQueryFilter(int start_row_index, int page_size, string sort_by, bool isAsc, string practice_id, string sort_by_second_key,
            string sort_by_third_key, string search_params, Filter filter_by, string hip_name, bool skip_deleted = false, string doctor_id = null)
        {
            var ordinals = new List<string>()
            {
                "patient_name",
                "patient_hip",
                "patient_insurance_number",
                "patient_birthdate_string",
                "treatment_doctor_name",
                "aftercare_name",
                "aftercare_doctor_lanr",
                "treatment_doctor_lanr",
                "aftercare_practice_bsnr"
            };
            var min_overdue_date = DateTime.Now.Date;

            var omit_order_statuses = new List<string> { "mo6", "mo9" };

            var include_scheduled = filter_by.filter_current || filter_by.filter_status.Any(t => t == "op1");
            var only_futured_scheduled = filter_by.filter_status.Any(t => t == "op1");
            var include_overdue = filter_by.filter_current || filter_by.filter_status.Any(t => t == "op3");
            var include_deleted = skip_deleted ? false : filter_by.filter_status.Any(t => t == "op4");

            var treatmentsWithOrders = (filter_by.orders == true && filter_by.localization == "!-");
            var onlyTreatments = (filter_by.orders == false && filter_by.localization == null);

            var query = new QueryBuilder<Oct_Model>()
            .Query(q => q.Bool(b => b
                .Should(sh =>
                {
                    ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(PlainElastic.Net.Operator.AND)));
                    return sh;
                }).MinimumNumberShouldMatch(1)
                    .Must(must =>
                    {
                        must.Term(t => t.Field("practice_id").Value(practice_id));
                        must.Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name));
                        must.Term(t => t.Field("treatment_doctor_id").Value(doctor_id));
                        must.Bool(shbb => shbb.MustNot(m => m.Term(t => t.Field("localization.lower_case_sort").Value("-"))));
                        must.Bool(bl => bl.Should(sh =>
                        {
                            if (include_scheduled)
                            {
                                sh.Bool(shb => shb
                                    .Must(shm =>
                                    {
                                        shm.Term(t => t.Field("status_treatment.lower_case_sort").Value("op1"));
                                        shm.Range(t => t.Field("treatment_date").Gte(only_futured_scheduled ? min_overdue_date.ToString("yyyy-MM-ddTHH:mm:ss") : null));
                                        return shm;
                                    }));
                            }
                            if (include_overdue)
                            {
                                sh.Bool(shb => shb
                                    .Should(shm => shm
                                        .Bool(shb1 => shb1.Must(shbm => shbm
                                            .Term(t => t.Field("status_treatment.lower_case_sort").Value("op1"))
                                            .Range(rng => rng.Field("treatment_date").Lt(min_overdue_date.ToString("yyyy-MM-ddTHH:mm:ss")))))
                                        .Bool(shb1 => shb1.Must(shbm => shbm
                                            .Term(t => t.Field("status_treatment.lower_case_sort").Value("op3"))))
                                    ));
                            }
                            if (include_deleted)
                            {
                                sh.Bool(shb => shb.Must(shm => shm.Term(t => t.Field("status_treatment.lower_case_sort").Value("op4"))));
                            }
                            return sh;
                        }));
                        if (treatmentsWithOrders)
                        {
                            must.Bool(shb => shb.Must(m => m.Term(t => t.Field("is_orders_drug").Value("true"))));
                            must.Bool(shb => shb.MustNot(m => m.Terms(t => t.Field("status_drug_order.lower_case_sort").Values(omit_order_statuses))));
                        }
                        if (onlyTreatments)
                        {
                            must.Bool(shb => shb.Must(m => m.Term(t => t.Field("is_orders_drug").Value("false"))));
                        }
                        return must;
                    })
                ));

            if (page_size != 0)
            {
                query = query.Size(page_size).From(start_row_index);
            }

            if (!String.IsNullOrEmpty(sort_by))
            {
                var sort_direction = isAsc ? SortDirection.asc : SortDirection.desc;
                query = query.Sort(s => s
                        .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", sort_direction)
                        .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", sort_direction)
                        .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", sort_direction)
                );
            }

            return query.BuildBeautified();
        }


        public static string BuildGetCasesinIDArrayQuery(string practice_id, string[] case_ids, int size, bool is_submit, string authorizing_doctor_id, string sort_by, bool isAsc)
        {
            string sort_by_second_key = "";
            string sort_by_third_key = "";

            switch (sort_by)
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

            var query = new QueryBuilder<Case_Model>().Size(size)
                .Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m
                    .Term(term => term.Field(id => id.practice_id).Value(practice_id.ToString()))
                    .Terms(t => t.Field("id").Values(case_ids))
                    .Term(pract => pract.Field("practice_id").Value(practice_id)).Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null)))
                    .MustNot(mn => mn.Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))))))).
                    Sort(s => s
                        .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                            .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                              .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                );

            return query.BuildBeautified();
        }

        public static string BuildGetCasesCountQuery(string search_params, string practice_id, Filter filter_by, string date_from, string date_to, int? page_size, bool is_submit, string[] deselected_ids, string authorizing_doctor_id,
            string sort_by, bool isAsc, string hip_name)
        {
            var primary_field = is_submit ? "aftercare_name.lower_case_sort" : "localization.lower_case_sort";

            string sort_by_second_key = "";
            string sort_by_third_key = "";

            switch (sort_by)
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

            var query = new QueryBuilder<Case_Model>();
            if (!page_size.HasValue)
            {
                if (!filter_by.filter_current)
                {
                    if (filter_by.localization == "!-")
                    {
                        query = query.Query(q => q
                            .Bool(b => b.Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null)))
                                .MustNot(ms => ms.Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-"))
                                              .Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4")))
                                 .Should(sh => sh
                                   .Match(m => m
                                       .Field("patient_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                       .Match(m => m
                                       .Field("patient_hip")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                       .Match(m => m
                                       .Field("patient_insurance_number")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field("patient_birthdate_string")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field("treatment_doctor_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                      .Match(m => m
                                   .Field("aftercare_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                       .Match(m => m
                                       .Field("aftercare_doctor_lanr")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                      .Match(m => m
                                       .Field("aftercare_practice_bsnr")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))).MinimumNumberShouldMatch(filter_by.filter_status.Length == 0 ? 1 : 2)));
                    }
                    else if (filter_by.localization == "-" && filter_by.orders == true)
                    {//only orders
                        if (filter_by.filter_type.Contains("mo4"))
                        {
                            query = query.Query(q => q
                                 .Bool(b => b
                                     .MustNot(ms => ms.Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                                     .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                     .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null))
                                     .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")).Range(t4 => t4.Field(fd => fd.treatment_date).Gte(DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                                      .Should(sh => sh
                                        .Match(m => m
                                            .Field("patient_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                            )
                                            .Match(m => m
                                            .Field("patient_hip")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                            .Field("patient_insurance_number")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                             .Match(m => m
                                            .Field("patient_birthdate_string")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                             .Match(m => m
                                            .Field("treatment_doctor_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                        .Field("aftercare_name")
                                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                            .Match(m => m
                                            .Field("aftercare_doctor_lanr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                            .Field("aftercare_practice_bsnr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))
                                   ).MinimumNumberShouldMatch(string.IsNullOrEmpty(search_params) ? 1 : 2)));
                        }
                        else
                        {
                            query = query
                                .Query(q => q
                                    .Bool(b => b.MustNot(ms => ms.Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-"))
                                              .Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4")))
                                        .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                            .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-"))
                                        .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null))
                                        .Range(t4 => t4.Field(fd => fd.treatment_date).Gte(DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                                     .Should(sh => sh
                                       .Match(m => m
                                           .Field("patient_name")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                           .Field("patient_hip")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                           .Match(m => m
                                           .Field("patient_insurance_number")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                            .Match(m => m
                                           .Field("patient_birthdate_string")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                            .Match(m => m
                                           .Field("treatment_doctor_name")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                          .Match(m => m
                                       .Field("aftercare_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                           .Match(m => m
                                           .Field("aftercare_doctor_lanr")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                          .Match(m => m
                                           .Field("aftercare_practice_bsnr")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))
                                  ).MinimumNumberShouldMatch(1)));
                        }
                    }
                    else //localization
                    {
                        if (filter_by.filter_type.Contains("mo4"))
                        {
                            query = query.
                                Query(q => q
                                 .Bool(b => b.MustNot(ms => ms.Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")).Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4")))
                                     .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                     .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null)))
                                      .Should(sh => sh
                                        .Match(m => m
                                            .Field("patient_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                            )
                                            .Match(m => m
                                            .Field("patient_hip")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                             .Match(m => m
                                            .Field("patient_birthdate_string")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                             .Field("patient_insurance_number")
                                             .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                            )
                                             .Match(m => m
                                            .Field("treatment_doctor_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                         .Field("aftercare_name")
                                         .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                        )
                                            .Match(m => m
                                            .Field("aftercare_doctor_lanr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                            .Field("aftercare_practice_bsnr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))).MinimumNumberShouldMatch(string.IsNullOrEmpty(search_params) ? 1 : 2)));
                        }
                        else
                        {
                            query = query.
                                Query(q => q
                                    .Bool(b => b.MustNot(ms => ms.Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-"))
                                        .Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4")))
                                        .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                        .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null)))
                                    .Should(sh => sh
                                      .Match(m => m
                                          .Field("patient_name")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                          .Match(m => m
                                          .Field("patient_hip")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                           .Match(m => m
                                          .Field("patient_birthdate_string")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                          .Match(m => m
                                           .Field("patient_insurance_number")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                           .Match(m => m
                                          .Field("treatment_doctor_name")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                          .Match(m => m
                                       .Field("aftercare_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                          .Match(m => m
                                          .Field("aftercare_doctor_lanr")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                         .Match(m => m
                                          .Field("aftercare_practice_bsnr")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))).MinimumNumberShouldMatch(filter_by.filter_status.Length == 0 ? 1 : 2)));
                        };

                    }//end locazlization 
                }//end current

                else
                { //current
                    query = query
                        .Query(q => q
                        .Bool(b => b
                            .MustNot(ms => ms.Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-"))
                                              .Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4")))
                            .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name)))
                             .Should(sh => sh
                               .Match(m => m
                                   .Field("patient_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                   .Match(m => m
                                   .Field("patient_hip")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                    .Match(m => m
                                   .Field("patient_birthdate_string")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                   .Match(m => m
                                       .Field("patient_insurance_number")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                    .Match(m => m
                                   .Field("treatment_doctor_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                  .Match(m => m
                                   .Field("aftercare_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                   .Match(m => m
                                   .Field("aftercare_doctor_lanr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                  .Match(m => m
                                   .Field("aftercare_practice_bsnr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                 .Bool(bl => bl.MustNot(tr => tr.Term(tr2 => tr2.Field("localization.lower_case_sort").Value("-")).Term(tr3 => tr3.Field("status_treatment.lower_case_sort").Value("op4")))
                                ).Bool(bl => bl.Must(tr => tr.Term(tr2 => tr2.Field("localization.lower_case_sort").Value("-"))
                                .Range(t4 => t4.Field(fd => fd.treatment_date).Gte(DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2)))))).MinimumNumberShouldMatch(string.IsNullOrEmpty(search_params) ? 1 : 2)));
                }
            }
            else
            {
                if (!filter_by.filter_current)
                {
                    if (filter_by.localization == "!-")
                    {
                        query = query.Size(page_size.Value).Query(q => q
                            .Bool(b => b.Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                .Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null))
                                .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null)))
                                .MustNot(ms => ms.Term(tr => tr.Field(primary_field).Value("-"))
                                              .Term(tr => tr.Field("treatment_doctor_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Term(tr => tr.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Terms(tr => tr.Field("id").Values(deselected_ids))
                                              .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                                 .Should(sh => sh
                                   .Match(m => m
                                       .Field("patient_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                       .Match(m => m
                                       .Field("patient_hip")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                       .Match(m => m
                                       .Field("patient_insurance_number")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field("patient_birthdate_string")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field("treatment_doctor_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                      .Match(m => m
                                   .Field("aftercare_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                       .Match(m => m
                                       .Field("aftercare_doctor_lanr")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                      .Match(m => m
                                       .Field("aftercare_practice_bsnr")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                              ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type)))
                              .MinimumNumberShouldMatch(filter_by.filter_status.Length == 0 ? 1 : 2)))
                              .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );
                    }
                    else if (filter_by.localization == "-" && filter_by.orders == true)
                    {//only orders
                        if (filter_by.filter_type.Contains("mo4"))
                        {
                            query = query.Size(page_size.Value).Query(q => q
                                 .Bool(b => b.MustNot(mn => mn.Term(tr => tr.Field(primary_field).Value("-"))
                                              .Term(tr => tr.Field("treatment_doctor_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Term(tr => tr.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Terms(tr => tr.Field("id").Values(deselected_ids))
                                              .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                                     .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                         .Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null))
                                         .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null))
                                         .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")).Range(t4 => t4.Field(fd => fd.treatment_date).Gte(DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                                      .Should(sh => sh
                                        .Match(m => m
                                            .Field("patient_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                            )
                                            .Match(m => m
                                            .Field("patient_hip")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                            .Field("patient_insurance_number")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                             .Match(m => m
                                            .Field("patient_birthdate_string")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                             .Match(m => m
                                            .Field("treatment_doctor_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                        .Field("aftercare_name")
                                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                            .Match(m => m
                                            .Field("aftercare_doctor_lanr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                            .Field("aftercare_practice_bsnr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))
                                   ).MinimumNumberShouldMatch(string.IsNullOrEmpty(search_params) ? 1 : 2)))
                                   .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );
                        }
                        else
                        {
                            query = query.Size(page_size.Value)
                                .Query(q => q
                                    .Bool(b => b.MustNot(mn => mn.Term(tr => tr.Field(primary_field).Value("-"))
                                              .Term(tr => tr.Field("treatment_doctor_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Term(tr => tr.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Terms(tr => tr.Field("id").Values(deselected_ids))
                                              .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                                        .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                            .Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null))
                                            .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null))
                                            .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")).Range(t4 => t4.Field(fd => fd.treatment_date).Gte(DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                                     .Should(sh => sh
                                       .Match(m => m
                                           .Field("patient_name")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                           .Field("patient_hip")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                           .Match(m => m
                                           .Field("patient_insurance_number")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                            .Match(m => m
                                           .Field("patient_birthdate_string")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                            .Match(m => m
                                           .Field("treatment_doctor_name")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                          .Match(m => m
                                       .Field("aftercare_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                           .Match(m => m
                                           .Field("aftercare_doctor_lanr")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                          .Match(m => m
                                           .Field("aftercare_practice_bsnr")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type))
                                  ).MinimumNumberShouldMatch(1))).Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );
                        }
                    }
                    else //localization
                    {
                        if (filter_by.filter_type.Contains("mo4"))
                        {
                            query = query.Size(page_size.Value)
                                .Query(q => q
                                 .Bool(b => b
                                 .MustNot(mn => mn.Term(tr => tr.Field(primary_field).Value("-"))
                                              .Term(tr => tr.Field("treatment_doctor_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Term(tr => tr.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Terms(tr => tr.Field("id").Values(deselected_ids))
                                              .Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                                     .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                         .Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null))
                                         .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null))
                                         .Term(tr4 => tr4.Field("localization.lower_case_sort").Value(filter_by.localization)))
                                      .Should(sh => sh
                                        .Match(m => m
                                            .Field("patient_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                            )
                                            .Match(m => m
                                            .Field("patient_hip")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                             .Match(m => m
                                            .Field("patient_birthdate_string")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                             .Field("patient_insurance_number")
                                             .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                            )
                                             .Match(m => m
                                            .Field("treatment_doctor_name")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                         .Field("aftercare_name")
                                         .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                        )
                                            .Match(m => m
                                            .Field("aftercare_doctor_lanr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Match(m => m
                                            .Field("aftercare_practice_bsnr")
                                            .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type)))
                                   .MinimumNumberShouldMatch(string.IsNullOrEmpty(search_params) ? 1 : 2))).Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );
                        }
                        else
                        {
                            query = query.Size(page_size.Value)
                                .Query(q => q
                                    .Bool(b => b
                                    .MustNot(mn => mn.Term(tr => tr.Field(primary_field).Value("-"))
                                              .Term(tr => tr.Field("treatment_doctor_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Term(tr => tr.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Terms(tr => tr.Field("id").Values(deselected_ids))
                                              .Term(t1 => t1.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                                        .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                            .Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null))
                                            .Terms(t => t.Field(fld => fld.is_orders_drug).Values(filter_by.orders.HasValue ? filter_by.orders.Value.ToString().ToLower() : null))
                                            .Term(tr4 => tr4.Field("localization.lower_case_sort").Value(filter_by.localization)))
                                    .Should(sh => sh
                                      .Match(m => m
                                          .Field("patient_name")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                          .Match(m => m
                                          .Field("patient_hip")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                           .Match(m => m
                                          .Field("patient_birthdate_string")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                          .Match(m => m
                                           .Field("patient_insurance_number")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                           .Match(m => m
                                          .Field("treatment_doctor_name")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                          .Match(m => m
                                       .Field("aftercare_name")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                          .Match(m => m
                                          .Field("aftercare_doctor_lanr")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                         )
                                         .Match(m => m
                                          .Field("aftercare_practice_bsnr")
                                          .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 ).Terms(t1 => t1.Field("status_treatment.lower_case_sort").Values(filter_by.filter_status)).Terms(t2 => t2.Field("status_drug_order.lower_case_sort").Values(filter_by.filter_type)))
                                 .MinimumNumberShouldMatch(filter_by.filter_status.Length == 0 ? 1 : 2))).Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );
                        };

                    }//end locazlization 
                }//end current

                else
                { //current
                    query = query.Size(page_size.Value)
                        .Query(q => q
                        .Bool(b => b.MustNot(mn => mn.Term(tr => tr.Field(primary_field).Value("-"))
                                              .Term(tr => tr.Field("treatment_doctor_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Term(tr => tr.Field("status_treatment.lower_case_sort").Value("op4"))
                                              .Term(tr => tr.Field("aftercare_name.lower_case_sort").Value(is_submit ? "-" : null))
                                              .Terms(tr => tr.Field("id").Values(deselected_ids))
                                              .Term(tr4 => tr4.Field("localization.lower_case_sort").Value("-")))
                            .Must(m => m.Term(tr4 => tr4.Field(id => id.practice_id).Value(practice_id)).Term(t => t.Field("patient_hip.lower_case_sort").Value(hip_name))
                                .Term(tr => tr.Field("treatment_doctor_id").Value(is_submit ? authorizing_doctor_id : null)))
                             .Should(sh => sh
                               .Match(m => m
                                   .Field("patient_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                   .Match(m => m
                                   .Field("patient_hip")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                    .Match(m => m
                                   .Field("patient_birthdate_string")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                   .Match(m => m
                                       .Field("patient_insurance_number")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                    .Match(m => m
                                   .Field("treatment_doctor_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                  .Match(m => m
                                   .Field("aftercare_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                   .Match(m => m
                                   .Field("aftercare_doctor_lanr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                  .Match(m => m
                                   .Field("aftercare_practice_bsnr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                                 .Bool(bl => bl.MustNot(tr => tr.Term(tr2 => tr2.Field("localization.lower_case_sort").Value("-")).Term(tr3 => tr3.Field("status_treatment.lower_case_sort").Value("op4")))
                                ).Bool(bl => bl.Must(tr => tr.Range(t4 => t4.Field(fd => fd.treatment_date).Gte(DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))))
                                .MinimumNumberShouldMatch(string.IsNullOrEmpty(search_params) ? 1 : 2))).Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );
                }
            }
            return query.BuildBeautified();
        }
        #endregion

        #region Treatments
        public static string BuildGetSubmittedCasesInErrorCorrectionAndWhereIDPresentQuery(string id, string ordinal, string case_type)
        {
            return new QueryBuilder<Submitted_Case_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)).Term(t => t.Field(f => f.type).Value(case_type))
                    .Bool(b1 => b1.Should(s => s.Term(t => t.Field("status.lower_case_sort").Value("fs5"))
                        .Term(t => t.Field("status.lower_case_sort").Value("fs6"))).MinimumNumberShouldMatch(1))))).BuildBeautified();
        }

        public static string BuildGetAllCaseQuery(string p_status, string tenant_id)
        {
            var query = new QueryBuilder<Submitted_Case_Model>().Size(int.MaxValue)
                .Query(q => q.Bool(b => b.Should(s => s.Match(m => m.Field("status.lower_case_sort").Query(p_status.ToLower())))));

            return query.BuildBeautified();
        }

        public static string BuildGetSubmittedCasesinIDArrayQuery(string[] case_ids, int size, string status)
        {
            var query = new QueryBuilder<Submitted_Case_Model>().Size(size)
                .Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m.Terms(t => t.Field("id").Values(case_ids)))
                    .MustNot(mn => mn.Term(tr => tr.Field("status.lower_case_sort").Value(status)))))));

            return query.BuildBeautified();
        }

        public static string BuildGetSubmittedCaseQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string sort_by_second_key, string sort_by_third_key, string sort_by_fourth_key, string sort_by_fifth_key)
        {
            QueryBuilder<Submitted_Case_Model> query = new QueryBuilder<Submitted_Case_Model>();
            if (string.IsNullOrEmpty(sort_by_fourth_key))
            {

                query = new QueryBuilder<Submitted_Case_Model>()
                .From(start_row_index)
                    .Size(page_size)
                        .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("type") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                       );
            }
            else
            {
                query = new QueryBuilder<Submitted_Case_Model>()
                .From(start_row_index)
                    .Size(page_size)
                        .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("type") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        .Field(sort_by_fourth_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                            .Field(sort_by_fifth_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc));
            }
            return query.BuildBeautified();
        }


        public static string BuildGetSubmittedCasesSearchAsYouTypeQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string search_params, Filter filter_by, string sort_by_second_key, string sort_by_third_key, string sort_by_fourth_key, string sort_by_fifth_key, string date_from, string date_to)
        {
            QueryBuilder<Submitted_Case_Model> query = new QueryBuilder<Submitted_Case_Model>();
            if (!string.IsNullOrEmpty(sort_by_fourth_key))
            {
                query = new QueryBuilder<Submitted_Case_Model>()
                    .From(start_row_index)
                       .Size(page_size)
                   .Query(q => q
                       .Bool(b => b
                           .Should(sh => sh
                               .Match(m => m
                                   .Field("doctor_lanr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("patient_birthdate_string")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("patient_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("hip_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("diagnose")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("patient_insurance_number")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("doctor_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("practice_bsnr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                               ).MinimumNumberShouldMatch(1)
                               .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values(filter_by.filter_type).MinimumMatch(1)).Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1)))
                       ))
                       .Filter(flt => flt.Range(dt => dt.Field(f => f.treatment_date).Lte(string.IsNullOrEmpty(date_to) ? "" : date_to + "T00:00:00").Gte(string.IsNullOrEmpty(date_from) ? "" : date_from + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                       .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("type") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        .Field(sort_by_fourth_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                            .Field(sort_by_fifth_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc));
            }
            else
            {
                query = new QueryBuilder<Submitted_Case_Model>()
                    .From(start_row_index)
                       .Size(page_size)
                   .Query(q => q
                       .Bool(b => b
                           .Should(sh => sh
                               .Match(m => m
                                   .Field("doctor_lanr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("patient_birthdate_string")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("patient_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("hip_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("diagnose")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("patient_insurance_number")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("doctor_name")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                                .Match(m => m
                                   .Field("practice_bsnr")
                                   .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                   )
                               ).MinimumNumberShouldMatch(1)
                               .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values(filter_by.filter_type).MinimumMatch(1)).Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1)))
                       ))
                       .Filter(flt => flt.Range(dt => dt.Field(f => f.treatment_date).Lte(string.IsNullOrEmpty(date_to) ? "" : date_to + "T00:00:00").Gte(string.IsNullOrEmpty(date_from) ? "" : date_from + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                       .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("type") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                       );

            }

            return query.BuildBeautified();
        }

        public static string BuildGetSubmittedCasesCountQuery(string search_params, Filter filter_by, string date_from, string date_to, int? page_size, string status)
        {

            var query = new QueryBuilder<Submitted_Case_Model>();
            if (!page_size.HasValue)
            {
                query = new QueryBuilder<Submitted_Case_Model>()
                    .Query(q => q
                     .Bool(b => b
                         .Should(sh => sh
                             .Match(m => m
                                 .Field("doctor_lanr")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("patient_birthdate_string")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("patient_name")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("hip_name")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("diagnose")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("patient_insurance_number")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("doctor_name")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("practice_bsnr")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                             ).MinimumNumberShouldMatch(1)
                              .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values(filter_by.filter_type).MinimumMatch(1))
                                 .Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1))
                             .Range(dt => dt.Field(f => f.treatment_date).Lte(date_to).Gte(date_from)))
                     ));
            }
            else
            {
                query = new QueryBuilder<Submitted_Case_Model>()
                    .From(0).Size(page_size.Value).Query(q => q
                     .Bool(b => b
                         .Should(sh => sh
                             .Match(m => m
                                 .Field("doctor_lanr")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("patient_birthdate_string")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("patient_name")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("hip_name")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("diagnose")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("patient_insurance_number")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("doctor_name")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                              .Match(m => m
                                 .Field("practice_bsnr")
                                 .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                 )
                             ).MinimumNumberShouldMatch(1)
                              .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values(filter_by.filter_type).MinimumMatch(1))
                                 .Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1))
                             .Range(dt => dt.Field(f => f.treatment_date).Lte(date_to).Gte(date_from)))
                             .MustNot(mn => mn.Term(t => t.Field("status.lower_case_sort").Value(status)))
                     ));

            }
            return query.BuildBeautified();
        }
        #endregion

        #region Aftercares
        public static string BuildGetAftercaresinIDArrayQuery(string practice_id, string[] case_ids, int size, bool is_submit, string authorizing_doctor_id, string sort_by, bool isAsc)
        {
            var sort_by_second_key = String.Empty;
            var sort_by_third_key = String.Empty;

            switch (sort_by)
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

            var query = new QueryBuilder<Aftercare_Model>().Size(size)
                .Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m
                    .Term(term => term.Field(id => id.practice_id).Value(practice_id.ToString())).Terms(t => t.Field("id").Values(case_ids))
                        .Term(tr => tr.Field("aftercare_doctor_practice_id").Value(is_submit ? authorizing_doctor_id : null)))))))
                         .Sort(s => s
                                .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                      .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        );


            return query.BuildBeautified();
        }


        public static string BuildGetAftercaresCountQuery(string search_params, string practice_id, Filter filter_by, string date_from, string date_to, int? page_size, bool is_submit,
            string account_id, bool is_practice, string[] deselected_ids, string authorizing_doctor_id, string sort_by, bool isAsc, List<AftercareHipParameter> rangeParameters, string hip_name)
        {
            var ordinals = new List<string>()
            {
                "patient_birthdate_string",
                "aftercare_doctor_name",
                "treatment_doctor_name",
                "patient_name",
                "hip",
                "ac_lanr",
                "op_lanr",
                "bsnr",
            };

            var sort_by_second_key = "";
            var sort_by_third_key = "";

            switch (sort_by)
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

            var include_overdue = filter_by.filter_status.Any(t => t == "ac3") || filter_by.filter_current;
            var include_open = filter_by.filter_status.Any(t => t == "ac1") || filter_by.filter_current;
            if (include_overdue && !filter_by.filter_status.Any(r => r == "ac1"))
            {
                var status_list = filter_by.filter_status.ToList();
                status_list.Add("ac1");
                filter_by.filter_status = status_list.ToArray();
            }

            if (!filter_by.filter_status.Any())
            {
                var status_list = filter_by.filter_status.ToList();
                status_list.Add("ac1");
                filter_by.filter_status = status_list.ToArray();
                include_overdue = true;
            }


            var query = new QueryBuilder<Aftercare_Model>();
            if (!page_size.HasValue)
            {
                query = new QueryBuilder<Aftercare_Model>()
                    .Query(q => q
                     .Bool(b => b
                         .MustNot(mn => mn.Term(tr => tr.Field("status.lower_case_sort").Value("ac4")))
                         .Should(sh =>
                         {
                             ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(PlainElastic.Net.Operator.AND)));
                             return sh;
                         }).MinimumNumberShouldMatch(1)
                         .Must(must =>
                         {
                             if (!include_overdue)
                             {
                                 must.Bool(b1 => b1.Must(m => m.Bool(bl => bl.Should(sh =>
                                 {
                                     rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Gte(r.OverdueDate))
                                                                                      .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                                     return sh;
                                 })
                                 .MinimumNumberShouldMatch(1))));
                             }

                             if (!include_open)
                             {
                                 must.Bool(b1 => b1.Must(m => m.Bool(bl => bl.Should(sh =>
                                 {
                                     rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Lt(r.OverdueDate))
                                                                                      .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                                     return sh;
                                 })
                                 .MinimumNumberShouldMatch(1))));
                             }

                             must.Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1));
                             must.Term(pract => pract.Field("practice_id").Value(practice_id));
                             must.Term(t => t.Field("hip.lower_case_sort").Value(hip_name));

                             must.Bool(mb => mb.Should(sh =>
                             {
                                 rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Gte(r.MinimumTreatmentDate))
                                                                                 .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                                 return sh;
                             }).MinimumNumberShouldMatch(1));

                             return must;
                         })));
            }
            else
            {
                query = new QueryBuilder<Aftercare_Model>()
                    .From(0).Size(page_size.Value).Query(q => q
                     .Bool(b => b
                         .MustNot(mn => mn.Terms(tr => tr.Field("id").Values(deselected_ids))
                                          .Term(tr => tr.Field("status.lower_case_sort").Value("ac4")))
                         .Should(sh =>
                         {
                             ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(PlainElastic.Net.Operator.AND)));
                             return sh;
                         }).MinimumNumberShouldMatch(1)
                              .Must(must =>
                              {
                                  if (!include_overdue)
                                  {
                                      must.Bool(b1 => b1.Must(m => m.Bool(bl => bl.Should(sh =>
                                      {
                                          rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Gte(r.OverdueDate))
                                                                                           .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                                          return sh;
                                      })
                                      .MinimumNumberShouldMatch(1))));
                                  }

                                  if (!include_open)
                                  {
                                      must.Bool(b1 => b1.Must(m => m.Bool(bl => bl.Should(sh =>
                                      {
                                          rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Lt(r.OverdueDate))
                                                                                           .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                                          return sh;
                                      })
                                      .MinimumNumberShouldMatch(1))));
                                  }

                                  must.Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1))
                                      .Term(pract => pract.Field("practice_id").Value(practice_id))
                                      .Term(tr => tr.Field("aftercare_doctor_practice_id").Value(is_submit ? authorizing_doctor_id : null))
                                      .Range(dt => dt.Field(f => f.treatment_date).Lte(date_to).Gte(date_from));

                                  return must;
                              })
                     ))
                    .Filter(flt => flt.Bool(b => b.Must(m => m.Bool(bl => bl.Should(sh =>
                    {
                        rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Gte(r.MinimumTreatmentDate))
                                                                       .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                        return sh;
                    })))))
                     .Sort(s => s
                            .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    );

            }

            return query.BuildBeautified();
        }

        public static string BuildGetAftercaresQuery(int start_row_index, int page_size, string sort_by, string search_params, bool isAsc, string practice_id, string sort_by_second_key,
            string sort_by_third_key, Filter filter_by, List<AftercareHipParameter> rangeParameters, string hip_name, IEnumerable<string> deselected_ids = null)
        {
            var ordinals = new List<string>()
            {
                "patient_birthdate_string",
                "aftercare_doctor_name",
                "treatment_doctor_name",
                "patient_name",
                "hip",
                "ac_lanr",
                "op_lanr",
                "bsnr",
            };

            var filtered_by_status = filter_by.filter_status.Any();
            if (!filtered_by_status && filter_by.filter_current)
            {
                filter_by.filter_status = new string[] { "ac1", "ac3" };
            }

            var include_overdue = filter_by.filter_status.Any(t => t == "ac3") || filter_by.filter_current;
            var include_open = filter_by.filter_status.Any(t => t == "ac1") || filter_by.filter_current;
            var include_withdrawn = filter_by.filter_status.Any(t => t == "ac4");
            if (include_overdue && !filter_by.filter_status.Any(r => r == "ac1"))
            {
                var status_list = filter_by.filter_status.ToList();
                status_list.Add("ac1");
                filter_by.filter_status = status_list.ToArray();
            }

            if (!filter_by.filter_status.Any())
            {
                var status_list = filter_by.filter_status.ToList();
                status_list.Add("ac1");
                status_list.Add("ac4");
                filter_by.filter_status = status_list.ToArray();
                include_overdue = true;
                include_open = true;
                include_withdrawn = true;
            }

            var query = new QueryBuilder<Oct_Model>()
                .Query(q => q.Bool(b => b
                    .Should(sh =>
                    {
                        ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(PlainElastic.Net.Operator.AND)));
                        return sh;
                    }).MinimumNumberShouldMatch(1)
                    .Must(must =>
                    {
                        must.Term(t => t.Field("practice_id").Value(practice_id));
                        must.Terms(t => t.Field("status.lower_case_sort").Values(filter_by.filter_status));
                        must.Terms(t => t.Field("hip.lower_case_sort").Values(hip_name));
                        if (!include_overdue)
                        {
                            must.Bool(b1 => b1.Must(m => m.Bool(bl => bl.Should(sh =>
                            {
                                rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Gte(r.OverdueDate))
                                                                                 .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));

                                sh.Term(t => t.Field("status.lower_case_sort").Value(!include_withdrawn ? null : "ac4"));
                                return sh;
                            })
                            .MinimumNumberShouldMatch(1))));
                        }

                        if (!include_open)
                        {
                            must.Bool(b1 => b1.Must(m => m.Bool(bl => bl.Should(sh =>
                            {
                                rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Lt(r.OverdueDate))
                                                                                 .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));

                                sh.Term(t => t.Field("status.lower_case_sort").Value(!include_withdrawn ? null : "ac4"));
                                return sh;
                            })
                            .MinimumNumberShouldMatch(1))));
                        }

                        return must;
                    })
                    .MustNot(mn => mn.Terms(t => t.Field("id").Values(deselected_ids))
                                     .Term(t => t.Field("status.lower_case_sort").Value(include_withdrawn ? null : "ac4")))
                ))
                .Filter(flt => flt.Bool(b => b.Must(m => m.Bool(bl => bl.Should(sh =>
                {
                    rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm.Range(rng => rng.Field("treatment_date").Gte(r.MinimumTreatmentDate))
                                                                   .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk)))));
                    return sh;
                })))));

            if (page_size != 0)
            {
                query = query.Size(page_size).From(start_row_index);
            }

            if (!String.IsNullOrEmpty(sort_by))
            {
                query = query.Sort(s => s
                                .Field(sort_by.Equals("treatment_date") || sort_by.Equals("status") ? sort_by : sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                    .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                      .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                        );
            }

            return query.BuildBeautified();
        }
        #endregion

    }
}
