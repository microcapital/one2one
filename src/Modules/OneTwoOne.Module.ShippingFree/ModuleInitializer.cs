using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.ShippingPrices.Services;
using OneTwoOne.Module.ShippingFree.Services;

namespace OneTwoOne.Module.ShippingFree
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IShippingPriceServiceProvider, FreeShippingServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
