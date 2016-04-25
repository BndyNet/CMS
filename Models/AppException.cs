namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppException
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public System.DateTime OccuredDate { get; set; }
    }
}
