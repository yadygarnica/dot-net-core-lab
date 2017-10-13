using DotNetCoreLab.Application.Bootstrapping.Swagger;
using DotNetCoreLab.Application.Bootstrapping.WebApi.Settings;
using DotNetCoreLab.Core.Interfaces.ApiIntegrations;
using DotNetCoreLab.Core.Interfaces.Repositories;
using DotNetCoreLab.Core.Interfaces.Service;
using DotNetCoreLab.Core.Services;
using DotNetCoreLab.Infrastructure.ApiIntegrations;
using DotNetCoreLab.Infrastructure.ApiIntegrations.EmailSender;
using DotNetCoreLab.Infrastructure.ApiIntegrations.PaymentService;
using DotNetCoreLab.Infrastructure.ApiIntegrations.Settings;
using DotNetCoreLab.Infrastructure.Repositories;
using DotNetCoreLab.Infrastructure.Repositories.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreLab.Application.Bootstrapping.WebApi
{
    public class Startup
    {
        private readonly SwaggerHelper _swaggerHelper;

        private readonly ApplicationSettings _applicationSettings;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

            this._applicationSettings = new ApplicationSettings();
            this.Configuration.GetSection("AppSettings").Bind(this._applicationSettings);
            
            this._swaggerHelper = new SwaggerHelper(this._applicationSettings.SwaggerSetting);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();

            // Add framework services.
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(2, 0);
            });
            
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(this._swaggerHelper.SetupOptions);

            //Register AppConfigs
            services.AddSingleton<RepositorySetting>(this._applicationSettings.RepositorySetting);
            services.AddSingleton<PaymentServiceIntegratorSetting>(this._applicationSettings.PaymentServiceIntegratorSetting);

            //Register dependency classes
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IPaymentServiceIntegrator, PaymentServiceIntegrator>();
            services.AddSingleton<IEmailSenderIntegrator, EmailSenderIntegrator>();
            services.AddSingleton<IHttpRequestManager, HttpRequestManager>();
            services.AddSingleton<ITransactionService, TransactionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(this._swaggerHelper.SetupUiOptions);

            app.UseMvcWithDefaultRoute();
        }
    }
}
