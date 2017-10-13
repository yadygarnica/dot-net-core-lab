using DotNetCoreLab.Core.Models;

namespace DotNetCoreLab.Infrastructure.ApiIntegrations.PaymentService.Contracts
{
    public class AuthorizationRequest
    {
        /// <summary>
        /// Transaction to be authorized.
        /// </summary>
        public Transaction Transaction { get; set; }
    }
}