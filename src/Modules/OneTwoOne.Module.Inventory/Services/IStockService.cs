using OneTwoOne.Module.Inventory.Models;
using System.Threading.Tasks;

namespace OneTwoOne.Module.Inventory.Services
{
    public interface IStockService
    {
        Task AddAllProduct(Warehouse warehouse);

        Task UpdateStock(StockUpdateRequest stockUpdateRequest);
    }
}
