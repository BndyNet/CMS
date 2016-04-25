namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsEnabled { get; set; }
        public Nullable<System.DateTime> LastLoggedDate { get; set; }
    }
}
