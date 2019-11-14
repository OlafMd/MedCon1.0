using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Settlement.Retrieval
{
    public static class QueryBuilderSettlement
    {

        public static string BuildGetSettlementQuery(int start_row_index, int page_size, string sort_by, string search_params, bool isAsc, string practice_id, string sort_by_second_key,
            string sort_by_third_key, string sort_by_fourth_key, Filter filter_by, IEnumerable<string> deselected_ids = null, List<AftercareHipParameter> rangeParameters = null, string hip_name = null)
        {
            var ordinals = new List<string>()
            {
                "patient_full_name",
                "doctor",
                "birthday.lower_case_sort",
                "hip",
                "patient_insurance_number",
                "lanr",
                "bsnr"
            };

            var query = new QueryBuilder<Settlement_Model>()
                .Query(q => q.Bool(b => b
                    .Should(sh =>
                    {
                        ordinals.ForEach(ord => sh.Match(m => m.Field(ord).Query(search_params).Operator(PlainElastic.Net.Operator.AND)));
                        return sh;
                    }).MinimumNumberShouldMatch(1)
                    .Must(must =>
                    {
                        must.Terms(t => t.Field("case_type").Values(filter_by.filter_type).MinimumMatch(1))
                            .Terms(t1 => t1.Field("status.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1))
                            .Term(t1 => t1.Field("hip.lower_case_sort").Value(!String.IsNullOrEmpty(hip_name) ? hip_name.ToLower() : null))
                            .Term(term => term.Field(id => id.practice_id).Value(practice_id));

                        if (rangeParameters != null && rangeParameters.Any())
                        {
                            must.Bool(bl => bl.Should(sh =>
                            {
                                rangeParameters.ForEach(r => sh.Bool(shb => shb
                                    .Must(shm => shm.Range(rng => rng.Field("surgery_date").Lt(r.MinimumTreatmentDate))
                                                    .Term(tr => tr.Field("hip_ik_number").Value(r.HipIk))
                                                    .Term(tr => tr.Field("case_type").Value("op"))
                                                    .Terms(tr => tr.Field("ac_status").Values(new string[] { "ac1", "fs8" })))
                                    .MustNot(shmn => shmn.Term(t => t.Field("status.lower_case_sort").Value("fs13")))
                                ));

                                return sh;
                            }));
                        }

                        return must;
                    })
                    .MustNot(mn => mn.Terms(t => t.Field("id").Values(deselected_ids)))
                ));

            query = query.Size(page_size != 0 ? page_size : int.MaxValue).From(start_row_index);

            if (!String.IsNullOrEmpty(sort_by))
            {
                query = query.Sort(s => s
                      .Field(sort_by, isAsc ? SortDirection.asc : SortDirection.desc)
                      .Field(sort_by_second_key, isAsc ? SortDirection.asc : SortDirection.desc)
                      .Field(sort_by_third_key, isAsc ? SortDirection.asc : SortDirection.desc)
                      .Field(sort_by_fourth_key, isAsc ? SortDirection.asc : SortDirection.desc)
                );
            }

            return query.BuildBeautified();
        }

        public static string BuildGetSettlementInErrorCorrectionAndWhereIDPresentQuery(string id, string ordinal, string case_type)
        {
            return new QueryBuilder<Settlement_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field(ordinal).Value(id)).Term(t => t.Field("case_type").Value(case_type))
                        .Term(t => t.Field("status.lower_case_sort").Value("fs6"))))).BuildBeautified();
        }

        public static string BuildGetSettlementWhereStatus(string patient_id, string localization, string status_code, string case_type)
        {
            var query = new QueryBuilder<Settlement_Model>().Size(int.MaxValue).From(0)
                .Query(q => q.Bool(b => b.Must(m => m
                    .Term(t => t.Field("patient_id").Value(patient_id))
                    .Term(t => t.Field("localization").Value(localization))
                    .Term(t => t.Field("status.lower_case_sort").Value(status_code))
                    .Term(t => t.Field("case_type").Value(case_type)))))
                .BuildBeautified();

            return query;
        }

        public static string BuildGetNumberOfFSCasesInDoctorsPractice(string practice_id, string status)
        {
            return new QueryBuilder<Settlement_Model>()
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Term(t => t.Field("status.lower_case_sort").Value(status))
                                .Term(t => t.Field("practice_id").Value(practice_id))))).BuildBeautified();
        }

        public static string BuildGetSettlementsForIDArray(Guid practice_id, string[] case_ids)
        {
            var query = new QueryBuilder<Case_Model>().Size(int.MaxValue)
                .Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m
                    .Term(term => term.Field(id => id.practice_id).Value(practice_id.ToString()))
                    .Terms(t => t.Field("id").Values(case_ids)))))));


            return query.BuildBeautified();
        }

        public static string BuildGetSettlementEligibleForSubmissionReport(Guid practice_id, string[] case_ids = null)
        {
            var query = new QueryBuilder<Case_Model>().Size(int.MaxValue)
                .Query(q => q.Filtered(f => f.Filter(flt => flt.Bool(b => b.Must(m => m
                    .Terms(t => t.Field("id").Values(case_ids))
                    .Term(term => term.Field(id => id.practice_id).Value(practice_id.ToString())))
                    .MustNot(m => m.Terms(t => t.Field("status.lower_case_sort").Values(new string[] { "fs8", "fs6" })))))));


            return query.BuildBeautified();
        }
        public static string BuildGetAllSettlementsWithNonDownloadedSubmissionReport(Guid practice_id, string doctorId = null)
        {
            var query = new QueryBuilder<Settlement_Model>().Size(int.MaxValue)
                .Query(q => q.Filtered(f =>
                    f.Filter(flt => flt.Bool(b =>
                        b.Must(m => m
                            .Bool(shouldBool =>
                                shouldBool.Should(sh => sh
                                    .Bool(bl => bl.Must(mb => mb.Term(tr => tr.Field(ff => ff.treatment_doctor_id).Value(doctorId))
                                        .Term(tc => tc.Field(fc => fc.case_type).Value("op"))))
                                    .Bool(bl2 => bl2.Must(mb2 => mb2.Term(trm => trm.Field(ff => ff.aftercare_doctor_practice_id).Value(doctorId))
                                        .Term(tc => tc.Field(fc => fc.case_type).Value("ac"))))
                                    .Bool(bl => bl.Must(mb => mb.Term(tr => tr.Field(ff => ff.treatment_doctor_id).Value(doctorId))
                                        .Term(tc => tc.Field(fc => fc.case_type).Value("oct"))))))
                    .Term(t => t.Field("is_report_downloaded").Value("false"))
                    .Term(term => term.Field(id => id.practice_id).Value(practice_id.ToString())))
                    .MustNot(m => m.Terms(t => t.Field("status.lower_case_sort").Values(new string[] { "fs8", "fs6" }))))
                    )));

            return query.BuildBeautified();
        }
    }
}
