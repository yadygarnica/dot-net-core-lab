using DotNetCoreLab.Core.Interfaces.ApiIntegrations;
using DotNetCoreLab.Core.Models;
using DotNetCoreLab.Core.Models.Enum;
using DotNetCoreLab.Infrastructure.ApiIntegrations.PaymentService.Contracts;
using DotNetCoreLab.Infrastructure.ApiIntegrations.Settings;
using RestSharp;

namespace DotNetCoreLab.Infrastructure.ApiIntegrations.PaymentService
{
    public class PaymentServiceIntegrator : IPaymentServiceIntegrator
    {
       
        private readonly PaymentServiceIntegratorSetting _paymentServiceIntegratorSetting;
        private IHttpRequestManager _requestManager;

        public PaymentServiceIntegrator(PaymentServiceIntegratorSetting paymentServiceIntegratorSetting, IHttpRequestManager requestManager)
        {
            this._paymentServiceIntegratorSetting = paymentServiceIntegratorSetting;
            this._requestManager = requestManager;
        }

        public string AuthorizeTransaction(Transaction transaction)
        {
            AuthorizationRequest request = new AuthorizationRequest()
            {
                Transaction = transaction
            };

            RequestSettings resquestSettings = new RequestSettings()
            {
                BaseAddress = this._paymentServiceIntegratorSetting.BaseAddress,
                Endpoint = this._paymentServiceIntegratorSetting.AuthorizeEndpoint,
                TimeoutInSeconds = this._paymentServiceIntegratorSetting.TimeoutInSeconds,
                Method = Method.POST
            };

            AuthorizationResponse response = this._requestManager.InvokeRestMethod<AuthorizationResponse, AuthorizationRequest>(resquestSettings, request);

            return response.TransactionId;
        }

        public TranactionStatus CaptureTransation(Transaction transaction)
        {
            CaptureRequest request = new CaptureRequest()
            {
                TransactionId = transaction.Id
            };

            RequestSettings resquestSettings = new RequestSettings()
            {
                BaseAddress = this._paymentServiceIntegratorSetting.BaseAddress,
                Endpoint = this._paymentServiceIntegratorSetting.CaptureEndpoint,
                TimeoutInSeconds = this._paymentServiceIntegratorSetting.TimeoutInSeconds,
                Method = Method.POST
            };

            CaptureResponse response = this._requestManager.InvokeRestMethod<CaptureResponse, CaptureRequest>(resquestSettings, request);

            return (TranactionStatus)response.TranactionStatus;
        }
    }
}