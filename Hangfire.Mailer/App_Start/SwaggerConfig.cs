using System.Web.Http;
using WebActivatorEx;
using Hangfire.Mailer;
using Swashbuckle.Application;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Hangfire.Mailer
{
    public class SwaggerConfig
    {
       public static void Register()
        {
            //var thisAssembly = typeof(SwaggerConfig).Assembly;
            //GlobalConfiguration.Configuration
            //    .EnableSwagger(c => { c.SingleApiVersion("v1", "Hangfire.Mailer"); })
            //    .EnableSwaggerUi(c => { });
        }
    }
}
