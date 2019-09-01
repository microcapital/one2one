using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Notifications.Models;

namespace OneTwoOne.Module.Notifications.Data
{
    public class NotificationsCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotification>().ToTable("Notifications_UserNotification");
        }
    }
}
