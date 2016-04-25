namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Download
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public System.DateTime UploadedDate { get; set; }
        public int Views { get; set; }
    }
}
