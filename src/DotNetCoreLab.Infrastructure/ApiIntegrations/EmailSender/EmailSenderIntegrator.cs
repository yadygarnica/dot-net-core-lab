using DotNetCoreLab.Core.Interfaces.ApiIntegrations;

namespace DotNetCoreLab.Infrastructure.ApiIntegrations.EmailSender
{
    public class EmailSenderIntegrator : IEmailSenderIntegrator
    {
        public void SendAcceptedPaymentAsync(string addresseeEmail)
        {
            throw new System.NotImplementedException();
        }

        public void SendRefusedPaymentAsync(string addresseeEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}
