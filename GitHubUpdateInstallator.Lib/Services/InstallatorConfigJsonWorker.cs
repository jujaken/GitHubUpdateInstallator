using System.Text.Json;
using GitHubUpdateInstallator.Lib.Models;

namespace GitHubUpdateInstallator.Lib.Services
{
    public class InstallatorConfigJsonWorker : IInstallatorConfigWorker
    {
        public async Task<InstallatorConfig> SetDefault(string path)
        {
            var cfg = new InstallatorConfig();
            await File.WriteAllTextAsync(path, JsonSerializer.Serialize(cfg));
            return cfg;
        }
        public async Task<InstallatorConfig> GetConfig(string path)
        {
            if (!File.Exists(path))
                return await SetDefault(path);

            return JsonSerializer.Deserialize<InstallatorConfig>(await File.ReadAllTextAsync(path))
                ?? await SetDefault(path);
        }
    }
}
