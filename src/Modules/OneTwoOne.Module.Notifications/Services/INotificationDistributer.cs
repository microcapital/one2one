using System.Threading.Tasks;

namespace OneTwoOne.Module.Notifications.Services
{
    /// <summary>
    /// Used to distribute notifications to users.
    /// </summary>
    public interface INotificationDistributer //时态
    {
        /// <summary>
        /// Distributes given notification to users.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        Task DistributeAsync(long notificationId);
    }
}
