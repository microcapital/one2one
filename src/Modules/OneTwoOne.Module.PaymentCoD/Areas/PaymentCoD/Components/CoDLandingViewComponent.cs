using Microsoft.AspNetCore.Mvc;
using OneTwoOne.Infrastructure.Web;

namespace OneTwoOne.Module.PaymentCoD.Areas.PaymentCoD.Components
{
    public class CoDLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(this.GetViewPath());
        }
    }
}
