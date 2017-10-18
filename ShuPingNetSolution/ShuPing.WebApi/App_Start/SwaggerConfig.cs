using System.Web.Http;
using WebActivatorEx;
using ShuPing.WebApi;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ShuPing.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ShuPing.WebApi");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>{});
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/ShuPing.WebApi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
