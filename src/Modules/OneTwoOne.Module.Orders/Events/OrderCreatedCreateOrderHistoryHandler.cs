﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Orders.Models;

namespace OneTwoOne.Module.Orders.Events
{
    public class OrderCreatedCreateOrderHistoryHandler : INotificationHandler<OrderCreated>
    {
        private readonly IRepository<OrderHistory> _orderHistoryRepository;

    public OrderCreatedCreateOrderHistoryHandler(IRepository<OrderHistory> orderHistoryRepository)
    {
        _orderHistoryRepository = orderHistoryRepository;
    }

    public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
    {
        var orderHistory = new OrderHistory
        {
            OrderId = notification.OrderId,
            CreatedOn = DateTimeOffset.Now,
            CreatedById = notification.UserId,
            NewStatus = OrderStatus.New,
            Note = notification.Note,
        };

        if (notification.Order != null)
        {
            orderHistory.OrderSnapshot = JsonConvert.SerializeObject(notification.Order);
        }

        _orderHistoryRepository.Add(orderHistory);
        await _orderHistoryRepository.SaveChangesAsync();
    }
}
}
