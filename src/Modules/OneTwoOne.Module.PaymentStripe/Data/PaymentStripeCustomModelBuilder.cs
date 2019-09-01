using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentStripe.Data
{
    public class PaymentStripeCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("Stripe") { Name = "Stripe", LandingViewComponentName = "StripeLanding", ConfigureUrl = "payments-stripe-config", IsEnabled = true, AdditionalSettings = "{\"PublicKey\": \"pk_test_6pRNASCoBOKtIshFeQd4XMUh\", \"PrivateKey\" : \"sk_test_BQokikJOvBiI2HlWgH4olfQ2\"}" }
            );
        }
    }
}
