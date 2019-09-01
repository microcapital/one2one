using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Cms.Events;
using OneTwoOne.Module.Cms.Services;
using OneTwoOne.Module.Core.Events;

namespace OneTwoOne.Module.Cms
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationHandler<EntityDeleting>, EntityDeletingHandler>();
            services.AddTransient<IPageService, PageService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.cms");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
