using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.PaymentCoD.Models;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.PaymentCoD.Areas.PaymentCoD.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("PaymentCoD")]
    [Route("api/cod")]
    public class CoDApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public CoDApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var codProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CODProviderId);
            if (string.IsNullOrEmpty(codProvider.AdditionalSettings))
            {
                return Ok(new CoDSetting());
            }

            var model = JsonConvert.DeserializeObject<CoDSetting>(codProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] CoDSetting model)
        {
            if (ModelState.IsValid)
            {
                var codProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CODProviderId);
                codProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
