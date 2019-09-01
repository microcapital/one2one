using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Catalog.Data;
using OneTwoOne.Module.Catalog.Events;
using OneTwoOne.Module.Catalog.Services;
using OneTwoOne.Module.Core.Events;

namespace OneTwoOne.Module.Catalog
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductTemplateProductAttributeRepository, ProductTemplateProductAttributeRepository>();
            services.AddTransient<INotificationHandler<ReviewSummaryChanged>, ReviewSummaryChangedHandler>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductPricingService, ProductPricingService>();
            services.AddTransient<IProductService, ProductService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.catalog");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
