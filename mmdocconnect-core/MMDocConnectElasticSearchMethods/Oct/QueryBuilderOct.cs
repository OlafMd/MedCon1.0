using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Oct.Entity;
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
    public static class QueryBuilderOct
    {
        public static string BuildGetOctsQuery(int start_row_index, int page_size, string sort_by, string hip_name, string search_params, bool isAsc, string practice_id, string sort_by_second_key,
            string sort_by_third_key, Filter filter_by, List<OctHipParameter> rangeParameters, IEnumerable<string> deselected_ids = null, bool omit_withdrawn = false)
        {
            var ordinals = new List<string>()
            {
                "patient_name",
                "patient_hip",
                "patient_insurance_number",
                "treatment_doctor_name",
                "treatment_doctor_lanr",
                "oct_doctor_lanr",
                "treatment_doctor_practice_bsnr",
                "oct_doctor_name",
            };

            var filtered_by_status = filter_by.filter_status.Any();
            if (!filtered_by_status && filter_by.filter_current)
            {
                filter_by.filter_status = new string[] { "oct1", "oct3" };
            }

            var include_overdue = filter_by != null && filter_by.filter_status.Any(t => t == "oct3");
            var include_open = filter_by != null && filter_by.filter_status.Any(t => t == "oct1");
            var include_withdrawn = filter_by != null && filter_by.filter_status.Any(t => t == "oct4");
            var include_pending = filter_by != null && filter_by.filter_status.Any(t => t == "oct6");
            var include_exceeded = filter_by != null && filter_by.filter_status.Any(t => t == "oct5");

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
                        must.Bool(bl => bl.Should(sh =>
                        {
                            if (include_open)
                            {
                                sh.Bool(shb => shb
                                    .Must(shm => shm.Term(t => t.Field("status.lower_case_sort").Value("oct1")))
                                    .Must(shm => shm
                                        .Bool(shmb => shmb.Should(shmbs =>
                                        {
                                            rangeParameters.ForEach(r => shmbs.Bool(shmbsb => shmbsb.Must(shmbsbm => shmbsbm
                                                .Term(tr => tr.Field("hip_ik").Value(r.HipIk))
                                                .Range(rng => rng.Field("treatment_date").Gte(r.OverdueDate))
                                                .Range(rng => rng.Field("treatment_year_octs").Lt(r.MaxOCTs)))));
                                            return shmbs;
                                        })))
                                    .MinimumNumberShouldMatch(1));
                            }

                            if (include_withdrawn)
                            {
                                sh.Bool(shb => shb.Must(shm => shm.Term(t => t.Field("status.lower_case_sort").Value("oct4"))));
                            }

                            if (include_overdue)
                            {
                                sh.Bool(shb => shb
                                    .Must(shm => shm
                                        .Term(t => t.Field("status.lower_case_sort").Value("oct1"))
                                        .Bool(shmb => shmb.Should(shmbs =>
                                        {
                                            rangeParameters.ForEach(r => shmbs.Bool(shmbsb => shmbsb.Must(shmbsbm => shmbsbm
                                                   .Term(tr => tr.Field("hip_ik").Value(r.HipIk))
                                                   .Range(rng => rng.Field("treatment_date").Gte(r.MinimumTreatmentDate == "0001-01-01" ? null : r.MinimumTreatmentDate))
                                                   .Range(rng => rng.Field("treatment_date").Lte(r.OverdueDate == "0001-01-01" ? null : r.OverdueDate)))));
                                            return shmbs;
                                        }))
                                    ));
                            }

                            if (include_exceeded)
                            {
                                sh.Bool(shb => shb
                                    .Must(shm => shm
                                        
                                        .Bool(shmb => shmb.Should(shmbs =>
                                        {
                                            rangeParameters.ForEach(r => shmbs.Bool(shmbsb => shmbsb.Must(shmbsbm => shmbsbm
                                                .Term(tr => tr.Field("hip_ik").Value(r.HipIk))
                                                .Range(rng => rng.Field("treatment_year_date").Gte(r.OverdueDate == "0001-01-01" ? null : r.OverdueDate))
                                                .Term(t => t.Field("treatment_year_octs").Value(r.MaxOCTs)))));
                                            return shmbs;
                                        })))
                                    .MustNot(shmn => shmn
                                        .Term(t => t.Field("status.lower_case_sort").Value("oct4"))));
                            }

                            if (include_pending)
                            {
                                sh.Bool(shb => shb.
                                    Must(m => m.Term(t => t.Field("status.lower_case_sort").Value("oct6"))));
                            }

                            return sh;
                        }));

                        return must;
                    })

                    .MustNot(mn => mn.Terms(t => t.Field("status.lower_case_sort").Values(omit_withdrawn ? new string[] { "oct6", "oct4" } : null))
                                     .Terms(t => t.Field("id").Values(deselected_ids)))
                ))

                .Filter(flt => flt.Bool(b => b.Must(m => m.Bool(bl => bl.Should(sh =>
                {
                    rangeParameters.ForEach(r => sh.Bool(shb => shb.Must(shm => shm
                        .Terms(trs => trs.Field("status.lower_case_sort").Values(new String[] { "oct1", "oct5" }))
                        .Range(rng => rng.Field("treatment_date").Gte(r.MinimumTreatmentDate == "0001-01-01" ? null : r.MinimumTreatmentDate))
                        .Term(tr => tr.Field("hip_ik").Value(r.HipIk)))));

                    sh.Terms(tr => tr.Field("status.lower_case_sort").Values(new string[] { "oct4", "oct6" }));
                    return sh;
                })))));

            if (page_size != 0)
            {
                query = query.Size(page_size).From(start_row_index);
            }

            if (!String.IsNullOrEmpty(sort_by))
            {
                var sort_direction = isAsc ? SortDirection.asc : SortDirection.desc;
                query = query.Sort(s => s
                        .Field(sort_by.Equals("treatment_date") || sort_by.Equals("oct_date") || sort_by.Equals("treatment_year_date") ? sort_by : sort_by + ".lower_case_sort", sort_direction)
                        .Field(sort_by_second_key.Equals("treatment_date") || sort_by_second_key.Equals("patient_birthdate") ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", sort_direction)
                        .Field(sort_by_third_key.Equals("treatment_date") || sort_by_third_key.Equals("patient_birthdate") ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", sort_direction)
                );
            }


            return query.BuildBeautified();
        }

        public static string BuildGetOctsWhereFieldsHaveValuesQuery(List<FieldValueParameter> parameters, string practice_id, FieldValueParameter rangeParameter = null)
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

            var query = new QueryBuilder<Oct_Model>()
                .Size(Int32.MaxValue)
                .Query(q => q
                    .Bool(b => b
                        .Must(m =>
                        {
                            nonNegationList.ForEach(param => m.Term(term => term.Field(param.FieldName).Value(param.FieldValue.ToLower())));
                            m.Term(t => t.Field("practice_id").Value(practice_id));

                            if (rangeParameter != null)
                            {
                                switch (rangeParameter.RangeConfig)
                                {
                                    case "lte":
                                        m.Range(rng => rng.Field(rangeParameter.FieldName).Lte(rangeParameter.FieldValue));
                                        break;
                                    case "lt":
                                        m.Range(rng => rng.Field(rangeParameter.FieldName).Lt(rangeParameter.FieldValue));
                                        break;
                                    case "gte":
                                        m.Range(rng => rng.Field(rangeParameter.FieldName).Gte(rangeParameter.FieldValue));
                                        break;
                                    case "gt":
                                        m.Range(rng => rng.Field(rangeParameter.FieldName).Gt(rangeParameter.FieldValue));
                                        break;
                                    default: break;
                                }
                            }

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
