using DotNetCoreLab.Application.Bootstrapping.Swagger.Settings;
using DotNetCoreLab.Infrastructure.ApiIntegrations.Settings;
using DotNetCoreLab.Infrastructure.Repositories.Settings;

namespace DotNetCoreLab.Application.Bootstrapping.WebApi.Settings
{
    public class ApplicationSettings
    {
        public RepositorySetting RepositorySetting { get; set; }

        public SwaggerSetting SwaggerSetting { get; set; }

        public PaymentServiceIntegratorSetting PaymentServiceIntegratorSetting { get; set; }

        public EmailSenderIntegratorSetting EmailSenderIntegratorSetting { get; set; }
    }
}