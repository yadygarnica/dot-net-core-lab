using System;
using DotNetCoreLab.Core.Models.Enum;

namespace DotNetCoreLab.Presentation.V2.Contracts
{
    public class TransactionPostReponseError : TransactionPostResponse
    {
        public TransactionPostReponseError(TranactionStatus tranactionStatus, Exception exception)
            : base(tranactionStatus, "")
        {
            this.Exception = exception;
        }

        public Exception Exception { get; set; }
    }
}