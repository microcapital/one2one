using Microsoft.EntityFrameworkCore;

namespace OneTwoOne.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
