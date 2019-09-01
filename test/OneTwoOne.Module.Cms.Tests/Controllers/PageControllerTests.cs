using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Cms.Areas.Cms.Controllers;
using OneTwoOne.Module.Cms.Areas.Cms.ViewModels;
using OneTwoOne.Module.Cms.Models;
using OneTwoOne.Module.Core.Services;
using Xunit;

namespace OneTwoOne.Module.Cms.Tests.Controllers
{
    public class PageControllerTests
    {
        [Fact]
        public void PageDetail_ShouldReturns_CorrectModelType()
        {
            var mock = new Mock<IRepository<Page>>();
            mock.Setup(x => x.Query()).Returns(new List<Page>() { new Page() { Name = "Page" } }.AsQueryable());
            var pageController = new PageController(mock.Object, new Mock<IContentLocalizationService>().Object);

            var result = pageController.PageDetail(It.IsAny<long>()) as ViewResult;
            
            Assert.IsType<PageVm>(result?.ViewData.Model);
        }
    }
}
