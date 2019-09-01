using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Core.Extensions;
using OneTwoOne.Module.Orders.Services;
using OneTwoOne.Module.Payments.Areas.Payments.ViewModels;
using OneTwoOne.Module.Payments.Models;
using OneTwoOne.Module.ShoppingCart.Models;
using OneTwoOne.Module.ShoppingCart.Services;

namespace OneTwoOne.Module.Payments.Areas.Payments.Controllers
{
    [Area("Payments")]
    [Route("checkout")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CheckoutController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;

        public CheckoutController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
        }

        [HttpGet("payment")]
        public async Task<IActionResult> Payment()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id);
            if(cart == null)
            {
                return Redirect("~/");
            }

            cart.LockedOnCheckout = true;
            await _paymentProviderRepository.SaveChangesAsync();

            var checkoutPaymentForm = new CheckoutPaymentForm();
            checkoutPaymentForm.PaymentProviders = await _paymentProviderRepository.Query()
                .Where(x => x.IsEnabled)
                .Select(x => new PaymentProviderVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    LandingViewComponentName = x.LandingViewComponentName
                }).ToListAsync();

            return View(checkoutPaymentForm);
        }
    }
}
