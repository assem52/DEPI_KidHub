using System.Threading.Tasks;

namespace KidHub.Infrastructure.Services.Paymob
{
    public interface IPaymobService
    {
        Task<string> GetAuthenticationToken();
        Task<string> CreatePaymentLink(decimal amount, string currency, string orderId);
        Task<bool> ValidatePayment(string paymentToken);
    }
} 