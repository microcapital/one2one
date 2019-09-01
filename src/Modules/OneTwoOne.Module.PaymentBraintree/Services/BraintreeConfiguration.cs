using System.Threading.Tasks;
using Braintree;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.PaymentBraintree.Areas.PaymentBraintree.ViewModels;
using OneTwoOne.Module.PaymentBraintree.Models;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentBraintree.Services
{
    public class BraintreeConfiguration : IBraintreeConfiguration
    {
        public string Environment { get; private set; }
        public string MerchantId { get; private set; }
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }

        public async Task<IBraintreeGateway> BraintreeGateway()
        {
            if (_braintreeGateway == null)
            {
                _braintreeGateway = await CreateGateway();
            }

            return _braintreeGateway;
        }

        private IBraintreeGateway _braintreeGateway { get; set; }

        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public BraintreeConfiguration(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }
    

        private async Task<IBraintreeGateway> CreateGateway()
        {
            var braintreeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.BraintreeProviderId);
            var braintreeSetting = JsonConvert.DeserializeObject<BraintreeConfigForm>(braintreeProvider.AdditionalSettings);

            Environment = braintreeSetting.Environment;
            MerchantId = braintreeSetting.MerchantId;
            PublicKey = braintreeSetting.PublicKey;
            PrivateKey = braintreeSetting.PrivateKey;

            return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey);
        }

        public async Task<string> GetClientToken()
        {
            var gateway = await BraintreeGateway();
            return await gateway.ClientToken.GenerateAsync();
        }
    }
}
