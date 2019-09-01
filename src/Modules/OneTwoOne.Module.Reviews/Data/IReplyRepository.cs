using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Reviews.Models;
using System.Linq;

namespace OneTwoOne.Module.Reviews.Data
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IQueryable<ReplyListItemDto> List();
    }
}
