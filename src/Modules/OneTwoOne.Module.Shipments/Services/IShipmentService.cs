using System.Collections.Generic;
using System.Threading.Tasks;
using OneTwoOne.Infrastructure;
using OneTwoOne.Module.Shipments.Models;

namespace OneTwoOne.Module.Shipments.Services
{
    public interface IShipmentService
    {
        Task<IList<ShipmentItemVm>> GetShipmentItem(long orderId);

        Task<IList<ShipmentItemVm>> GetItemToShip(long orderId, long warehouseId);

        Task<Result> CreateShipment(Shipment shipment);
    }
}
