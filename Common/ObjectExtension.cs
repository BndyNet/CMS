using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Gets dictionary instance that includes all property names and values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Dictionary{System.String System.String}.</returns>
        public static Dictionary<string, string> ToDict(this object obj)
        {
            if (obj == null) return null;

            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (obj is IDictionary)
            {
                var d = (IDictionary)obj;
                foreach (var key in d.Keys)
                {
                    if (key != null && d[key] != null)
                    {
                        dict[key.ToString()] = d[key].ToString();
                    }
                }
            }
            else
            {
                var properties = obj.GetType().GetProperties();
                foreach (var p in properties)
                {
                    var value = p.GetValue(obj, null);
                    dict.Add(p.Name, value == null ? null : value.ToString());
                }
            }
            return dict;
        }
    }
}
