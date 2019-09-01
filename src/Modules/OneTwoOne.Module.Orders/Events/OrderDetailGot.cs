using MediatR;
using OneTwoOne.Module.Orders.Areas.Orders.ViewModels;

namespace OneTwoOne.Module.Orders.Events
{
    public class OrderDetailGot : INotification
    {
        public OrderDetailVm OrderDetailVm { get; set; }
    }
}
