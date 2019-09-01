using System.Threading.Tasks;
using OneTwoOne.Module.Shipping.Models;

namespace OneTwoOne.Module.ShippingPrices.Services
{
    public interface IShippingPriceServiceProvider
    {
        Task<GetShippingPriceResponse> GetShippingPrices(GetShippingPriceRequest request, ShippingProvider provider);
    }
}
