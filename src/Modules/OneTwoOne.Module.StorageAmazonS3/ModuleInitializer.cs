using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core.Services;

namespace OneTwoOne.Module.StorageAmazonS3
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStorageService, S3StorageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }
    }
}
