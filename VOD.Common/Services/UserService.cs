using System.Net.Http.Json;
using System;

namespace VOD.Common.Services;

public class UserService : IUserService
{
    public readonly FilmsHttpClient _http;
    public UserService(FilmsHttpClient http) => _http = http;

    public async Task<List<FilmDTO>> GetFilmsAsync()
    {
        try
        {            
            using var response = await _http.Client.GetAsync("films"); //?free={freeOnly}
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<FilmDTO>>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? new List<FilmDTO>();
        }
        catch
        {
            throw;
        }
    }

    public async Task<FilmDTO> GetFilmAsync(int? id)
    {
        try
        {
            if (id <= 0) return new();

            using var response = await _http.Client.GetAsync($"films/{id}");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<FilmDTO>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? default;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<SimilarFilmsDTO>> GetSimilarAsync()
    {
        try
        {
            using var response = await _http.Client.GetAsync("similarfilms"); //?free={freeOnly}
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<SimilarFilmsDTO>>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? new List<SimilarFilmsDTO>();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<FilmGenreDTO>> GetFilmGenresAsync()
    {
        try
        {
            using var response = await _http.Client.GetAsync("filmgenres"); //?free={freeOnly}
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<FilmGenreDTO>>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? new List<FilmGenreDTO>();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<GenreDTO>> GetGenresAsync()
    {
        try
        {
            using var response = await _http.Client.GetAsync("genres"); //?free={freeOnly}
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<GenreDTO>>(await
            response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            return result ?? new List<GenreDTO>();
        }
        catch
        {
            throw;
        }
    }
}
