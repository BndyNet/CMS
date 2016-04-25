namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public bool EnableAttachment { get; set; }
    }
}
