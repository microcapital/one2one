using System.Threading.Tasks;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Orders.Models;

namespace OneTwoOne.Module.Orders.Services
{
    public interface IOrderEmailService
    {
        Task SendEmailToUser(User user, Order order);
    }
}
