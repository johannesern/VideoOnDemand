using System.Text;

namespace VOD.Common.Services;

public class AdminService : IAdminService
{
	public readonly FilmsHttpClient _http;
	public AdminService(FilmsHttpClient http)
	{
		_http = http;
	}

	public async Task<List<TDto>> GetAsync<TDto>(string uri)
	{
		try
		{
			using (var response = await _http.Client.GetAsync(uri))
			{
				try
				{
					response.EnsureSuccessStatusCode();
					var result = JsonSerializer.Deserialize<List<TDto>>(await
					response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
					if (result != null)
						return result;
					else
						return null;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}
		catch (Exception ex)
		{
			return null;
		}
	}

    public async Task<TDto?> SingleAsync<TDto>(string uri)
    {
        try
        {
            using (var response = await _http.Client.GetAsync(uri))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var result = JsonSerializer.Deserialize<TDto>(await
                    response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (result != null)
                        return result;
                    else
                        return default;
                }
                catch (Exception ex)
                {
                    return default;
                }
            }
        }
        catch (Exception ex)
        {
            return default;
        }
    }

	public async Task CreateAsync<TDto>(string uri, TDto dto)
	{
		try
		{
            using StringContent jsonContent = new(
				JsonSerializer.Serialize(dto), 
				Encoding.UTF8,
				"application/json");

			using (HttpResponseMessage response = await _http.Client.PostAsync(uri, jsonContent))
            {
                try
                {
                    response.EnsureSuccessStatusCode();					
                }
                catch (Exception ex) { }
            }
        }
		catch (Exception ex) { }
	}

    public async Task EditAsync<TDto>(string uri, TDto dto)
    {
        
        try
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");


            using (HttpResponseMessage response = await _http.Client.PutAsync(uri, jsonContent))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex) { }
            }
        }
        catch (Exception ex) { }
    }

    public async Task DeleteAsync<TDto>(string uri)
    {

        try
        {
            using (HttpResponseMessage response = await _http.Client.DeleteAsync(uri))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex) { }
            }
        }
        catch (Exception ex) { }
    }

}
