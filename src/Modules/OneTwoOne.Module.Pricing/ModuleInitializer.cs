using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Pricing.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.Pricing
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICouponService, CouponService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.pricing");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
