using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Modules;

namespace OneTwoOne.Module.PaymentMomo
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.paymentMomo");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
