using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneTwoOne.Infrastructure.Helpers;
using OneTwoOne.Module.Notifications.Models;

namespace OneTwoOne.Module.Notifications.Areas.Notifications.ViewModels
{
    public class TestNotificationVm
    {
        public string Severity { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }

        public List<SelectListItem> OnlineUsers { get; set; }

        public List<SelectListItem> Severities { get; set; }

        public TestNotificationVm()
        {
            Severities = EnumHelper.ToDictionary(typeof(NotificationSeverity)).Select(s => new SelectListItem(s.Key.ToString(), s.Value)).ToList();
        }
    }
}
