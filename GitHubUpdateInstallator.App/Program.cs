using GitHubUpdateInstallator.Lib.Services;

#if !DEBUG
try
{
#endif

var dir = Directory.GetCurrentDirectory();

IInstallatorConfigWorker worker = new InstallatorConfigJsonWorker();
var cfg = await worker.GetConfig("InstallatorConfig.json");

IAppInfoSevice appInfoService = new AppInfoJsonSevice();
var update = await appInfoService.GetCurrentUpdate(dir + "/" + "AppUpdate");

IAppGitHubUpdater appGitHubUpdater = new AppGitHubUpdater();
await appGitHubUpdater.Download(cfg, update.Version, dir);

#if !DEBUG

}
catch
{
    Console.WriteLine("bad config, bruh");
}
#endif
