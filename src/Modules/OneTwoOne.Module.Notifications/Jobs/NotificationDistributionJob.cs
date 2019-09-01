using OneTwoOne.Infrastructure.Helpers;
using OneTwoOne.Module.HangfireJobs.Models;
using OneTwoOne.Module.Notifications.Services;

namespace OneTwoOne.Module.Notifications.Jobs
{
    /// <summary>
    /// This background job distributes notifications to users.
    /// </summary>
    public class NotificationDistributionJob : BackgroundJob<NotificationDistributionJobArgs>
    {
        private readonly INotificationDistributer _notificationDistributer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationDistributionJob"/> class.
        /// </summary>
        public NotificationDistributionJob(INotificationDistributer notificationDistributer)
        {
            _notificationDistributer = notificationDistributer;
        }

        public override void Execute(NotificationDistributionJobArgs args)
        {
            AsyncHelper.RunSync(() => _notificationDistributer.DistributeAsync(args.NotificationId));
        }
    }
}
