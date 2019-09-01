using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.ShippingPrices.Services;
using OneTwoOne.Module.ShippingTableRate.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.ShippingTableRate
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IShippingPriceServiceProvider, TableRateShippingServiceProvider>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.shipping-tablerate");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
