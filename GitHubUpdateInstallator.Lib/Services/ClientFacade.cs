
using GitHubUpdateInstallator.Lib.Models;
using System.Diagnostics;

namespace GitHubUpdateInstallator.Lib.Services
{
    public class ClientFacade : IClientFacade
    {
        public async Task<Update?> CheckUpdate(IAppGitHubUpdater? appGitHubUpdater = null)
            => await (appGitHubUpdater ?? new AppGitHubUpdater())
                .CheckNewUpdate(await new InstallatorConfigJsonWorker()
                                    .GetConfig("InstallatorConfig.json"),
                               (await new AppInfoJsonSevice().GetCurrentUpdate(Directory
                                    .GetCurrentDirectory() + "/" + "AppUpdate")).Version);

        public void Update()
        {
            Process.Start("GitHubUpdateInstallator.App.exe", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
