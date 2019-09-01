using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.News.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.News
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INewsItemService, NewsItemService>();
            services.AddTransient<INewsCategoryService, NewsCategoryService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.news");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
