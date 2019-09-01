using System.Linq;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Comments.Models;

namespace OneTwoOne.Module.Comments.Data
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<CommentListItemDto> List();
    }
}