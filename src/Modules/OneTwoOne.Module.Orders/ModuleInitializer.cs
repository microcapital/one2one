using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Module.Orders.Events;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Orders.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.Orders
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderEmailService, OrderEmailService>();
            services.AddHostedService<OrderCancellationBackgroundService>();
            services.AddTransient<INotificationHandler<OrderChanged>, OrderChangedCreateOrderHistoryHandler>();
            services.AddTransient<INotificationHandler<OrderCreated>, OrderCreatedCreateOrderHistoryHandler>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.orders");
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
        }
    }
}
