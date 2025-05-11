using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KidHub.Infrastructure.Services.Paymob;

namespace KidHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymobService _paymobService;

        public PaymentController(IPaymobService paymobService)
        {
            _paymobService = paymobService;
        }

        // Endpoint for creating a payment
        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            try
            {
                // Create the payment link using the Paymob service
                var paymentLink = await _paymobService.CreatePaymentLink(
                    request.Amount,
                    request.Currency,
                    request.OrderId
                );

                // Return the generated payment link to the client
                return Ok(new { paymentUrl = paymentLink });
            }
            catch (Exception ex)
            {
                // Handle errors during the payment link creation
                return BadRequest(new { error = ex.Message });
            }
        }

        // Endpoint for validating a payment
        [HttpPost("validate-payment")]
        public async Task<IActionResult> ValidatePayment([FromBody] ValidatePaymentRequest request)
        {
            try
            {
                // Validate the payment using the payment token
                var isValid = await _paymobService.ValidatePayment(request.PaymentToken);
                return Ok(new { isValid });
            }
            catch (Exception ex)
            {
                // Handle errors during the validation process
                return BadRequest(new { error = ex.Message });
            }
        }
    }

    // Request model for creating a payment
    public class CreatePaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "EGP";  // Default currency set to EGP
        public string OrderId { get; set; }
    }

    // Request model for validating a payment
    public class ValidatePaymentRequest
    {
        public string PaymentToken { get; set; }
    }
}
