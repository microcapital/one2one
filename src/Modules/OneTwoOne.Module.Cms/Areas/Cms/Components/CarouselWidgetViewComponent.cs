using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Cms.Areas.Cms.ViewModels;
using OneTwoOne.Module.Core.Areas.Core.ViewModels;
using OneTwoOne.Module.Core.Services;

namespace OneTwoOne.Module.Cms.Areas.Cms.Components
{
    public class CarouselWidgetViewComponent : ViewComponent
    {
        private IMediaService _mediaService;

        public CarouselWidgetViewComponent(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new CarouselWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetViewComponentItemVm>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                item.Image = _mediaService.GetMediaUrl(item.Image);
            }

            return View(this.GetViewPath(), model);
        }
    }
}
