using DotNetCoreLab.Core.Models.Enum;

namespace DotNetCoreLab.Core.Models
{
    public class Transaction
    {
        public string Id { get; set; }

        public string PaymentServiceId { get; set; }

        public TranactionStatus TranactionStatus { get; set; }

        public int Amount { get; set; }

        public Card Card { get; set; }

        public Cardholder Cardholder { get; set; }
    }
}
