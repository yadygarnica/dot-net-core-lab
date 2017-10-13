using DotNetCoreLab.Core.Models;

namespace DotNetCoreLab.Core.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        string Create(Transaction transaction);

        Transaction Read(int transactionId);

        bool Update(string transactionId, Transaction transaction);

        bool Delete(string transactionId);
    }
}
