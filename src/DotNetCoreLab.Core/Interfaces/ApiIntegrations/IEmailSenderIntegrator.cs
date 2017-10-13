namespace DotNetCoreLab.Core.Interfaces.ApiIntegrations
{
    public interface IEmailSenderIntegrator
    {
        void SendAcceptedPaymentAsync(string addresseeEmail);

        void SendRefusedPaymentAsync(string addresseeEmail);
    }
}