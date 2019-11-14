namespace Core_ClassLibrarySupport.Utils
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string reciver, string term)
        {
            if (reciver == null || term == null)
            {
                return false;
            }
            return reciver.ToLower().Contains(term.ToLower());

        }
    }
}