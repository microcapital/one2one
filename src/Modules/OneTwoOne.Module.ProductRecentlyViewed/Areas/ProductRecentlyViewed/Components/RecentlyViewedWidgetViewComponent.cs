using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Core.Areas.Core.ViewModels;
using OneTwoOne.Module.Core.Services;
using OneTwoOne.Module.ProductRecentlyViewed.Areas.ProductRecentlyViewed.ViewModels;

namespace OneTwoOne.Module.ProductRecentlyViewed.Areas.ProductRecentlyViewed.Components
{
    public class RecentlyViewedWidgetViewComponent: ViewComponent
    {
        private IMediaService _mediaService;

        public RecentlyViewedWidgetViewComponent(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new RecentlyViewedWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                ItemCount = JsonConvert.DeserializeObject<int>(widgetInstance.Data)
            };

            return View(this.GetViewPath(), model);
        }

    }
}
