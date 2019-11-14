using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Doctor.Retrieval
{
    public static class QueryBuilderDoctors
    {
        public static string BuildGetDoctorsQuery(int start_row_index, int page_size, string sort_by, bool isAsc)
        {
            var query = new QueryBuilder<Practice_Doctors_Model>()
                   .From(start_row_index)
                      .Size(100)
                          .Sort(s => s
                              .Field(sort_by, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                              .Field("name_untouched", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                              );

            return query.BuildBeautified();

        }

        public static string BuildGetDoctorsForIDArrayQuery(string[] ids)
        {
            var query = new QueryBuilder<Practice_Doctors_Model>()
                   .From(0)
                      .Size(int.MaxValue)
                      .Query(q => q.Bool(b => b.Must(m => m.Term(t => t.Field("type").Value("doctor")).Terms(t => t.Field("id").Values(ids)))));

            return query.BuildBeautified();

        }

        public static string BuildGetDoctorsQuerySearch(string search_params)
        {
            var query = new QueryBuilder<Practice_Doctors_Model>()
                   .From(0)
                      .Size(int.MaxValue)
                        .Query(q => q
                           .Bool(b => b.Must(m => m.Term(t => t.Field("type").Value("doctor")).Term(t => t.Field("account_status").Value("aktiv")))
                               .Should(sh => sh
                                   .Match(m => m
                                       .Field(fs => fs.type)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                       .Match(m => m
                                       .Field(fs => fs.bsnr_lanr)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field(fs => fs.address)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field(fs => fs.name)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                       .Match(m => m
                                       .Field(fs => fs.city)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )).MinimumNumberShouldMatch(1)))
                          .Sort(s => s.Field("name_untouched", PlainElastic.Net.SortDirection.asc));

            return query.BuildBeautified();

        }
        public static string BuildGetDoctorsQueryFilter(int start_row_index, int page_size, string sort_by, bool isAsc, string search_params, Filter filter_by)
        {
            var query = new QueryBuilder<Practice_Doctors_Model>();

            query.From(start_row_index)
                          .Size(100)
                            .Query(q => q
                                .Bool(b => b
                                 .Should(sh => sh
                                   .Match(m => m
                                       .Field(fs => fs.type)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                       .Match(m => m
                                       .Field(fs => fs.bsnr_lanr)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field(fs => fs.address)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field(fs => fs.name)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                       .Match(m => m
                                       .Field(fs => fs.city)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      ))
                                           .MinimumNumberShouldMatch(1)
                                                .Must(must => must.Terms(t => t.Field(f1 => f1.type).Values(filter_by.filter_type).MinimumMatch(1)).Terms(t1 => t1.Field(f => f.account_status).Values(filter_by.filter_status).MinimumMatch(1)))
                                           ))

                              .Sort(s => s
                                  .Field(sort_by, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  .Field("name_untouched", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                  );

            return query.BuildBeautified();

        }

        public static string BuildGetDoctorsQuerySearch(string search_params, IEnumerable<String> potential_doctors)
        {
            var query = new QueryBuilder<Practice_Doctors_Model>()
                   .From(0)
                      .Size(int.MaxValue)
                        .Query(q => q
                           .Bool(b => b.Must(m => m
                               .Term(t => t.Field("type").Value("doctor"))
                               .Term(t => t.Field("account_status").Value("aktiv"))
                               .Terms(t=>t.Field(f=>f.id).Values(potential_doctors))
                               )
                               .Should(sh => sh
                                   .Match(m => m
                                       .Field(fs => fs.type)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                       )
                                       .Match(m => m
                                       .Field(fs => fs.bsnr_lanr)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field(fs => fs.address)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                        .Match(m => m
                                       .Field(fs => fs.name)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )
                                       .Match(m => m
                                       .Field(fs => fs.city)
                                       .Query(search_params).Operator(PlainElastic.Net.Operator.AND)
                                      )).MinimumNumberShouldMatch(1)))
                          .Sort(s => s.Field("name_untouched", PlainElastic.Net.SortDirection.asc));

            return query.BuildBeautified();

        }
    }

}
