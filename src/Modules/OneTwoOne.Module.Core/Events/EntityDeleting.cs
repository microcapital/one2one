using MediatR;

namespace OneTwoOne.Module.Core.Events
{
    public class EntityDeleting : INotification
    {
        public long EntityId { get; set; }
    }
}
