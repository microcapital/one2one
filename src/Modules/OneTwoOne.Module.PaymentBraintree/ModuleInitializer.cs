using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.PaymentBraintree.Services;

namespace OneTwoOne.Module.PaymentBraintree
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBraintreeConfiguration, BraintreeConfiguration>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.paymentBraintree");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
