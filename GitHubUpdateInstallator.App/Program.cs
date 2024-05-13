using GitHubUpdateInstallator.Lib.Services;

#if !DEBUG
try
{
#endif

IInstallatorConfigWorker worker = new InstallatorConfigJsonWorker();
var cfg = await worker.GetConfig("InstallatorConfig.json");

IAppGitHubUpdater appGitHubUpdater = new AppGitHubUpdater();
var update = await appGitHubUpdater.GetLastUpdate(cfg);
Console.WriteLine(update.Version);

#if !DEBUG

}
catch
{
    Console.WriteLine("bad config, bruh");
}
#endif
