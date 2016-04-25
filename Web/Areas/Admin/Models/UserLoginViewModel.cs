using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Areas.Admin.Models
{
    public class UserLoginViewModel
    {
        public string Username { get; set; }
        public DateTime DateLoggedin { get; set; }
    }
}