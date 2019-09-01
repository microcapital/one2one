using System.Threading.Tasks;
using OneTwoOne.Infrastructure;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Orders.Areas.Orders.ViewModels;
using OneTwoOne.Module.Orders.Models;

namespace OneTwoOne.Module.Orders.Services
{
    public interface IOrderService
    {
        Task<Result<Order>> CreateOrder(long cartId, string paymentMethod, decimal paymentFeeAmount, OrderStatus orderStatus = OrderStatus.New);

        Task<Result<Order>> CreateOrder(long cartId, string paymentMethod, decimal paymentFeeAmount, string shippingMethod, Address billingAddress, Address shippingAddress, OrderStatus orderStatus = OrderStatus.New);

        void CancelOrder(Order order);

        Task<decimal> GetTax(long cartId, string countryId, long stateOrProvinceId, string zipCode);

        Task<OrderTaxAndShippingPriceVm> UpdateTaxAndShippingPrices(long cartId, TaxAndShippingPriceRequestVm model);
    }
}
