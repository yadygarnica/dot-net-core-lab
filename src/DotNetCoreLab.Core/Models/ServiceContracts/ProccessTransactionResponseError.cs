using System;

namespace DotNetCoreLab.Core.Models.ServiceContracts
{
    public class ProccessTransactionResponseError : ProccessTransactionResponse
    {
        public Exception Exception { get; set; }
    }
}