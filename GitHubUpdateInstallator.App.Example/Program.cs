using GitHubUpdateInstallator.Lib.Models;
using GitHubUpdateInstallator.Lib.Services;

IClientFacade clientFacade = new ClientFacade();

Console.WriteLine("Yey!");
Console.WriteLine($"Hello, I'm {(await clientFacade.GetCurrentUpdate()).Version}");

Update? update = null;
try
{
    update = await clientFacade.CheckUpdate();
}
catch (HttpRequestException)
{
    Console.WriteLine("[error] No connection!");
}

if (update == null)
{
    Console.WriteLine("New update!");
    clientFacade.Update();
}
else
    Console.WriteLine("No update");