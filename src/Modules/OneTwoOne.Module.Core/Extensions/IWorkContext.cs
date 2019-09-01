using System.Threading.Tasks;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Core.Extensions
{
    public interface IWorkContext
    {
        Task<User> GetCurrentUser();
    }
}
