using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Modules;
using OneTwoOne.Module.Core.Extensions;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Core.Services;

namespace OneTwoOne.Module.Core
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEntityService, EntityService>();
            serviceCollection.AddTransient<IMediaService, MediaService>();
            serviceCollection.AddTransient<IThemeService, ThemeService>();
            serviceCollection.AddTransient<ITokenService, TokenService>();
            serviceCollection.AddTransient<IWidgetInstanceService, WidgetInstanceService>();
            serviceCollection.AddScoped<SignInManager<User>, OneTwoOneSignInManager<User>>();
            serviceCollection.AddScoped<IWorkContext, WorkContext>();
            serviceCollection.AddScoped<ISmsSender, SmsSender>();
            serviceCollection.AddSingleton<SettingDefinitionProvider>();
            serviceCollection.AddScoped<ISettingService, SettingService>();
            serviceCollection.AddScoped<ICurrencyService, CurrencyService>();

            GlobalConfiguration.RegisterAngularModule("oneTwoOneAdmin.core");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
