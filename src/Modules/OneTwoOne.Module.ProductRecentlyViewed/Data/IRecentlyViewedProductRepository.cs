using System.Linq;
using OneTwoOne.Module.Catalog.Models;

namespace OneTwoOne.Module.ProductRecentlyViewed.Data
{
    public interface IRecentlyViewedProductRepository
    {
        IQueryable<Product> GetRecentlyViewedProduct(long userId);
    }
}
