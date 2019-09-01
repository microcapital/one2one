using System.Threading.Tasks;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Notifications.Models;
using OneTwoOne.Module.Notifications.Services;

namespace OneTwoOne.Module.Notifications.Notifiers
{
    public class TestNotifier : ITestNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;

        public TestNotifier(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public async Task WelcomeToTheApplicationAsync(long userId)
        {
            // Publish to new user
            await _notificationPublisher.PublishAsync(
                "WelcomeToTheApplication",
                new MessageNotificationData("Welcome to store."),
                severity: NotificationSeverity.Success,
                userIds: new[] { userId }
                );
        }

        public async Task NewUserRegisteredAsync(User user)
        {
            var notificationData = new MessageNotificationData("New user registered.");

            notificationData["userName"] = user.UserName;
            notificationData["email"] = user.Email;

            // Publish to all subscribed users
            await _notificationPublisher.PublishAsync(NotificationDefinitions.Names.NewUserRegistered, notificationData);
        }

        //This is for test purposes
        public async Task SendMessageAsync(long userId, string message, NotificationSeverity severity = NotificationSeverity.Info)
        {
            await _notificationPublisher.PublishAsync(
                "SimpleMessage",
                new MessageNotificationData(message),
                severity: severity,
                userIds: new[] { userId }
                );
        }
    }
}
