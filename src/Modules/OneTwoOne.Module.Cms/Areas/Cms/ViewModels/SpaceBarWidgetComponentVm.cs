using System.Collections.Generic;

namespace OneTwoOne.Module.Cms.Areas.Cms.ViewModels
{
    public class SpaceBarWidgetComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public List<SpaceBarWidgetSetting> Items { get; set; }
    }
}
