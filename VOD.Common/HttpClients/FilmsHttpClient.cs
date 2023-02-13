namespace VOD.Common.HttpClients;

public class FilmsHttpClient
{
	public readonly HttpClient Client;
	public FilmsHttpClient(HttpClient client)
	{
		Client= client;
	}
}
