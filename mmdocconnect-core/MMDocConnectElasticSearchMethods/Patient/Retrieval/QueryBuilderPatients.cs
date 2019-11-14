using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Oct.Entity;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Patient.Retrieval
{
    public static class QueryBuilderPatients
    {
        public static string BuildGetPatientDetailsQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string patient_id, string sort_by_second_key,
            IEnumerable<string> op_case_ids, IEnumerable<string> doctor_ids, IEnumerable<string> other_case_ids, List<DateTime> min_fee_waiver_dates, string practice_id,
            List<string> consent_ids, List<OctHipParameter> octRangeParameters, List<AftercareHipParameter> acRangeParameters)
        {
            var statuses_to_omit = op_case_ids.Any() ? new List<string>() { "oct4", "op4", "oct1" } : null;

            var query = new QueryBuilder<PatientDetailViewModel>()
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Term(m => m
                        .Field("patient_id")
                        .Value(patient_id))
                    .Bool(bl => bl.Should(sh => sh
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Terms(m => m
                                        .Field("case_id")
                                        .Values(op_case_ids)))
                                .MustNot(shmn => shmn
                                    .Terms(t => t
                                        .Field("status.lower_case_sort")
                                        .Values(statuses_to_omit)))
                            )
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Terms(m => m
                                        .Field("aftercare_doctor_practice_id")
                                        .Values(doctor_ids))
                                    .Term(t => t
                                        .Field("detail_type")
                                        .Value("ac"))
                                )
                            )
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Terms(m => m
                                        .Field("treatment_doctor_id")
                                        .Values(doctor_ids))
                                    .Term(t => t
                                        .Field("detail_type")
                                        .Value("oct"))
                                )
                            )
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Terms(m => m
                                        .Field("case_id")
                                        .Values(other_case_ids))
                                    .Term(t => t
                                        .Field("detail_type")
                                        .Value("op"))
                                )
                            )
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Term(m => m
                                        .Field("patient_id")
                                        .Value(patient_id))
                                    .Term(t => t
                                        .Field("detail_type")
                                        .Value("order"))
                                    .Term(t => t
                                        .Field("practice_id")
                                        .Value(practice_id))
                                )
                            )
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Term(t => t
                                        .Field("detail_type.lower_case_sort")
                                        .Value("fee_waiver"))
                                    .Bool(shmb => shmb
                                        .Should(shmbsh =>
                                        {
                                            min_fee_waiver_dates.ForEach(min => shmbsh.Range(rng => rng.Field("date")
                                                .Lte(min.ToString("yyyy-MM-dd"))
                                                .Gte(new DateTime(min.Year, 1, 1).ToString("yyyy-MM-dd"))
                                            ));
                                            shmbsh.Term(t => t.Field("practice_id").Value(practice_id));

                                            return shmbsh;
                                        }).MinimumNumberShouldMatch(1))
                                )
                            )
                            .Bool(shb => shb
                                .Must(shm => shm
                                    .Term(t => t
                                        .Field("detail_type.lower_case_sort")
                                        .Value("participation"))
                                    .Bool(shmb => shmb
                                        .Should(shmbsh =>
                                        {
                                            shmbsh.Terms(t => t.Field("id").Values(consent_ids));
                                            shmbsh.Term(t => t.Field("practice_id").Value(practice_id));

                                            return shmbsh;
                                        }).MinimumNumberShouldMatch(1))
                                )
                            )
                   ).MinimumNumberShouldMatch(1)))))

                .Filter(flt => flt.Bool(b => b.Must(m => m.Bool(bl => bl.Should(sh =>
                {
                    //Check if ac is hidden
                    acRangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm
                        .Term(trs => trs.Field("detail_type.lower_case_sort").Value("ac"))
                        .Terms(trs => trs.Field("status.lower_case_sort").Values(new String[] { "ac1", "ac3", "fs0", "ac4" }))
                        .Range(rng => rng.Field("date").Gte(r.MinimumTreatmentDate))
                        .Term(tr => tr.Field("hip_ik").Value(r.HipIk)))));

                    //check if oct is hidden
                    octRangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm
                      .Term(trs => trs.Field("detail_type.lower_case_sort").Value("oct"))
                      .Terms(trs => trs.Field("status.lower_case_sort").Values(new String[] { "oct1", "oct5" }))
                      .Range(rng => rng.Field("date").Gte(r.MinimumTreatmentDate == "0001-01-01" ? null : r.MinimumTreatmentDate))
                      .Term(tr => tr.Field("hip_ik").Value(r.HipIk)))));

                    //we have to hide only oct1 and oct5 octs so if we have other types we should show them
                    sh.Bool(shb => shb.Must(shbm => shbm
                        .Term(tr => tr.Field("detail_type.lower_case_sort").Value("oct"))
                        .Bool(shbmb => shbmb
                            .MustNot(mn => mn.Terms(tr => tr.Field("status.lower_case_sort").Values(new string[] { "oct1", "oct5" }))))
                        ));

                    //we have to hide only oct1 and oct5 octs so if we have other types we should show them
                    sh.Bool(shb => shb.Must(shbm => shbm
                        .Term(tr => tr.Field("detail_type.lower_case_sort").Value("ac"))
                        .Bool(shbmb => shbmb
                            .MustNot(mn => mn.Terms(tr => tr.Field("status.lower_case_sort").Values(new string[] { "fs0", "ac1", "ac3", "ac4" }))))
                        ));

                    sh.Terms(trs => trs.Field("detail_type.lower_case_sort").Values(new String[] { "participation", "order", "fee_waiver", "op" }));

                    return sh;
                })))))

            .From(start_row_index)
            .Size(page_size)
            .Sort(s => s.Field(sort_by != "date" ? sort_by + ".lower_case_sort" : sort_by, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                        .Field("detail_type.lower_case_sort", PlainElastic.Net.SortDirection.desc));

            return query.BuildBeautified();
        }

        public static string BuildGetPatientDetailsForContractIDQuery(string contract_id)
        {
            var query = new QueryBuilder<PatientDetailViewModel>()
            .Size(int.MaxValue)
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Match(m => m
                        .Field("case_id")
                        .Query(contract_id))
                          .Match(m => m.Field("detail_type").Query("participation"))))).BuildBeautified();
            return query;
        }

        public static string BuildGetPatientDetailsListForDetailTypeAndPatientID(string detail_type, string patient_id)
        {
            var query = new QueryBuilder<PatientDetailViewModel>()
            .Size(int.MaxValue)
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Match(m => m
                        .Field("patient_id")
                        .Query(patient_id))
                          .Match(m => m.Field("detail_type").Query(detail_type))))).BuildBeautified();
            return query;
        }

        public static string BuildGetPatientDetailsQueryTenant(int start_row_index, int page_size, string sort_by, bool isAsc, string patient_id, string sort_by_second_key)
        {
            var statuses_to_omit = new List<string>() { "fs0", "op1", "ac1", "oct1", "mo0", "mo4", "mo6", "mo7", "mo8", "mo9" };

            var query = new QueryBuilder<PatientDetailViewModel>()
            .Query(q => q.Bool(b => b
                .MustNot(mn => mn.Terms(t => t.Field("status.lower_case_sort").Values(statuses_to_omit)))
                .Must(mu => mu
                    .Match(m => m
                        .Field("patient_id")
                        .Query(patient_id)))))
             .From(start_row_index)
                .Size(page_size)
                    .Sort(s => s
                        .Field(sort_by != "date" ? sort_by + ".lower_case_sort" : sort_by, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                         .Field(sort_by != "date" ? sort_by + ".lower_case_sort" : sort_by, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                               );
            return query.BuildBeautified();
        }

        public static string BuildGetPatientsSearchAsYouTypeQuery(ElasticParameterObject parameter, string sort_by, string practice_id, string sort_by_second_key, string sort_by_third_key, string hip_name = null, IEnumerable<string> patient_ids_with_invalid_consent = null)
        {
            var ordinals = new List<string>() { 
                "name",
                "insurance_id",
                "health_insurance_provider",
                "birthday_string",
                "external_id"
            };

            var query = new QueryBuilder<Patient_Model>()
               .Query(q =>
               {
                   q.Filtered(f =>
                   {
                       if (parameter.this_practice)
                       {
                           f.Filter(r => r.Missing(m => m.Field("originating_practice_id")));
                       }
                       else if (parameter.different_practice)
                       {
                           f.Filter(r => r.Exists(m => m.Field("originating_practice_id").ShouldExists(true)));
                       }

                       f.Query(q1 => q1.Bool(b => b
                          .Must(m => m.Term(tr => tr.Field("has_rejected_oct").Value(parameter.show_only_with_rejected_octs ? "true" : null))
                                      .Term(tr => tr.Field("practice_id").Value(practice_id))
                                      .Terms(tr => tr.Field("id").Values(patient_ids_with_invalid_consent))
                                      .Term(tr => tr.Field("health_insurance_provider.lower_case_sort").Value(hip_name)))
                          .Should(sh =>
                          {
                              ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(parameter.search_params).Operator(PlainElastic.Net.Operator.AND)));
                              return sh;
                          }).MinimumNumberShouldMatch(1)));

                       return f;
                   });

                   return q;
               }).Sort(s => s
                                .Field(sort_by + ".lower_case_sort", parameter.isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key == "birthday" ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", parameter.isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_third_key == "birthday" ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", parameter.isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                           ).From(parameter.start_row_index)
                   .Size(parameter.page_size);

            return query.BuildBeautified();
        }

        public static string BuildGetPatientsSearchAsYouTypeQueryTenant(int start_row_index, int page_size, string sort_by, bool isAsc, string search_params, string sort_by_second_key, string sort_by_third_key)
        {
            var ordinals = new List<string>() { 
                "name",
                "insurance_id",
                "health_insurance_provider",
                "birthday_string",
                "insurance_status",
                "last_first_op_doctor_name",
                "last_first_ac_doctor_name",
                "practice",
                "practice_bsnr",
                "ac_practice",
                "ac_practice_bsnr",
                "ac_doctor_lanr",
                "op_doctor_lanr"
            };

            var query = new QueryBuilder<Patient_Model>()
               .Query(q => q
                .Filtered(f => f.Filter(r => r.Missing(m => m.Field("originating_practice_id")))
                .Query(q1 => q1
                   .Bool(b => b
                       .Should(sh =>
                       {
                           ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(PlainElastic.Net.Operator.AND)));
                           return sh;
                       }).MinimumNumberShouldMatch(1))
               )))
               .Sort(s => s
                                .Field(sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key == "birthday" ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_third_key == "birthday" ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                           ).From(start_row_index)
                   .Size(page_size);
            return query.BuildBeautified();
        }

        public static string BuildGetPatientQuery(string id)
        {
            var query = new QueryBuilder<Patient_Model>()
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Match(m => m
                         .Field("id")
                        .Query(id)))));
            return query.BuildBeautified();
        }
        /// <summary>
        /// Elastic query string for retrieving patient detail case for its ID.
        /// <para>Detail case can be an order, case or participation consent.</para>
        /// <para>Elastic type is patient_details.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string BuildGetPatientDetailQuery(string id)
        {
            var query = new QueryBuilder<PatientDetailViewModel>()
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Match(m => m
                         .Field("id")
                        .Query(id)))));
            return query.BuildBeautified();
        }

        /// <summary>
        /// Query string which gets active participation consent from elastic. 
        /// <para>Elastic type is patient_details</para>
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string BuildGetPatientDetailQuery_ByParticipationStatus(string patient_id, string status)
        {
            var query = new QueryBuilder<PatientDetailViewModel>()
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Match(m => m
                         .Field("status.lower_case_sort")
                        .Query(status))
                        )
                .Must(m1 => m1.Match(h => h.Field("patient_id").Query(patient_id)))
                        ));
            return query.BuildBeautified();
        }

        public static string BuildGetPatientDetailQueryAndOrderID(string orderID)
        {
            var query = new QueryBuilder<PatientDetailViewModel>()
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                       .Match(m => m
                         .Field("order_id")
                        .Query(orderID))

                        )));
            return query.BuildBeautified();
        }

        public static string BuildGetPatientsWhereIDPresentQuery(string id, string ordinal)
        {
            return new QueryBuilder<Patient_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)))))
                    .BuildBeautified();
        }

        public static string BuildGetPatientsWhereFieldsPresentQuery(List<KeyValuePair<string, string>> parameters)
        {
            return new QueryBuilder<Patient_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m =>
                {
                    parameters.ForEach(p => m.Term(t => t.Field(p.Key).Value(p.Value))); return m;
                }))).BuildBeautified();
        }

        public static string BuildGetPatientDetailsWhereIDPresentQuery(string id, string ordinal)
        {
            return new QueryBuilder<PatientDetailViewModel>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id))).Should(sh => sh
                    .Terms(ts => ts.Field("status.lower_case_sort").Values(new string[] { "ac1", "ac3", "fs0", "mo1", "mo2", "fs6" }))).MinimumNumberShouldMatch(1)))
                        .BuildBeautified();
        }

        public static string BuildGetPatientDetailsForIdAndOrdinal(string id, string ordinal)
        {
            return new QueryBuilder<PatientDetailViewModel>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)))))
                    .BuildBeautified();
        }

        public static string BuildGetPatientDetailsWhereFieldsHaveValuesQuery(List<FieldValueParameter> parameters, string practice_id)
        {
            var negationList = new List<FieldValueParameter>();
            var nonNegationList = new List<FieldValueParameter>();

            foreach (var parameter in parameters)
            {
                if (parameter.Negation)
                {
                    negationList.Add(parameter);
                }
                else
                {
                    nonNegationList.Add(parameter);
                }
            }

            var query = new QueryBuilder<PatientDetailViewModel>()
                .Size(Int32.MaxValue)
                .Query(q => q
                    .Bool(b => b
                        .Must(m =>
                        {
                            nonNegationList.ForEach(param => m.Term(term => term.Field(param.FieldName).Value(param.FieldValue.ToLower())));
                            m.Term(t => t.Field("practice_id").Value(practice_id));

                            return m;
                        })
                        .MustNot(m =>
                        {
                            negationList.ForEach(param => m.Term(t => t.Field(param.FieldName).Value(param.FieldValue.ToLower())));
                            return m;
                        })
                    )
                ).BuildBeautified();

            return query;
        }
    }
}
