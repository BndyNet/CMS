namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserLoginHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClientIP { get; set; }
        public string Browser { get; set; }
        public System.DateTime LoggedOn { get; set; }
    }
}
