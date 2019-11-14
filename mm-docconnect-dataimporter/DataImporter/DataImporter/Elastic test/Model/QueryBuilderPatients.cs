using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_test.Model
{
    public static class QueryBuilderPatients
    {
        public static string BuildGetPatientsQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string practice_id, string sort_by_second_key, string sort_by_third_key)
        {
            var query = new QueryBuilder<Patient_Model_xls>()
            .Query(q => q.Bool(b => b
                .Must(mu => mu
                    .Match(m => m
                        .Field(pr => pr.practice_id)
                        .Query(practice_id)))))
             .From(start_row_index)
                .Size(page_size)
                    .Sort(s => s
                        .Field(sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                         .Field(sort_by_second_key == "birthday" ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                          .Field(sort_by_third_key == "birthday" ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                               );
            return query.BuildBeautified();
        }

        public static string BuildGetPatientsSearchAsYouTypeQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string search_params, string practice_id, string sort_by_second_key, string sort_by_third_key)
        {
            var query = new QueryBuilder<Patient_Model_xls>()
               .Query(q => q
                   .Bool(b => b
                       .Should(sh => sh
                           .Match(m => m
                               .Field("name")
                               .Query(search_params)
                               )
                            .Match(m => m
                               .Field("insurance_id")
                               .Query(search_params)
                               )
                            .Match(m => m
                               .Field("health_insurance_provider")
                               .Query(search_params)
                               )
                            .Match(m => m
                               .Field("birthday_string")
                               .Query(search_params)
                               )
                           ).MinimumNumberShouldMatch(1)
                           .Must(ma => ma.Match(m => m.Field("practice_id").Query(practice_id)))
                       )
                   ).Sort(s => s
                                .Field(sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_second_key == "birthday" ? sort_by_second_key : sort_by_second_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                .Field(sort_by_third_key == "birthday" ? sort_by_third_key : sort_by_third_key + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                           ).From(start_row_index)
                   .Size(page_size);
            return query.BuildBeautified();
        }
    }
}
