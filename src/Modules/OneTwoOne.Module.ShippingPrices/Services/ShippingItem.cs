using OneTwoOne.Module.Catalog.Models;

namespace OneTwoOne.Module.ShippingPrices.Services
{
    public class ShippingItem
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
