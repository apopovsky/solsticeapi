using System.Web.Http;
using WebActivatorEx;
using SolsticeApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SolsticeApi
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SolsticeApi");

                        // If you want the output Swagger docs to be indented properly, enable the "PrettyPrint" option.
                        //
                        c.PrettyPrint();

                        c.IncludeXmlComments(GetXmlCommentsPath());

                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                .EnableSwaggerUi();
        }

        /// <summary>
        /// Gets the path to the Xml Comments file for the Web API assembly
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = string.Format("{0}.XML", Assembly.GetExecutingAssembly().GetName().Name);
            var binFilePath = Path.Combine(baseDirectory, "bin");
            var commentsFilePath = Path.Combine(binFilePath, commentsFileName);

            return commentsFilePath;
        }
    }
}
