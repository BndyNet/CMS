namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public bool EnableComment { get; set; }
        public short Views { get; set; }
    }
}
