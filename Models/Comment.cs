namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> RefCommentId { get; set; }
        public string ClientIP { get; set; }
        public int BOId { get; set; }
        public BusinessObjectType BOType { get; set; }
    }
}
