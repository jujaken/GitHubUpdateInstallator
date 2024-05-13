using GitHubUpdateInstallator.Lib.Models;

namespace GitHubUpdateInstallator.Lib.Services
{
    public interface IAppGitHubUpdater
    {
        /// <summary>
        /// получает последние обновление с github
        /// </summary>
        /// <returns></returns>
        Task<Update> GetLastUpdate(InstallatorConfig cfg);

        /// <summary>
        /// устанавливает именно данную версию
        /// </summary>
        /// <param name="repoUrl"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        Task Download(InstallatorConfig cfg, string version, string path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repoUrl"></param>
        /// <param name="currentVersion"></param>
        /// <returns>есть ли новый апдейт</returns>
        Task<Update?> CheckNewUpdate(InstallatorConfig cfg, string currentVersion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repoUrl"></param>
        /// <param name="currentVersion"></param>
        /// <returns>было ли обновлено приложение</returns>
        Task<bool> UpdateApp(InstallatorConfig cfg, string currentVersion, string path);
    }
}