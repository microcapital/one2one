using System.Threading.Tasks;
using OneTwoOne.Module.Catalog.Models;

namespace OneTwoOne.Module.Catalog.Services
{
    public interface IProductService
    {
        void Create(Product product);

        void Update(Product product);

        Task Delete(Product product);
    }
}
