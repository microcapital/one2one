using System.Threading.Tasks;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Core.Services;
using OneTwoOne.Module.Orders.Models;

namespace OneTwoOne.Module.Orders.Services
{
    public class OrderEmailService : IOrderEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly IRazorViewRenderer _viewRender;
        public OrderEmailService(IEmailSender emailSender, IRazorViewRenderer viewRender)
        {
            _emailSender = emailSender;
            _viewRender = viewRender;
        }

        public async Task SendEmailToUser(User user, Order order)
        {
            var emailBody = await _viewRender.RenderViewToStringAsync("/Areas/Orders/Views/EmailTemplates/OrderEmailToCustomer.cshtml", order);
            var emailSubject = $"Order information #{order.Id}";
            await _emailSender.SendEmailAsync(user.Email, emailSubject, emailBody, true);
        }
    }
}
