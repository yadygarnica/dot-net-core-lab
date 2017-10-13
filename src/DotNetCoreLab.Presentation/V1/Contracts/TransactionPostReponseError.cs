using DotNetCoreLab.Core.Models.Enum;
using System;

namespace DotNetCoreLab.Presentation.V1.Contracts
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