using System.Threading.Tasks;
using OneTwoOne.Module.SampleData.Areas.SampleData.ViewModels;

namespace OneTwoOne.Module.SampleData.Services
{
    public interface ISampleDataService
    {
        Task ResetToSampleData(SampleDataOption model);
    }
}
