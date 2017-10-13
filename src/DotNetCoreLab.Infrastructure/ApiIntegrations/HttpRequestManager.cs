using System;
using DotNetCoreLab.Infrastructure.ApiIntegrations.Settings;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace DotNetCoreLab.Infrastructure.ApiIntegrations
{
    public class HttpRequestManager : IHttpRequestManager
    {
        public TResponse InvokeRestMethod<TResponse, TRequest>(RequestSettings requestSettings, TRequest request)
        {
            RestClient restClient = new RestClient(requestSettings.BaseAddress);

            string jsonRequest = JsonConvert.SerializeObject(request);

            RestRequest restRequest = new RestRequest(requestSettings.Endpoint, requestSettings.Method);
            restRequest.AddParameter("application/json; charset=utf-8", jsonRequest, ParameterType.RequestBody);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Timeout = requestSettings.TimeoutInSeconds * 1000;

            IRestResponse response = restClient.Execute(restRequest);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw response.ErrorException;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //TODO: Personalize the exception.
                throw new Exception("Error calling external api.");
            }

            TResponse responseObject = JsonConvert.DeserializeObject<TResponse>(response.Content);

            return responseObject;
        }
    }
}
