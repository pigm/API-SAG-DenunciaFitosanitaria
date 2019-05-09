using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;


namespace WebApiSag.Security.Identity
{
    public class JWTAuthenticationIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Valida usuario
        /// </summary>
        /// <param name="userName"></param>
        public JWTAuthenticationIdentity(string userName)
            : base(userName)
        {
            UserName = userName;
        }
    }
}