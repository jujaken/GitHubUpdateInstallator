using GitHubUpdateInstallator.Lib.Services;
using System.Diagnostics;

#if !DEBUG
try
{
#endif

    var dir = Directory.GetCurrentDirectory();

    IInstallatorConfigWorker worker = new InstallatorConfigJsonWorker();
    var cfg = await worker.GetConfig("InstallatorConfig.json");

    IAppInfoSevice appInfoService = new AppInfoJsonSevice();
    var update = await appInfoService.GetCurrentUpdate(dir + "/" + "AppUpdate.json");

    IAppGitHubUpdater appGitHubUpdater = new AppGitHubUpdater();
    await appGitHubUpdater.Download(cfg, update.Version, dir);

    Console.WriteLine();

    Process.Start(args[0]);
    Environment.Exit(0);

    return 0;

#if !DEBUG

}
catch
{
    Console.WriteLine("bad config, bruh");
    return -1;
}

#endif
