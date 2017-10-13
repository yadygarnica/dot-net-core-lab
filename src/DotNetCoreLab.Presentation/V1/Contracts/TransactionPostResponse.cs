using DotNetCoreLab.Core.Models.Enum;

namespace DotNetCoreLab.Presentation.V1.Contracts
{
    public class TransactionPostResponse
    {
        public TransactionPostResponse(TranactionStatus tranactionStatus, string transactionId)
        {
            this.TranactionStatus = tranactionStatus;
            this.TransactionId = transactionId;
        }

        public TranactionStatus TranactionStatus { get; set; }

        public string TransactionId { get; set; }
    }
}
