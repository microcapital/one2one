﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Catalog.Areas.Catalog.ViewModels;
using OneTwoOne.Module.Catalog.Models;
using OneTwoOne.Module.Core.Areas.Core.ViewModels;
using OneTwoOne.Module.Core.Services;

namespace OneTwoOne.Module.Catalog.Areas.Catalog.Components
{
    public class CategoryWidgetViewComponent : ViewComponent
    {
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IMediaService _mediaService;

        public CategoryWidgetViewComponent(IRepository<Category> categoriesRepository, IMediaService mediaService)
        {
            _categoriesRepository = categoriesRepository;
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new CategoryWidgetComponentVm() {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
            };
            var settings = JsonConvert.DeserializeObject<CategoryWidgetSettings>(widgetInstance.Data);
            if (settings != null)
            {
                var category = _categoriesRepository.Query()
                    .Include(c => c.ThumbnailImage)
                    .FirstOrDefault(c => c.Id == settings.CategoryId);
                model.Category = new CategoryThumbnail() {
                    Id = category.Id,
                    Description = category.Description,
                    Name = category.Name,
                    Slug = category.Slug,
                    ThumbnailImage = category.ThumbnailImage,
                    ThumbnailUrl = _mediaService.GetThumbnailUrl(category.ThumbnailImage)
                };
            }

            return View(this.GetViewPath(), model);
        }
    }
}
