using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Contacts.Data
{
    public class ContactCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("GoogleAppKey") { Module = "Contact", IsVisibleInCommonSettingPage = false, Value = "" }
            );
        }
    }
}
