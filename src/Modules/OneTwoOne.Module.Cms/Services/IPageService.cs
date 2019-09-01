using System.Threading.Tasks;
using OneTwoOne.Module.Cms.Models;

namespace OneTwoOne.Module.Cms.Services
{
    public interface IPageService
    {
        Task Create(Page page);

        Task Update(Page page);

        Task Delete(Page page);
    }
}
