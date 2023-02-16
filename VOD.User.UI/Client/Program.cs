namespace VOD.User.UI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp =>
        builder.Services.AddHttpClient<FilmsHttpClient>(client =>
        client.BaseAddress = new Uri("https://localhost:5000/api/")));

        await builder.Build().RunAsync();
    }
}