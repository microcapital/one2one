﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Orders.Events;
using OneTwoOne.Module.Shipments.Models;

namespace OneTwoOne.Module.Shipments.Events
{
    public class OrderDetailGotHandler : INotificationHandler<OrderDetailGot>
    {
        private readonly IRepository<ShipmentItem> _shipmentItemRepository;

        public OrderDetailGotHandler(IRepository<ShipmentItem> shipmentItemRepository)
        {
            _shipmentItemRepository = shipmentItemRepository;
        }

        public async Task Handle(OrderDetailGot orderDetailGot, CancellationToken cancellationToken)
        {
            var shippedItems = await _shipmentItemRepository.Query()
                .Where(x => x.Shipment.OrderId == orderDetailGot.OrderDetailVm.Id)
                .ToListAsync();

            if (!shippedItems.Any())
            {
                return;
            }

            foreach (var item in orderDetailGot.OrderDetailVm.OrderItems)
            {
                var shippedItemsByProduct = shippedItems.Where(x => x.ProductId == item.ProductId);
                foreach (var shippedItemByProduct in shippedItemsByProduct)
                {
                    item.ShippedQuantity = item.ShippedQuantity + shippedItemByProduct.Quantity;
                }
            }
        }
    }
}
