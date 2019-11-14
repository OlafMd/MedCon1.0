﻿using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.HIP.Retrieval
{
    public static class QueryBuilderHIP
    {
        public static string BuildGetHIPQuerySearchAsYouTupe(string search_params)
        {
            var query = new QueryBuilder<HIP_Model>();
            search_params = search_params.ToLower();
            query.From(0)
                .Size(int.MaxValue)
                .Query(q => q
                    .Bool(b => b
                    .Should(sh => sh
                    .Match(m => m
                        .Field(f => f.ik_number)
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND))
                    .Match(m => m
                        .Field(f => f.name)
                        .Query(search_params).Operator(PlainElastic.Net.Operator.AND)))
                        .MinimumNumberShouldMatch(1)))
                .Sort(s => s.Field("name.lower_case_sort", PlainElastic.Net.SortDirection.asc));

            return query.BuildBeautified();
        }
    }
}
