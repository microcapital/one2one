using System.Collections.Generic;
using OneTwoOne.Module.ShippingPrices.Services;
using OneTwoOne.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace OneTwoOne.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderTaxAndShippingPriceVm
    {
        public bool IsProductPriceIncludedTax { get; set; }

        public IList<ShippingPrice> ShippingPrices { get; set; }

        public string SelectedShippingMethodName { get; set; }

        public CartVm Cart { get; set; }
    }
}
