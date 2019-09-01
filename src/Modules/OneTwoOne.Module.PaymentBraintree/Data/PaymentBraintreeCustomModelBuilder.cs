using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.PaymentBraintree.Models;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentBraintree.Data
{
    public class PaymentBraintreeCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("Braintree") {
                    Name = PaymentProviderHelper.BraintreeProviderId,
                    LandingViewComponentName = "BraintreeLanding",
                    ConfigureUrl = "payments-braintree-config",
                    IsEnabled = true,
                    AdditionalSettings =
                    "{" +
                        "\"PublicKey\": \"6j4d7qspt5n48kx4\", " +
                        "\"PrivateKey\" : \"bd1c26e53a6d811243fcc3eb268113e1\", " +
                        "\"MerchantId\" : \"ncsh7wwqvzs3cx9q\", " +
                        "\"IsProduction\" : \"false\"" +
                    "}"
                }
            );
        }
    }
}
