using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.PaymentBraintree.Areas.PaymentBraintree.ViewModels;
using OneTwoOne.Module.PaymentBraintree.Models;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentBraintree.Areas.PaymentBraintree.Controllers
{
    [Area("PaymentBraintree")]
    [Authorize(Roles = "admin")]
    [Route("api/braintree")]
    public class BraintreeApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public BraintreeApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.BraintreeProviderId);
            var model = JsonConvert.DeserializeObject<BraintreeConfigForm>(stripeProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] BraintreeConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.BraintreeProviderId);
                stripeProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
