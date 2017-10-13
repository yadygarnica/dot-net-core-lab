using DotNetCoreLab.Application.Bootstrapping.Swagger.Settings;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotNetCoreLab.Application.Bootstrapping.Swagger
{
    public class SwaggerHelper
    {
        private readonly SwaggerSetting _swaggerSetting;
        readonly Assembly _assembly;

        public SwaggerHelper(SwaggerSetting swaggerSetting)
        {
            this._assembly = this.GetType().Assembly;
            this._swaggerSetting = swaggerSetting;
        }

        public void SetupOptions(SwaggerGenOptions options)
        {
            options.DocInclusionPredicate((version, apiDescription) =>
            {
                if (apiDescription.GroupName == version)
                {
                    IEnumerable<string> values = apiDescription.RelativePath.Split('/').Select(v => v.Replace("v{version}", version));

                    apiDescription.RelativePath = string.Join("/", values);

                    ApiParameterDescription versionParameter = apiDescription.ParameterDescriptions.SingleOrDefault(p => p.Name == "version");

                    if (versionParameter != null)
                        apiDescription.ParameterDescriptions.Remove(versionParameter);

                    return true;
                }
                else
                {
                    return false;
                }
            });

            foreach (ApiVersionInfo apiVersion in this._swaggerSetting.Versions)
            {
                options.SwaggerDoc(apiVersion.Name, CreateInfoForApiVersion(apiVersion.Name, apiVersion.IsDeprecated));
            }

            // Set the comments path for the Swagger JSON and UI.
            options.IncludeXmlComments(this.XmlCommentsFilePath);
        }

        public void SetupUiOptions(SwaggerUIOptions options)
        {
            foreach (ApiVersionInfo apiVersion in this._swaggerSetting.Versions)
            {
                options.SwaggerEndpoint($"/swagger/{apiVersion.Name}/swagger.json", $"{this.Title} {apiVersion.Name}");
            }
        }

        private string XmlCommentsFilePath
        {
            get
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = this.Title + ".Docs.xml";
                return Path.Combine(basePath, fileName);
            }
        }

        private Info CreateInfoForApiVersion(string apiVersion, bool isDeprecated)
        {
            Info info = new Info()
            {
                Title = $"{this.Title} {apiVersion}",
                Version = apiVersion,
                Description = this.Description,
                Contact = new Contact() { Name = "Garnica, Y.", Email = "yadygarnica@gmail.com" },
                License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if (isDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        private string Description
        {
            get { return GetAttributeValue<AssemblyDescriptionAttribute>(a => a.Description); }
        }

        private string Title
        {
            get { return GetAttributeValue<AssemblyTitleAttribute>(a => a.Title, Path.GetFileNameWithoutExtension(_assembly.CodeBase));}
        }

        private string GetAttributeValue<TAttr>(Func<TAttr,string> resolveFunc, string defaultResult = null) where TAttr : Attribute
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(TAttr), false);

            if (attributes.Length > 0)
            {
                return resolveFunc((TAttr) attributes[0]);
            }
            else
            {
                return defaultResult;
            }
        }
    }
}