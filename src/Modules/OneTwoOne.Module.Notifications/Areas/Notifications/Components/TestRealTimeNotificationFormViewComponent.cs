using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Core.Models;
using OneTwoOne.Module.Notifications.Areas.Notifications.ViewModels;
using OneTwoOne.Module.SignalR.RealTime;

namespace OneTwoOne.Module.Notifications.Areas.Notifications.Components
{
    public class TestRealTimeNotificationFormViewComponent : ViewComponent
    {
        private readonly IRepository<User> _userRepository;
        private readonly IOnlineClientManager _onlineClientManager;
        public TestRealTimeNotificationFormViewComponent(IRepository<User> userRepository, IOnlineClientManager onlineClientManager)
        {
            _userRepository = userRepository;
            _onlineClientManager = onlineClientManager;
        }

        public IViewComponentResult Invoke()
        {
            var onlineUserIds = _onlineClientManager.GetAllClients().Select(o => o.UserId.Value).ToList();

            var users = _userRepository.Query().Where(u =>
                onlineUserIds.Contains(u.Id)).Select(u =>
                new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.Id.ToString()
                }).ToList();

            var vm = new TestNotificationVm
            {
                OnlineUsers = users
            };

            return View(this.GetViewPath(), vm);
        }
    }
}
