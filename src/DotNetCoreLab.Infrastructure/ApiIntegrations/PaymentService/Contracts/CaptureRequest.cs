namespace DotNetCoreLab.Infrastructure.ApiIntegrations.PaymentService.Contracts
{
    public class CaptureRequest
    {
        /// <summary>
        /// Transaction id to be captured.
        /// </summary>
        public string TransactionId { get; set; }
    }
}