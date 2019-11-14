using MMDocConnectElasticSearchMethods.Models;
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

        public static string BuildGetReceiptsQuery(int start_row_index, int page_size, string sort_by, bool isAsc, string doctor_id)
        {
            var query = new QueryBuilder<Receipt_Model>();
            if (sort_by == "filedate" || sort_by == "amountNo")
            {
                query.From(start_row_index)
                 .Size(page_size).
                              Query(q => q
                          .Bool(b => b.Must(m => m.Term(tr4 => tr4.Field(id => id.doctorID).Value(doctor_id)))))
                          .Sort(s => s
                              .Field(sort_by, isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                                     );
            }
            else
            {
                query.From(start_row_index)
                .Size(page_size).
                             Query(q => q
                         .Bool(b => b.Must(m => m.Term(tr4 => tr4.Field(id => id.doctorID).Value(doctor_id)))))
                         .Sort(s => s
                             .Field(sort_by + ".lower_case_sort", isAsc ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc)
                               .Field("filedate", PlainElastic.Net.SortDirection.desc)
                                    );
            }
            return query.BuildBeautified();

        }

        public static string BuildGetNonViewedReceiptsQuery(string doctor_id)
        {
            return new QueryBuilder<Receipt_Model>()
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Term(t => t.Field(f => f.doctorID).Value(doctor_id)).Term(t => t.Field(f => f.isViewed).Value("false"))))).BuildBeautified();
        }
    }
}
