using DotNetCoreLab.Core.Interfaces.ApiIntegrations;
using DotNetCoreLab.Core.Interfaces.Repositories;
using DotNetCoreLab.Core.Interfaces.Service;
using DotNetCoreLab.Core.Models;
using DotNetCoreLab.Core.Models.Enum;
using DotNetCoreLab.Core.Models.ServiceContracts;
using System;
using System.Diagnostics;

namespace DotNetCoreLab.Core.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly IPaymentServiceIntegrator _paymentServiceIntegrator;
        private readonly ITransactionRepository _repository;
        private IEmailSenderIntegrator _emailSenderIntegrator;

        public TransactionService( IPaymentServiceIntegrator paymentServiceIntegrator
            , IEmailSenderIntegrator emailSenderIntegrator,ITransactionRepository repository)
        {
            this._paymentServiceIntegrator = paymentServiceIntegrator;
            this._repository = repository;
            this._emailSenderIntegrator = emailSenderIntegrator;
        }

        public ProccessTransactionResponse Proccess(Transaction transaction)
        {
            try
            {
                transaction.PaymentServiceId = this._paymentServiceIntegrator.AuthorizeTransaction(transaction);

                transaction.Id = this._repository.Create(transaction);

                //Here it can be made any other proccess in between.

                transaction.TranactionStatus = this._paymentServiceIntegrator.CaptureTransation(transaction);

                bool transactionUpdated = this._repository.Update(transaction.Id, transaction);


                if (transaction.TranactionStatus == TranactionStatus.Aproved)
                {
                    if (transactionUpdated)
                    {
                        //TODO: SendEmail to the user
                        this._emailSenderIntegrator.SendAcceptedPaymentAsync(transaction.Cardholder.EmailAddress);
                    }
                    else
                    {
                        //TODO: Retry
                    }
                }
                else
                {
                    throw new Exception("Payment refused.");
                }

                return new ProccessTransactionResponse()
                {
                    TranactionStatus = transaction.TranactionStatus,
                    TransactionId = transaction.Id
                };
            }
            catch (Exception exception)
            {
                Debug.Write(exception.Message);

                this._emailSenderIntegrator.SendRefusedPaymentAsync(transaction.Cardholder.EmailAddress);

                return new ProccessTransactionResponseError()
                {
                    Exception = exception,
                    TranactionStatus = TranactionStatus.Denied,
                    TransactionId = ""
                };
            }
        }
    }
}