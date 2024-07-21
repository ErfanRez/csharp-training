using System.Text.RegularExpressions;

namespace CoreLayer.Utilities
{
    public static class TextHelper
    {
        public static string ToSlug(this string value)
        {
            // Trim and convert to lowercase
            string purified = value.Trim().ToLower();

            // Replace spaces with hyphens
            purified = Regex.Replace(purified, @"\s+", "-");

            // Remove all non-alphanumeric characters except hyphens
            string result = Regex.Replace(purified, @"[^a-z0-9-]", "");

            // Trim hyphens from the start and end of the result
            result = result.Trim('-');

            return result;
        }
    }
}
