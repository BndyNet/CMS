namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SinglePage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool EnableComment { get; set; }
        public bool EnableAttachment { get; set; }
    }
}
