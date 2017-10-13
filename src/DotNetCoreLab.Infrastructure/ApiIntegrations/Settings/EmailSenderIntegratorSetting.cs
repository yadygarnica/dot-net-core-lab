namespace DotNetCoreLab.Infrastructure.ApiIntegrations.Settings
{
    public class EmailSenderIntegratorSetting
    {
        public string BaseAddress { get; set; }
        public string SendEmailEndpoint { get; set; }
        public int TimeoutInSeconds { get; set; }
    }
}
