using OneTwoOne.Infrastructure.Models;

namespace OneTwoOne.Infrastructure.Data
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : IEntityWithTypedId<long>
    {
    }
}
