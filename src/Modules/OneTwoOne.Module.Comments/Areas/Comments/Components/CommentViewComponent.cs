using Microsoft.AspNetCore.Mvc;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Comments.Areas.Comments.ViewModels;

namespace OneTwoOne.Module.Comments.Areas.Comments.Components
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long entityId, string entityTypeId)
        {

            var model = new CommentVm
            {
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            return View(this.GetViewPath(), model);
        }
    }
}
