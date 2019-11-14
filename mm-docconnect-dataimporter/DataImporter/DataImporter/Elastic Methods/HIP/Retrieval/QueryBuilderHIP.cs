using DataImporter.Models;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_Methods.HIP.Retrieval
{
    public static class QueryBuilderHIP
    {
        public static string BuildGetHIPQuerySearchAsYouTupe(string search_params)
        {
            var query = new QueryBuilder<HIP_Model>();
            query.From(0)
                .Size(int.MaxValue);

            return query.BuildBeautified();
        }
    }
}
