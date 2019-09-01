using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core;
using OneTwoOne.Module.Core.Events;
using OneTwoOne.Module.Notifications.Data;
using OneTwoOne.Module.Notifications.Events;
using OneTwoOne.Module.Notifications.Jobs;
using OneTwoOne.Module.Notifications.Notifiers;
using OneTwoOne.Module.Notifications.Services;
using OneTwoOne.Module.SignalR.RealTime;

namespace OneTwoOne.Module.Notifications
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationRepository, NotificationRepository>();

            services.AddSingleton<INotificationDefinitionManager, NotificationDefinitionManager>();
            services.AddSingleton<IOnlineClientManager, OnlineClientManager>();
            services.AddSingleton<IRealTimeNotifier, SignalRRealTimeNotifier>();

            services.AddTransient<INotificationDistributer, NotificationDistributer>();
            services.AddTransient<INotificationPublisher, NotificationPublisher>();
            services.AddTransient<INotificationSubscriptionManager, NotificationSubscriptionManager>();
            services.AddTransient<IUserNotificationManager, UserNotificationManager>();

            services.AddTransient<ITestNotifier, TestNotifier>();
            services.AddTransient<INotificationHandler<UserSignedIn>, UserSignedInHandler>();
            services.AddTransient<NotificationDistributionJob>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.AddSettingDefinitionItems(SettingDefinitions.DefaultItems());
            app.AddNotificationDefinitionItems(NotificationDefinitions.DefaultItems());
        }
    }
}
