using System.Threading.Tasks;

namespace OneTwoOne.Infrastructure.Web
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
