using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.HangfireJobs.Extensions;
using OneTwoOne.Module.HangfireJobs.Internal;

namespace OneTwoOne.Module.HangfireJobs
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var configuration = sp.GetRequiredService<IConfiguration>();

            services.AddHangfireService(config =>
            {
                config.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));
            });

            //overwrite HangfireBaseOptions
            services.PostConfigure<HangfireConfigureOptions>(o =>
            {
                o.Dasbhoard.AuthorizationCallback = httpContext =>
                {
                    var user = httpContext.User;
                    return user.Identity.IsAuthenticated && user.IsInRole("admin");
                };
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHangfire();
            app.InitializeHangfireJobs();
        }
    }
}
