using DotNetCoreLab.Core.Interfaces.Repositories;
using DotNetCoreLab.Core.Models;
using System;

namespace DotNetCoreLab.Infrastructure.Repositories
{
    //TODO: Implemetar integração com banco.
    public class TransactionRepository : ITransactionRepository
    {
        public string Create(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction Read(int transactionId)
        {
            throw new NotImplementedException();
        }

        public bool Update(string transactionId, Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
