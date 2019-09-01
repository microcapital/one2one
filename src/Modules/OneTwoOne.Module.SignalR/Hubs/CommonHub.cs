using Microsoft.Extensions.Logging;
using OneTwoOne.Module.Core.Extensions;
using OneTwoOne.Module.SignalR.RealTime;

namespace OneTwoOne.Module.SignalR.Hubs
{
    public class CommonHub : OnlineClientHubBase
    {
        public CommonHub(IWorkContext workContext, IOnlineClientManager onlineClientManager) : base(workContext, onlineClientManager)
        {
        }

        public void Register()
        {
            Logger.LogDebug("A client is registered: " + Context.ConnectionId);
        }
    }
}
