using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.SampleData.Data;
using OneTwoOne.Module.SampleData.Services;

namespace OneTwoOne.Module.SampleData
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISqlRepository, SqlRepository>();
            services.AddTransient<ISampleDataService, SampleDataService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
