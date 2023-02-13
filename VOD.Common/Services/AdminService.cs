using VOD.Common.HttpClients;

namespace VOD.Common.Services;

public class AdminService
{
	public readonly FilmsHttpClient _http;
	public AdminService(FilmsHttpClient http)
	{
		_http= http;
	}

	//public async Task<List<TDto>> GetAsync<TDto>(string uri)
	//{
	//	try
	//	{
	//		using (var response = await _http.Client.GetAsync(uri))
	//		{
	//			try
	//			{
	//				response.EnsureSuccessStatusCode();
	//			}
	//			catch (Exception ex)
	//			{

	//			}
	//		}
				
	//	}
	//	catch (Exception ex)
	//	{

	//	}
	//}
}
