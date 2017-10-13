using DotNetCoreLab.Core.Models.Enum;

namespace DotNetCoreLab.Core.Models.ServiceContracts
{
    public class ProccessTransactionResponse
    {
        public TranactionStatus TranactionStatus { get; set; }

        public string TransactionId { get; set; }
    }
}