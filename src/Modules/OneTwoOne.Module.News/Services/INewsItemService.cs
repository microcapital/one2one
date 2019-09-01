using System.Threading.Tasks;
using OneTwoOne.Module.News.Models;

namespace OneTwoOne.Module.News.Services
{
    public interface INewsItemService
    {
        void Create(NewsItem newsItem);

        void Update(NewsItem newsItem);

        Task Delete(long id);

        Task Delete(NewsItem newsItem);
    }
}
