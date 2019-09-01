using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.PaymentNganLuong.Models;
using OneTwoOne.Module.PaymentNganLuong.ViewModels;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentNganLuong.Areas.PaymentNganLuong.Components
{
    public class NganLuongLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public NganLuongLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var nganLuongProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.NganLuongPaymentProviderId);
            var nganLuongSetting = JsonConvert.DeserializeObject<NganLuongConfigForm>(nganLuongProvider.AdditionalSettings);

            return View(this.GetViewPath());
        }
    }
}
