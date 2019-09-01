using System.Threading.Tasks;
using System.Collections.Generic;
using OneTwoOne.Module.Catalog.Areas.Catalog.ViewModels;
using OneTwoOne.Module.Catalog.Models;

namespace OneTwoOne.Module.Catalog.Services
{
    public interface ICategoryService
    {
        Task<IList<CategoryListItem>> GetAll();

        Task Create(Category category);

        Task Update(Category category);

        Task Delete(Category category);
    }
}
