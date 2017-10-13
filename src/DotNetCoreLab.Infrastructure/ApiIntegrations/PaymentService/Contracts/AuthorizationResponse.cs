namespace DotNetCoreLab.Infrastructure.ApiIntegrations.PaymentService.Contracts
{
    public class AuthorizationResponse
    {
        public string TransactionId { get; set ;}

        public int TranactionStatus { get; set ;}
    }
}