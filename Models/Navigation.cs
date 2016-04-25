namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Navigation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public BusinessObjectType BOType { get; set; }
        public string URL { get; set; }
        public string Path { get; set; }
        public int DisplayOrder { get; set; }
    }
}
