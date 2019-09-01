using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core.Events;
using OneTwoOne.Module.ProductRecentlyViewed.Data;
using OneTwoOne.Module.ProductRecentlyViewed.Events;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.ProductRecentlyViewed
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRecentlyViewedProductRepository, RecentlyViewedProductRepository>();
            services.AddTransient<INotificationHandler<EntityViewed>, EntityViewedHandler>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.recentlyViewed");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
