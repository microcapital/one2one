using System.Threading.Tasks;
using OneTwoOne.Module.News.Models;

namespace OneTwoOne.Module.News.Services
{
    public interface INewsCategoryService
    {
        Task Create(NewsCategory category);

        Task Update(NewsCategory category);

        Task Delete(long id);

        Task Delete(NewsCategory category);
    }
}
