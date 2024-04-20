
namespace StoreService.Application.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            if (str == null)
                return true;
            return str.Trim().Length == 0;
        }
    }
}