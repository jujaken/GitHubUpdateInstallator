using GitHubUpdateInstallator.Lib.Services;

IClientFacade clientFacade = new ClientFacade();

Console.WriteLine("Yey!");
Console.WriteLine($"Hello, I'm {(await clientFacade.GetCurrentUpdate()).Version}");

if (await clientFacade.CheckUpdate() != null)
{
    Console.WriteLine("New update!");
    clientFacade.Update();
}
else
    Console.WriteLine("No update");