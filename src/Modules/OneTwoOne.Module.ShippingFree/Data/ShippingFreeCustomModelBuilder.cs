using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Shipping.Models;

namespace OneTwoOne.Module.ShippingFree.Data
{
    public class ShippingFreeCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingProvider>().HasData(new ShippingProvider("FreeShip") { Name = "Free Ship", IsEnabled = true, ConfigureUrl = "", ShippingPriceServiceTypeName = "OneTwoOne.Module.ShippingFree.Services.FreeShippingServiceProvider,OneTwoOne.Module.ShippingFree", AdditionalSettings = "{MinimumOrderAmount : 1}", ToAllShippingEnabledCountries = true, ToAllShippingEnabledStatesOrProvinces = true });
        }
    }
}
