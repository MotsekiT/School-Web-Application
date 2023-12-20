using Microsoft.Owin;
using Owin;
using FirebaseAuthentication.App_Start;

[assembly: OwinStartupAttribute(typeof(FirebaseAuthentication.App_Start.StartUp))]
namespace FirebaseAuthentication.App_Start
{
    public partial class StartUp
    {
        public void Configuration (IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}