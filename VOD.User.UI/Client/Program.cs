namespace VOD.User.UI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient<FilmsHttpClient>(client =>
            client.BaseAddress = new Uri("https://localhost:5000/api/"));

        builder.Services.AddScoped<IUserService, UserService>();

        await builder.Build().RunAsync();
    }
}