using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Tax.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.Tax
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITaxService, TaxService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.tax");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
