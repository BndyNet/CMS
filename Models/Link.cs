namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Link
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LinkUrl { get; set; }
        public string LinkImage { get; set; }
        public int DisplayOrder { get; set; }
    }
}
