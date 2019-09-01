namespace OneTwoOne.Module.Core.Services
{
    public interface IPdfConverter
    {
        byte[] Convert(string htmlContent);
    }
}
