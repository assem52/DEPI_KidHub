using System;

namespace KidHub.Infrastructure.Services.Paymob
{
    public class PaymobSettings
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
        public string IntegrationId { get; set; }
        public string IframeUrl { get; set; }
        public string BaseUrl { get; set; } = "https://accept.paymob.com/api";
    }
} 