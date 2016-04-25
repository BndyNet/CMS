namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOAttributeValue
    {
        public int Id { get; set; }
        public int BOId { get; set; }
        public BusinessObjectType BOType { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
    
        public virtual BOAttributeDefinition BOAttributeDefinition { get; set; }
    }
}
