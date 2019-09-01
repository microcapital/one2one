using System.Threading.Tasks;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Vendors.Services
{
    public interface IVendorService
    {
        Task Create(Vendor brand);

        Task Update(Vendor brand);

        Task Delete(long id);

        Task Delete(Vendor brand);
    }
}
