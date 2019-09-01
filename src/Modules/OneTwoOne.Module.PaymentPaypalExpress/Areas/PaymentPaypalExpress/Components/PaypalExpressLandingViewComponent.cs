using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.PaymentPaypalExpress.Models;
using OneTwoOne.Module.PaymentPaypalExpress.ViewModels;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentPaypalExpress.Areas.PaymentPaypalExpress.Components
{
    public class PaypalExpressLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public PaypalExpressLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paypalExpressProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaypalExpressProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<PaypalExpressConfigForm>(paypalExpressProvider.AdditionalSettings);

            var model = new PaypalExpressCheckoutForm();
            model.Environment = paypalExpressSetting.Environment;
            model.PaymentFee = paypalExpressSetting.PaymentFee;

            return View(this.GetViewPath(), model);
        }
    }
}
