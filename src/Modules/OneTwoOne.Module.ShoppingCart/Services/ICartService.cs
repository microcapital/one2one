using System.Linq;
using System.Threading.Tasks;
using OneTwoOne.Infrastructure;
using OneTwoOne.Module.Pricing.Services;
using OneTwoOne.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using OneTwoOne.Module.ShoppingCart.Models;

namespace OneTwoOne.Module.ShoppingCart.Services
{
    public interface ICartService
    {
        Task<Result> AddToCart(long customerId, long productId, int quantity);

        Task<Result> AddToCart(long customerId, long createdById, long productId, int quantity);

        IQueryable<Cart> Query();

        Task<Cart> GetActiveCart(long customerId);

        Task<Cart> GetActiveCart(long customerId, long createdById);

        Task<CartVm> GetActiveCartDetails(long customerId);

        Task<CartVm> GetActiveCartDetails(long customerId, long createdById);

        Task<CouponValidationResult> ApplyCoupon(long cartId, string couponCode);

        Task MigrateCart(long fromUserId, long toUserId);
    }
}
