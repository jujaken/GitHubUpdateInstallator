using GitHubUpdateInstallator.Lib.Models;

namespace GitHubUpdateInstallator.Lib.Services
{
    public interface IAppInfoSevice
    {
        Task<Update> SetDefault(string path);
        Task<Update> GetCurrentUpdate(string path);
        Task SetCurrentUpdate(string path, Update update);
    }
}
