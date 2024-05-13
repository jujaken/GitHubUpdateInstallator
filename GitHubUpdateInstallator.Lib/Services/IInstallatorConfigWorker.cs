using GitHubUpdateInstallator.Lib.Models;

namespace GitHubUpdateInstallator.Lib.Services
{
    public interface IInstallatorConfigWorker
    {
        Task<InstallatorConfig> SetDefault(string path);
        Task<InstallatorConfig> GetConfig(string path);
    }
}