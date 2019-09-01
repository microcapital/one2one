using System.Collections.Generic;
using OneTwoOne.Module.Core.Areas.Core.ViewModels;

namespace OneTwoOne.Module.Cms.Areas.Cms.ViewModels
{
    public class SpaceBarWidgetForm : WidgetFormBase
    {
        public IList<SpaceBarWidgetSetting> Items = new List<SpaceBarWidgetSetting>();
    }
}
