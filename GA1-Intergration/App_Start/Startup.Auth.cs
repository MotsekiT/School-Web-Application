using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using System;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Helpers;

namespace FirebaseAuthentication.App_Start
{
    public partial class StartUp
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30.0)
                
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Authentication;
            
        }

        
    }
}