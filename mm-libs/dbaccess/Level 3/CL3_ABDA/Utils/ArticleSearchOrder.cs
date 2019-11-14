namespace CL3_ABDA.Utils
{
    public enum ArticleSortingOrder { ASC, DESC }

    public class ArticleSearchOrder
    {
        public ProductField field { get; set; }
        public SortingOrder order { get; set; }
    }
}
