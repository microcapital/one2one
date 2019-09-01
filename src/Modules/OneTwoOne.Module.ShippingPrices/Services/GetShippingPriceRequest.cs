using System.Collections.Generic;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Shipping.Models;

namespace OneTwoOne.Module.ShippingPrices.Services
{
    public class GetShippingPriceRequest
    {
        public Address ShippingAddress { get; set; }

        public Address WarehouseAddress { get; set; }

        public IList<ShippingItem> ShippingItem { get; set; } = new List<ShippingItem>();

        public decimal OrderAmount { get; set; }
    }
}
