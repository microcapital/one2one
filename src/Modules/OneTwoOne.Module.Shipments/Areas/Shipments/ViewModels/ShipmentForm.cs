using System.Collections.Generic;
using OneTwoOne.Module.Shipments.Services;

namespace OneTwoOne.Module.Shipments.Areas.Shipments.ViewModels
{
    public class ShipmentForm
    {
        public long OrderId { get; set; }

        public long WarehouseId { get; set; }

        public string TrackingNumber { get; set; }

        public IList<ShipmentItemVm> Items { get; set; } = new List<ShipmentItemVm>();
    }
}
