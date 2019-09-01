using System.Collections.Generic;
using OneTwoOne.Module.Core.Areas.Core.ViewModels;

namespace OneTwoOne.Module.Cms.Areas.Cms.ViewModels
{
    public class CarouselWidgetForm : WidgetFormBase
    {
        public IList<CarouselWidgetItemForm> Items = new List<CarouselWidgetItemForm>();
    }
}
