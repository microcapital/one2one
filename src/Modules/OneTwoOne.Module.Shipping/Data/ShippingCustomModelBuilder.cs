using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Shipping.Models;

namespace OneTwoOne.Module.Shipping.Data
{
    public class ShippingCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingProvider>().ToTable("Shipping_ShippingProvider");
        }
    }
}
