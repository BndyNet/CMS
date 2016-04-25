using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class BOPropertyDefinition
    {
        public BusinessObjectType BOType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsSortable { get; set; }
        public bool IsQueryable { get; set; }
        public string ValueFormat { get; set; }
        public AttrValueType ValueType { get; set; }
        public int DisplayOrder { get; set; }
    }
}
