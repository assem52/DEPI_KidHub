using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace KidHub.Infrastructure.Services.Paymob
{
    public class PaymobService : IPaymobService
    {
        private readonly HttpClient _httpClient;
        private readonly PaymobSettings _settings;
        private string _authToken;

        public PaymobService(IHttpClientFactory httpClientFactory, IOptions<PaymobSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient(); // Use IHttpClientFactory to create HttpClient
            _settings = settings.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }

        public async Task<string> GetAuthenticationToken()
        {
            if (!string.IsNullOrEmpty(_authToken))
                return _authToken;

            var request = new
            {
                api_key = _settings.ApiKey
            };

            var content = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/auth/tokens", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<PaymobTokenResponse>(responseContent);

            _authToken = tokenResponse.Token;
            return _authToken;
        }

        // Step 1: Create an order with Paymob (order creation)
        public async Task<string> CreateOrderAsync(decimal amount, string currency, string orderId)
        {
            var token = await GetAuthenticationToken();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var request = new
            {
                amount_cents = (int)(amount * 100), // Convert to cents
                currency = currency,
                order_id = orderId,
                integration_id = _settings.IntegrationId
            };

            var content = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/ecommerce/orders", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderResponse = JsonSerializer.Deserialize<PaymobOrderResponse>(responseContent);

            return orderResponse.Id; // Returning the order ID after creation
        }

        // Step 2: Generate payment link (use the order ID)
        public async Task<string> GeneratePaymentKeyAsync(string orderId)
        {
            var token = await GetAuthenticationToken();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var request = new
            {
                order_id = orderId,
                integration_id = _settings.IntegrationId
            };

            var content = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/ecommerce/payment-links", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var paymentResponse = JsonSerializer.Deserialize<PaymobPaymentResponse>(responseContent);

            return paymentResponse.PaymentToken; // Return payment token to be used in iframe
        }

        // Step 3: Finalize payment link (creates iframe URL for the front-end)
        public async Task<string> CreatePaymentLink(decimal amount, string currency, string orderId)
        {
            var orderIdResponse = await CreateOrderAsync(amount, currency, orderId); // First create the order
            var paymentToken = await GeneratePaymentKeyAsync(orderIdResponse); // Then generate the payment key

            // Return the full iframe URL with payment token
            return _settings.IframeUrl.Replace("{payment_key_obtained_previously}", paymentToken);
        }

        public async Task<bool> ValidatePayment(string paymentToken)
        {
            // Implement HMAC validation using the secret key
            // This is a simplified version - you should implement proper HMAC validation
            return true;
        }
    }

    public class PaymobTokenResponse
    {
        public string Token { get; set; }
    }

    public class PaymobPaymentResponse
    {
        public string PaymentToken { get; set; }
    }

    public class PaymobOrderResponse
    {
        public string Id { get; set; }
    }
}
