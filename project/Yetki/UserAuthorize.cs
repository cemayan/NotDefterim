using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace project.Yetki
{
        public class UserAuthorize : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {

            if (httpContext.User.Identity.IsAuthenticated)
                {                    
                    return true;

                }
                else
                {

                httpContext.Response.Redirect("~/Anasayfa/Login");
                return false;
                }

            }
        }
    
}