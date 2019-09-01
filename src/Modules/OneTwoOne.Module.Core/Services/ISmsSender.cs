using System.Threading.Tasks;

namespace OneTwoOne.Module.Core.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}