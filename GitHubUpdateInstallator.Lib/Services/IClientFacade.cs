using GitHubUpdateInstallator.Lib.Models;

namespace GitHubUpdateInstallator.Lib.Services
{
    public interface IClientFacade
    {
        Task<Update?> CheckUpdate(IAppGitHubUpdater? appGitHubUpdater = null);
        /// <summary>
        /// приводит к перезапуску приложения
        /// </summary>
        void Update();
    }
}
