using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Archive.Retrieval
{
    public static class QueryBuilderArchive
    {
        public static string BuildGetArchiveQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string sort_by_second_key, string sort_by_third_key)
        {

            var query = new QueryBuilder<Archive_Model>()
           .From(start_row_index)
               .Size(page_size).
                     Sort(s => s
                        .Field(sort_by.Equals("creationtimestamp") ? sort_by : sort_by += ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                 .Field(sort_by_second_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                     .Field(sort_by_third_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc));

            return query.BuildBeautified();

        }
        public static string BuildGetArchiveSearchAsYouTypeQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string search_params, Filter filter_by, string sort_by_second_key, string sort_by_third_key, string date_from, string date_to)
        {
            var query = new QueryBuilder<Archive_Model>();
            if (filter_by.filter_type.Length != 0)
            {
                query.From(start_row_index)
                 .Size(page_size)
                   .Query(q => q
                               .Bool(b => b
                                   .Should(sh => sh
                                       .Match(m => m
                                           .Field("description")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                            .Match(m => m
                                           .Field("recipient")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                          )
                                           .Match(m => m
                                           .Field("filetype")
                                           .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                           )
                                           .Term(t => t.Field(f => f.filetype).Value(filter_by.filter_type.First())
                                           )
                                            .Terms(tr => tr.Field("description.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1)))
                                           .MinimumNumberShouldMatch(1)
                                           ))
                                       .Filter(flt => flt.Range(dt => dt.Field(f => f.filedate).Lte(string.IsNullOrEmpty(date_to) ? "" : date_to + "T00:00:00").Gte(string.IsNullOrEmpty(date_from) ? "" : date_from + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))

                                      .Sort(s => s
                                      .Field(sort_by == "filedate" || sort_by == "creationtimestamp" ? sort_by : sort_by += ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                 .Field(sort_by_second_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                     .Field(sort_by_third_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                                 .Field("creationtimestamp", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                               );
            }

            else
            {
                query.From(start_row_index)
                .Size(page_size)
                 .Query(q => q
                   .Bool(b => b
                       .Should(sh => sh
                           .Match(m => m
                               .Field("description")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                               )
                                .Match(m => m
                                .Field("recipient")
                                .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                  )
                               .Match(m => m
                               .Field("filetype")
                               .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                               )
                               .Terms(tr => tr.Field("description.lower_case_sort").Values(filter_by.filter_status).MinimumMatch(1)).Terms(tr => tr.Field("recipient.lower_case_sort").Values(filter_by.filter_status)).Terms(tr => tr.Field("filetype.lower_case_sort").Values(filter_by.filter_status))
                               )
                               .MinimumNumberShouldMatch(1)
                               ))
                          .Filter(flt => flt.Range(dt => dt.Field(f => f.filedate).Lte(string.IsNullOrEmpty(date_to) ? "" : date_to + "T00:00:00").Gte(string.IsNullOrEmpty(date_from) ? "" : date_from + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                          .Sort(s => s
                          .Field(sort_by == "filedate" || sort_by == "creationtimestamp" ? sort_by : sort_by += ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                 .Field(sort_by_second_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                     .Field(sort_by_third_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                     .Field("creationtimestamp", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                   );
            }
            return query.BuildBeautified();
        }
        public static string BuildGetArchiveSearchAsYouTypeQueryWithParam(int start_row_index, int page_size, string sort_by, bool isAsc, string search_params, Filter filter_by, string sort_by_second_key, string sort_by_third_key, string date_from, string date_to)
        {
            var query = new QueryBuilder<Archive_Model>();

            query.From(start_row_index)
             .Size(page_size)
               .Query(q => q
                           .Bool(b => b
                               .Should(sh => sh
                                   .Match(m => m
                                       .Field("description")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                       .Match(m => m
                                       .Field("recipient")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                       .Match(m => m
                                       .Field("filetype")
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      ))
                                       .MinimumNumberShouldMatch(1)
                                       ))
                                     .Filter(flt => flt.Range(dt => dt.Field(f => f.filedate).Lte(string.IsNullOrEmpty(date_to) ? "" : date_to + "T00:00:00").Gte(string.IsNullOrEmpty(date_from) ? "" : date_from + "T00:00:00+" + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString().Substring(0, 2))))
                                  .Sort(s => s
                                  .Field(sort_by == "filedate" || sort_by  == "creationtimestamp" ? sort_by : sort_by += ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                 .Field(sort_by_second_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                     .Field(sort_by_third_key, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                             .Field("creationtimestamp", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                           );


            return query.BuildBeautified();
        }
    }
}
