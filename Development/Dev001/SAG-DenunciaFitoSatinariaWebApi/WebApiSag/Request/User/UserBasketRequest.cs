using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class UserBasketRequest
    {
        public string user { get; set; }
        public string userCodeProfile { get; set; }
        public int dayOfWeek { get; set; }
    }
}