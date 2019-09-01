using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Comments.Data
{
    public class CommentCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("Catalog.IsCommentsRequireApproval") { Module = "Catalog", IsVisibleInCommonSettingPage = true, Value = "true" }
            );
        }
    }
}
