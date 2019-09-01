using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.SignalR.Hubs;
using OneTwoOne.Module.SignalR.RealTime;

namespace OneTwoOne.Module.SignalR
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSignalR();
            serviceCollection.AddSingleton<IOnlineClientManager, OnlineClientManager>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<CommonHub>("/signalr");
            });
        }
    }
}
