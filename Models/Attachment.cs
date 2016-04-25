namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileExtensionName { get; set; }
        public string FilePath { get; set; }
        public System.DateTime UploadedDate { get; set; }
        public int BOId { get; set; }
        public BusinessObjectType BOType { get; set; }
    }
}
