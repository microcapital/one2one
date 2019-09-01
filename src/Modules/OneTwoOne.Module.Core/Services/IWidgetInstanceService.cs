using System.Linq;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Core.Services
{
    public interface IWidgetInstanceService
    {
        IQueryable<WidgetInstance> GetPublished();
    }
}
