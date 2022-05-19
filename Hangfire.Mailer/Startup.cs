using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using System.Web.Http;
using WebActivatorEx;
using Hangfire.Mailer;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

[assembly: OwinStartup(typeof(Hangfire.Mailer.Startup))]
[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Hangfire.Mailer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("MailerDb")
                .UseFilter(new LogFailureAttribute());
                
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
