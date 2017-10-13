using DotNetCoreLab.Infrastructure.ApiIntegrations.Settings;

namespace DotNetCoreLab.Infrastructure.ApiIntegrations
{
    public interface IHttpRequestManager
    {
        TResponse InvokeRestMethod<TResponse, TRequest>(RequestSettings requestSettings, TRequest request);
    }
}