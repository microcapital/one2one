﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Vendors.Services;
using OneTwoOne.Infrastructure;

namespace OneTwoOne.Module.Vendors
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IVendorService, VendorService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.vendors");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
