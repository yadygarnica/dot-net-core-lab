using DotNetCoreLab.Core.Models;
using DotNetCoreLab.Core.Models.Enum;

namespace DotNetCoreLab.Core.Interfaces.ApiIntegrations
{
    public interface IPaymentServiceIntegrator
    {
        string AuthorizeTransaction(Transaction transaction);

        TranactionStatus CaptureTransation(Transaction transaction);
    }
}
