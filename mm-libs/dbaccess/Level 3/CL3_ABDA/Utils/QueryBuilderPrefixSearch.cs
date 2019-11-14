using PlainElastic.Net.Queries;
using BOp.CatalogAPI.data;
using CL3_ABDA.Atomic.Retrieval;

namespace CL3_ABDA.Utils
{
    class QueryBuilderPrefixSearch
    {
        private string ProductName{ get; set; }
        private string ActiveSubstance { get; set; }
        private string Producer { get; set; }
        protected string Query { get; set; }

        public QueryBuilderPrefixSearch(P_L3ABDA_GAAPfSC_1547 parameter)
        {
            ProductName = parameter.ProductName;
            ActiveSubstance = parameter.ActiveSubstance;
            Producer = parameter.Producer;
        }

        public string GetQuery()
        {
            GetPrefixSearchQuery();

            return Query;
        }

        private void GetPrefixSearchQuery()
        {
            Query = new QueryBuilder<Product>()
            .Query(q => q
                .Bool(b => b
                    .Must(s => s
                        .Match(m => m
                            .Field(SearchCondition.GetFiledName(ProductField.NAME))
                            .Query(ProductName)
                            .Operator(PlainElastic.Net.Operator.AND)
                            .Fuzziness(4.0)
                        )
                    )
                    .Must(s => s
                        .Match(m => m
                            .Field(SearchCondition.GetFiledName(ProductField.SUBSTANCE))
                            .Query(ActiveSubstance)
                            .Operator(PlainElastic.Net.Operator.AND)
                            .Fuzziness(4.0)
                        )
                    )
                    .Must(s => s
                        .Match(m => m
                            .Field(SearchCondition.GetFiledName(ProductField.PRODUCER))
                            .Query(Producer)
                            .Operator(PlainElastic.Net.Operator.AND)
                            .Fuzziness(4.0)
                        )
                    )
                )
            ).BuildBeautified();
        }

    }
}
