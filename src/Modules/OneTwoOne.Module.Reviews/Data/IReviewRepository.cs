using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Reviews.Models;
using System.Linq;

namespace OneTwoOne.Module.Reviews.Data
{
    public interface IReviewRepository : IRepository<Review>
    {
        IQueryable<ReviewListItemDto> List();
    }
}