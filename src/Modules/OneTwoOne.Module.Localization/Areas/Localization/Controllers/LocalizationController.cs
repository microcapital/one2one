﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Core.Extensions;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Localization.Areas.Localization.Controllers
{
    [Area("Localization")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LocalizationController : Controller
    {
        private readonly IRepositoryWithTypedId<User, long> _userRepository;
        private readonly IWorkContext _workContext;

        public LocalizationController(IRepositoryWithTypedId<User, long> userRepository, IWorkContext workContext)
        {
            _userRepository = userRepository;
            _workContext = workContext;
        }

        [HttpPost]
        public async Task<IActionResult> SetLanguage(string culture, string returnUrl)
        {
            var currentUser = await _workContext.GetCurrentUser();

            currentUser.Culture = culture;
            _userRepository.SaveChanges();

            return LocalRedirect(returnUrl);
        }
    }
}
