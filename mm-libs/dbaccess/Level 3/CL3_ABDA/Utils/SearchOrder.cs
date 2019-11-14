namespace CL3_ABDA.Utils
{

    public enum SortingOrder { ASC, DESC }

    public class SearchOrder
    {
        public ProductField field { get; set; }
        public SortingOrder order { get; set; }
    }
}
