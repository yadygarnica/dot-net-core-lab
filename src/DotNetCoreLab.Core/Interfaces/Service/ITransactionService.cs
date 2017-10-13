using DotNetCoreLab.Core.Models;
using DotNetCoreLab.Core.Models.ServiceContracts;

namespace DotNetCoreLab.Core.Interfaces.Service
{
    public interface ITransactionService
    {
        ProccessTransactionResponse Proccess(Transaction transaction);
    }
}