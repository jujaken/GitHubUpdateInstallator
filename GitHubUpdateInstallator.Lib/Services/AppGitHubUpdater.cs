using GitHubUpdateInstallator.Lib.Extensions;
using GitHubUpdateInstallator.Lib.Models;
using Microsoft.VisualBasic.FileIO;
using System.IO.Compression;

namespace GitHubUpdateInstallator.Lib.Services
{
    public class AppGitHubUpdater(HttpClient? client = null) : IAppGitHubUpdater
    {
        private HttpClient client = client ?? new();

        private const string startStr = "/releases/tag/";
        private const string endStr = "\" data-view-component";
        private const string tmpDirPath = "updater-tmp/";

        public async Task<Update?> CheckNewUpdate(InstallatorConfig cfg, string currentVersion)
        {
            var lastUpdate = await GetLastUpdate(cfg);
            if (lastUpdate == null) return null;
            Console.WriteLine(lastUpdate.Version);

            var lastSplit = lastUpdate.Version.Split('.');
            var currentSplit = currentVersion.Split('.');

            for (int i = 1; i < lastSplit.Length; i++) // skip 'v'
            {
                if (Convert.ToInt32(lastSplit[i]) > Convert.ToInt32(currentSplit[i]))
                    return lastUpdate;
            }

            return null;
        }

        public async Task Download(InstallatorConfig cfg, string version, string path)
        {
            var zip = cfg.ZipName + ".zip";
            var zipFile = tmpDirPath + zip;

            Directory.CreateDirectory(tmpDirPath);

            using var fs = File.OpenWrite(zipFile);
            await (await client.GetAsync(cfg.RepoUrl + "/releases/download/v1.0.0/" + zip))
                .Content.CopyToAsync(fs);
            fs.Close();

            ZipFile.ExtractToDirectory(zipFile, tmpDirPath, true);
            FileSystem.CopyDirectory(tmpDirPath + cfg.ZipName, path, true);
        }

        public async Task<Update> GetLastUpdate(InstallatorConfig cfg)
        {
            var result = await client.GetAsync(cfg.RepoUrl + "/tags");
            var content = await result.Content.ReadAsStringAsync();
            var version = ExctractVersion(content);
            return new Update() { Version = version, IsLast = true };
        }

        public async Task<bool> UpdateApp(InstallatorConfig cfg, string currentVersion, string path)
        {
            var update = await CheckNewUpdate(cfg, currentVersion);
            if (update is null)
                return false;

            await Download(cfg, update.Version, path);
            return true;
        }

        private string ExctractVersion(string content)
        {
            var startIndex = content.StartIndexOf(startStr) + startStr.Length;
            var endIndex = content.Substring(startIndex).StartIndexOf(endStr);
            return content.Substring(startIndex, endIndex);
        }
    }
}
