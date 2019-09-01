using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneTwoOne.Module.SampleData.Areas.SampleData.ViewModels;
using OneTwoOne.Module.SampleData.Services;

namespace OneTwoOne.Module.SampleData.Areas.SampleData.Controllers
{
    [Area("SampleData")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SampleDataController : Controller
    {
        private readonly ISampleDataService _sampleDataService;

        public SampleDataController(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetToSample(SampleDataOption model)
        {
            await _sampleDataService.ResetToSampleData(model);
            return Redirect("~/");
        }
    }
}
