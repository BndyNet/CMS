namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOAttributeDefinition
    {
        public BOAttributeDefinition()
        {
            this.BOAttributeValues = new HashSet<BOAttributeValue>();
        }
    
        public int Id { get; set; }
        public int BOCategoryId { get; set; }
        public BusinessObjectType BOType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AttrValueType ValueType { get; set; }
    
        public virtual ICollection<BOAttributeValue> BOAttributeValues { get; set; }
    }
}
