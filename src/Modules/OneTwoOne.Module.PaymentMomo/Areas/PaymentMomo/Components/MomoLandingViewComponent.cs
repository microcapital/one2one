﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.PaymentMomo.Models;
using OneTwoOne.Module.PaymentMomo.ViewModels;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentMomo.Areas.PaymentMomo.Components
{
    public class MomoLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public MomoLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var momoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.MomoPaymentProviderId);
            var momoSetting = JsonConvert.DeserializeObject<MomoPaymentConfigForm>(momoProvider.AdditionalSettings);

            var model = new MomoCheckoutForm();
            model.PaymentFee = momoSetting.PaymentFee;

            return View(this.GetViewPath(), model);
        }
    }
}
