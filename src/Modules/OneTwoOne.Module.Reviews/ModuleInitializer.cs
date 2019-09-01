using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Reviews.Data;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.Reviews
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.reviews");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
