using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Inventory.Models;

namespace OneTwoOne.Module.Inventory.Data
{
    public class InventoryCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse(1) { Name = "Default warehouse", AddressId = 1 });
        }
    }
}
