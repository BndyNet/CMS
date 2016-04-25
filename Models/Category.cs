namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Flag { get; set; }
        public BusinessObjectType BOType { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
    }
}
