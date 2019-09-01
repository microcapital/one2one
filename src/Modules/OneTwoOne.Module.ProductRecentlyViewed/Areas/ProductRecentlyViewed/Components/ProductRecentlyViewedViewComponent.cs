using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Catalog.Areas.Catalog.ViewModels;
using OneTwoOne.Module.Catalog.Models;
using OneTwoOne.Module.Catalog.Services;
using OneTwoOne.Module.Core.Extensions;
using OneTwoOne.Module.Core.Services;
using OneTwoOne.Module.ProductRecentlyViewed.Data;

namespace OneTwoOne.Module.ProductRecentlyViewed.Areas.ProductRecentlyViewed.Components
{
    public class ProductRecentlyViewedViewComponent : ViewComponent
    {
        private readonly IRecentlyViewedProductRepository _productRepository;
        private readonly IMediaService _mediaService;
        private readonly IProductPricingService _productPricingService;
        private readonly IWorkContext _workContext;
        private readonly IContentLocalizationService _contentLocalizationService;

        public ProductRecentlyViewedViewComponent(IRecentlyViewedProductRepository productRepository,
            IMediaService mediaService,
            IProductPricingService productPricingService,
            IContentLocalizationService contentLocalizationService,
            IWorkContext workContext)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
            _workContext = workContext;
        }

        // TODO Number of items to config
        public async Task<IViewComponentResult> InvokeAsync(long? productId, int itemCount = 4)
        {
            var user = await _workContext.GetCurrentUser();
            IQueryable<Product> query = _productRepository.GetRecentlyViewedProduct(user.Id)
                .Include(x => x.ThumbnailImage);
            if (productId.HasValue)
            {
                query = query.Where(x => x.Id != productId.Value);
            }
            
            var model = query.Take(itemCount)
                .Select(x => ProductThumbnail.FromProduct(x)).ToList();

            foreach (var product in model)
            {
                product.Name = _contentLocalizationService.GetLocalizedProperty(nameof(Product), product.Id, nameof(product.Name), product.Name);
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                product.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
            }

            return View(this.GetViewPath(), model);
        }
    }
}
