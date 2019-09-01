using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Localization;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Localization.Data
{
    public class LocalizationCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culture>().ToTable("Localization_Culture");
            modelBuilder.Entity<Resource>().ToTable("Localization_Resource");
            modelBuilder.Entity<LocalizedContentProperty>().ToTable("Localization_LocalizedContentProperty");

            modelBuilder.Entity<Culture>().HasData(
               new Culture(GlobalConfiguration.DefaultCulture) { Name = "English (US)" }
            );

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("Localization.LocalizedConentEnable") { Module = "Localization", IsVisibleInCommonSettingPage = true, Value = "true" });
        }
    }
}
