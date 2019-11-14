using DataImporter.Models;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Receipt.Retrieval
{
    public static class QueryBuilderReceipts
    {

        public static string BuildGetReceiptsQuery()
        {
            var query = new QueryBuilder<Receipt_Model>();

            query.From(0)
             .Size(int.MaxValue);            

            return query.BuildBeautified();

        }
    }
}
