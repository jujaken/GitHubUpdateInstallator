using GitHubUpdateInstallator.Lib.Models;
using System.Text.Json;

namespace GitHubUpdateInstallator.Lib.Services
{
    public class AppInfoJsonSevice : IAppInfoSevice
    {
        public async Task<Update> SetDefault(string path)
        {
            var update = new Update();
            await SetCurrentUpdate(path, update);
            return update;
        }

        public async Task<Update> GetCurrentUpdate(string path)
        {
            if (!File.Exists(path))
                return await SetDefault(path);

            return JsonSerializer.Deserialize<Update>(await File.ReadAllTextAsync(path))
                ?? await SetDefault(path);
        }

        public async Task SetCurrentUpdate(string path, Update update)
        {
            await File.WriteAllTextAsync(path, JsonSerializer.Serialize(update));
        }
    }
}
