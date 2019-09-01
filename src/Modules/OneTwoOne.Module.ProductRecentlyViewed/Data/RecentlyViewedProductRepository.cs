using System.Linq;
using OneTwoOne.Module.Catalog.Models;
using OneTwoOne.Module.Core.Data;
using OneTwoOne.Module.ProductRecentlyViewed.Models;

namespace OneTwoOne.Module.ProductRecentlyViewed.Data
{
    public class RecentlyViewedProductRepository: Repository<Product>, IRecentlyViewedProductRepository
    {
        private const long EntityViewedActivityTypeId = 1;
        private const long ProductEntityTypeId = 3;

        public RecentlyViewedProductRepository(OneTwoOneDbContext context) : base(context)
        {
        }

        public IQueryable<Product> GetRecentlyViewedProduct(long userId)
        {
            return from product in DbSet
                join e in Context.Set<RecentlyViewedProduct>() on product.Id equals e.ProductId
                   where e.UserId == userId
                   orderby e.LatestViewedOn descending
                select product;
        }
    }
}
