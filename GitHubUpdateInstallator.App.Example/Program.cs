using GitHubUpdateInstallator.Lib.Services;

Console.WriteLine("Hello, I'm v1.0.0");

IClientFacade clientFacade = new ClientFacade();

if (await clientFacade.CheckUpdate() != null)
{
    Console.WriteLine("New update!");
    clientFacade.Update();
}
else
    Console.WriteLine("No update");