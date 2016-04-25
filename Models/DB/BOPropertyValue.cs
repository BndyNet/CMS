using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DB
{
    public class BOPropertyValue
    {
        public int BOId { get; set; }
        public BusinessObjectType BOType { get; set; }
        public int PropertyDefinitionId { get; set; }
        public string Value { get; set; }
    }
}
