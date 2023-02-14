namespace VOD.Common.HttpClients;

public class FilmsHttpClient
{
	public readonly HttpClient Client;
	public FilmsHttpClient(HttpClient client)
	{
		Client = client;
        //client.BaseAddress = new Uri("https://localhost:5000/api/"));  
        //såhär kan man också göra men då får man ta bort detta ur program.cs
    }
}
