using DotNetCoreLab.Core.Interfaces.Service;
using DotNetCoreLab.Core.Models;
using DotNetCoreLab.Core.Models.ServiceContracts;
using DotNetCoreLab.Presentation.V2.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCoreLab.Presentation.V2.Controllers
{
    /// <inheritdoc />
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        /// <summary>
        /// GET api/v1/transactions
        /// Get the last 100 transactions from the db
        /// Not implemented yet.
        /// </summary>
        [HttpGet]
        public List<Transaction> Get()
        {
            //TODO: Call the service.
            return new List<Transaction>() { };
        }

        /// <summary>
        /// GET api/v1/transactions/id
        /// Get a proccessed transaction from the db.
        /// Not implemented yet.
        /// </summary>
        /// <param name="id">Id of the Transaction</param>
        /// <returns>A Transaction.</returns>
        [HttpGet("{id}")]
        public Transaction Get(string id)
        {
            //TODO: Call the service.
            return new Transaction();
        }

        /// <summary>
        ///  DELETE api/v2/transactions/transactioId.
        ///  Delete a transaction from de db.
        /// Not implemented yet.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            //TODO: Call the service.
        }

        /// <summary>
        ///  PUT api/v2/transaction/transactioId.
        /// Not implemented yet.
        /// </summary>
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Transaction transaction)
        {
            //TODO: Call the service.
        }

        /// <summary>
        /// POST api/v1/transactions
        /// Proccess a Transaction and save it into a db.
        /// </summary>
        [HttpPost]
        public TransactionPostResponse Post([FromBody]Transaction transaction)
        {
            ProccessTransactionResponse response = this._transactionService.Proccess(transaction);

            if (response is ProccessTransactionResponseError == true)
            {
                ProccessTransactionResponseError responseError = (ProccessTransactionResponseError) response;

                return new TransactionPostReponseError(responseError.TranactionStatus, responseError.Exception);
            }

            return new TransactionPostResponse(response.TranactionStatus, response.TransactionId);
        }
    }
}
