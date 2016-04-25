using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public static class WebUrlHelper
    {
        public static string AttachQuery(Uri url, string key, object value)
        {
            if (string.IsNullOrWhiteSpace(url.Query))
                return string.Format("{0}?{1}={2}", url, key, value);

            var attached = false;
            var queries = new List<string>();
            foreach (var kv in url.Query.Replace("?", "").Split('&'))
            {
                var arr = kv.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr[0] == key)
                {
                    queries.Add(string.Format("{0}={1}", key, value));
                    attached = true;
                }
                else
                {
                    queries.Add(string.Format("{0}={1}", arr[0], arr.Length > 1 ? arr[1] : ""));
                }
            }

            if (!attached)
            {
                queries.Add(string.Format("{0}={1}", key, value)); 
            }

            return string.Format("{0}?{1}", url.AbsolutePath, string.Join("&", queries));
        }
    }
}
