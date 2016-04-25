using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Models
{
    public partial class Navigation
    {
        public List<Navigation> Children { get; set; }

        public Navigation()
        {
            Children = new List<Navigation>();
        }

        public static string GetPath(int id, string path)
        {
            return string.Format("{0}{1}/", path, id);
        }

        public static int GetLevel(Navigation nav)
        {
            return nav.Path.Split('/').Length - 1;
        }
    }
}
