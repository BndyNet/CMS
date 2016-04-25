using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Common
{
    public static class StringExtension
    {
        public static string StripHtml(this string it)
        {
            if (string.IsNullOrWhiteSpace(it))
                return string.Empty;

            var pattern = @"</?\w+[\s\S]+?>";
            return Regex.Replace(Regex.Replace(it, pattern, ""), @"\s{2,}", " ");
        }

        public static string Cut(this string it, int length)
        {
            if (string.IsNullOrWhiteSpace(it))
                return string.Empty;

            if (it.Length > length)
            {
                return it.Substring(0, length) + "...";
            }
            else
            {
                return it;
            }
        }
    }
}
