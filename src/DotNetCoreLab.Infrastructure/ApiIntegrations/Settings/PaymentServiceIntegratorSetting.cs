namespace DotNetCoreLab.Infrastructure.ApiIntegrations.Settings
{
    public class PaymentServiceIntegratorSetting
    {
        public string BaseAddress { get; set; }
        public string AuthorizeEndpoint { get; set; }
        public string CaptureEndpoint { get; set; }
        public int TimeoutInSeconds { get; set; }
    }
}
