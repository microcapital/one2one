using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Orders.Events;
using OneTwoOne.Module.Shipments.Events;
using OneTwoOne.Module.Shipments.Services;

namespace OneTwoOne.Module.Shipments
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationHandler<OrderDetailGot>, OrderDetailGotHandler>();
            services.AddTransient<IShipmentService, ShipmentService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
