using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Models;

namespace OneTwoOne.Module.Core.Data
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
       where T : class, IEntityWithTypedId<long>
    {
        public Repository(OneTwoOneDbContext context) : base(context)
        {
        }
    }
}
