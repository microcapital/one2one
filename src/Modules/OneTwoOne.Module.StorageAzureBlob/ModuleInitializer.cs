using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core.Services;

namespace OneTwoOne.Module.StorageAzureBlob
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStorageService, AzureBlobStorageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }
    }
}
