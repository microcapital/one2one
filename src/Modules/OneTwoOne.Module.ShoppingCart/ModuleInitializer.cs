using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core.Events;
using OneTwoOne.Module.ShoppingCart.Services;
using OneTwoOne.Module.ShoppingCart.Events;

namespace OneTwoOne.Module.ShoppingCart
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<INotificationHandler<UserSignedIn>, UserSignedInHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
