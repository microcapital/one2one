using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Route("api/districts")]
    public class DistrictApiController : Controller
    {
        private readonly IRepository<District> _districtRepository;

        public DistrictApiController(IRepository<District> districtRepository)
        {
            _districtRepository = districtRepository;
        }

        [HttpGet("/api/states-provinces/{stateOrProvinceId}/districts")]
        public async Task<IActionResult> GetDistricts(long stateOrProvinceId)
        {
            var districts = await _districtRepository
                .Query()
                .Where(x => x.StateOrProvinceId == stateOrProvinceId)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Id,
                    x.Name
                }).ToListAsync();

            return Json(districts);
        }
    }
}
