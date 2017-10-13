using RestSharp;

namespace DotNetCoreLab.Infrastructure.ApiIntegrations.Settings
{
    public class RequestSettings
    {
        public string BaseAddress { get; set; }

        public string Endpoint { get; set; }

        public int TimeoutInSeconds { get; set; }

        public Method Method { get; set; }
    }
}
