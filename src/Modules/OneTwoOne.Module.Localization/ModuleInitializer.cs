using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core.Events;
using OneTwoOne.Module.Localization.Events;
using OneTwoOne.Module.Localization.Services;
using OneTwoOne.Module.Core.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.Localization
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationHandler<UserSignedIn>, UserSignedInHandler>();
            services.AddTransient<IContentLocalizationService, ContentLocalizationService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.localization");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
