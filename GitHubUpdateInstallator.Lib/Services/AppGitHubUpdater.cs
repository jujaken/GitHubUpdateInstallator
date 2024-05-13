using GitHubUpdateInstallator.Lib.Extensions;
using GitHubUpdateInstallator.Lib.Models;

namespace GitHubUpdateInstallator.Lib.Services
{
    public class AppGitHubUpdater(HttpClient? client = null) : IAppGitHubUpdater
    {
        private HttpClient client = client ?? new();

        private const string startStr = "/releases/tag/";
        private const string endStr = "\" data-view-component";

        public async Task<bool> CheckNewUpdate(InstallatorConfig cfg, string currentVersion)
        {
            throw new NotImplementedException();
        }

        public async Task Download(InstallatorConfig cfg, string version, string path)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private string ExctractVersion(string content)
        {
            var startIndex = content.StartIndexOf(startStr) + startStr.Length;
            var endIndex = content.Substring(startIndex).StartIndexOf(endStr);
            return content.Substring(startIndex, endIndex);
        }
    }
}
