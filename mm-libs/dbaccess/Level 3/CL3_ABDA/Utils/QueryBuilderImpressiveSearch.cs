using PlainElastic.Net.Queries;
using BOp.CatalogAPI.data;

namespace CL3_ABDA.Utils
{
    class QueryBuilderImpressiveSearch
    {
        private string Pzn { get; set; }
        private string SearchQuery { get; set; }
        protected string Query { get; set; }
        private bool isSecondQueryNeeded { get; set; }

        public QueryBuilderImpressiveSearch(string pzn, string searchQuery)
        {
            this.isSecondQueryNeeded = false;
            Pzn = (string.IsNullOrWhiteSpace(pzn)) ? null : pzn.Trim().ToLower();
            SearchQuery = (string.IsNullOrWhiteSpace(searchQuery)) ? null : searchQuery.Trim().ToLower();
        }

        public string GetQuery()
        {

            if (Pzn != null)
            {
                if (Pzn == SearchQuery)
                    SetQueryJustByPZN();
                else
                    SetQueryWithPZN();
            }
            else
            {
                this.isSecondQueryNeeded = true;
                SetQueryByProducerNameOrSubstance();
            }

            return Query;
        }

        public string GetSecoundQuery(Product product)
        {
            if (product == null)
                return "";

            SetSecoundQuery(product);

            return Query;
        }

        public bool IsSecondQueryNeeded()
        {
            return this.isSecondQueryNeeded;
        }

        private void SetQueryJustByPZN()
        {
            Query = new QueryBuilder<Product>()
            .Query(q => q
               .Match(m => m
                   .Field(SearchCondition.GetFiledName(ProductField.CODE))
                   .Query(Pzn)
                   .Fuzziness(1.0)
                )
             ).BuildBeautified();
        }

        private void SetQueryWithPZN()
        {
            string[] fields = {
                SearchCondition.GetFiledName(ProductField.NAME), 
                SearchCondition.GetFiledName(ProductField.SUBSTANCE),
                SearchCondition.GetFiledName(ProductField.PRODUCER)
            };

            string searchQuery = SearchQuery.Replace(Pzn, "");
            Query = new QueryBuilder<Product>()
            .Query(q => q
                .Bool(b => b
                    .Should(sh => sh
                        .MultiMatch(mm => mm
                            .Query(searchQuery)
                            .Fuzziness(1.5)
                            .Fields(fields)
                            .Operator(PlainElastic.Net.Operator.OR)
                         )
                     )
                     .Should(s => s
                        .Match(m => m
                            .Field(SearchCondition.GetFiledName(ProductField.CODE))
                            .Query(Pzn)
                            .Boost(2.0)
                         )
                      )
                 )
            ).BuildBeautified();
        }

        private void SetQueryByProducerNameOrSubstance()
        {
            string[] fields = {
                SearchCondition.GetFiledName(ProductField.NAME), 
                SearchCondition.GetFiledName(ProductField.SUBSTANCE) + "^2"
            };

            Query = new QueryBuilder<Product>()
            .Query(q => q
                .Bool(b => b
                    .Should(sh => sh
                        .MultiMatch(mm => mm
                            .Query(SearchQuery)
                            .Fuzziness(1.5)
                            .Fields(fields)
                            .Operator(PlainElastic.Net.Operator.OR)
                         )
                     )
                     .Should(s => s
                        .Match(m => m
                            .Field(SearchCondition.GetFiledName(ProductField.PRODUCER))
                            .Query(SearchQuery)
                            .Boost(2.0)
                         )
                      )
                 )
            ).BuildBeautified();
        }

        private bool PrepareSecoundQuery(string producer)
        {
            string[] producerWords = producer.Split(' ');

            foreach (var word in producerWords)
            {
                if (SearchQuery.Contains(word))
                {
                    SearchQuery = SearchQuery.Replace(word, "");
                    return true;
                }
            }

            return false;
        }

        private void SetSecoundQuery(Product product)
        {
            string producer = (string.IsNullOrWhiteSpace(product.Producer)) ? null : product.Producer.Trim().ToLower();
            bool proceed = PrepareSecoundQuery(producer);

            if (proceed)
            {
                string[] fields = {
                    SearchCondition.GetFiledName(ProductField.NAME), 
                    SearchCondition.GetFiledName(ProductField.SUBSTANCE)
                };

                Query = new QueryBuilder<Product>()
                .Query(q => q
                    .Bool(b => b
                        .Should(sh => sh
                            .MultiMatch(mm => mm
                                .Query(SearchQuery)
                                .Fuzziness(1.5)
                                .Fields(fields)
                                .Operator(PlainElastic.Net.Operator.AND)
                             )
                         )
                         .Must(s => s
                            .Match(m => m
                                .Field(SearchCondition.GetFiledName(ProductField.PRODUCER))
                                .Query(producer)
                             )
                          )
                     )
                ).BuildBeautified();
            }
            else
            {
                Query = string.Empty;
            }
        }
    }
}
