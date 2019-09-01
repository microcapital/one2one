using MediatR;

namespace OneTwoOne.Module.Core.Events
{
    public class UserSignedIn : INotification
    {
        public long UserId { get; set; }
    }
}
