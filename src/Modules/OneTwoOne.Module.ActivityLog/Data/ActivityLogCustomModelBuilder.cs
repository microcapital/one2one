using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.ActivityLog.Models;

namespace OneTwoOne.Module.ActivityLog.Data
{
    public class ActivityLogCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasIndex(x => x.ActivityTypeId);

            modelBuilder.Entity<ActivityType>().HasData(new ActivityType(1) { Name = "EntityView" });
        }
    }
}
