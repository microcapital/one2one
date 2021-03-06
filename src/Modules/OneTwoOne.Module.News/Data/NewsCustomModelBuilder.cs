﻿using OneTwoOne.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OneTwoOne.Module.News.Models;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.News.Data
{
    public class NewsCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsItemCategory>(b =>
            {
                b.HasKey(ur => new { ur.CategoryId, ur.NewsItemId });
                b.HasOne(ur => ur.Category).WithMany(r => r.NewsItems).HasForeignKey(r => r.CategoryId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(ur => ur.NewsItem).WithMany(u => u.Categories).HasForeignKey(u => u.NewsItemId).OnDelete(DeleteBehavior.Cascade);
                b.ToTable("News_NewsItemCategory");
            });

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("News.PageSize") { Module = "News", IsVisibleInCommonSettingPage = true, Value = "10" }
            );

            modelBuilder.Entity<EntityType>().HasData(
                new EntityType("NewsCategory") { AreaName = "News", RoutingController = "NewsCategory", RoutingAction = "NewsCategoryDetail", IsMenuable = true },
                new EntityType("NewsItem") { AreaName = "News", RoutingController = "NewsItem", RoutingAction = "NewsItemDetail", IsMenuable = false }
            );
        }
    }
}
