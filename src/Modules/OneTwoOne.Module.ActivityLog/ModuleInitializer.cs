using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.ActivityLog.Data;
using OneTwoOne.Module.ActivityLog.Events;
using OneTwoOne.Module.Core.Events;

namespace OneTwoOne.Module.ActivityLog
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IActivityTypeRepository, ActivityRepository>();
            services.AddTransient<INotificationHandler<EntityViewed>, EntityViewedHandler>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.activityLog");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
