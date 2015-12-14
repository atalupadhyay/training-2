using System;
using System.Text;

namespace Komsky.Helpers
{
    public static class Utils
    {
        public static string ToBase64Encode(this string plainText)
        {
            if (String.IsNullOrEmpty(plainText))
            {
                return null;
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string ToBase64Decode(this string base64EncodedData)
        {
            if (String.IsNullOrEmpty(base64EncodedData))
            {
                return null;
            }

            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
