using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Helpers;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Core.Extensions;
using OneTwoOne.Module.Core.Services;
using OneTwoOne.Module.Payments.Models;
using OneTwoOne.Module.PaymentStripe.Areas.PaymentStripe.ViewModels;
using OneTwoOne.Module.PaymentStripe.Models;
using OneTwoOne.Module.ShoppingCart.Services;

namespace OneTwoOne.Module.PaymentStripe.Areas.PaymentStripe.Components
{
    public class StripeLandingViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly ICurrencyService _currencyService;

        public StripeLandingViewComponent(ICartService cartService, IWorkContext workContext, IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository, ICurrencyService currencyService)

        {
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _currencyService = currencyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
            var stripeSetting = JsonConvert.DeserializeObject<StripeConfigForm>(stripeProvider.AdditionalSettings);
            var curentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(curentUser.Id);
            var zeroDecimalAmount = cart.OrderTotal;
            if(!CurrencyHelper.IsZeroDecimalCurrencies(_currencyService.CurrencyCulture))
            {
                zeroDecimalAmount = zeroDecimalAmount * 100;
            }

            var regionInfo = new RegionInfo(_currencyService.CurrencyCulture.LCID);
            var model = new StripeCheckoutForm();
            model.PublicKey = stripeSetting.PublicKey;
            model.Amount = (long)zeroDecimalAmount;
            model.ISOCurrencyCode = regionInfo.ISOCurrencySymbol;

            return View(this.GetViewPath(), model);
        }
    }
}
