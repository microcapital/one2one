using System.Linq;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.ActivityLog.Models;

namespace OneTwoOne.Module.ActivityLog.Data
{
    public interface IActivityTypeRepository : IRepository<Activity>
    {
        IQueryable<MostViewEntityDto> List();
    }
}
