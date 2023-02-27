using Microsoft.AspNetCore.Mvc;
using VOD.Films.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VOD.Films.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		public readonly IDbService _db;

		public GenresController(IDbService db) => _db = db;

		// GET: api/<GenresController>
		[HttpGet]
		public async Task<IResult> Get()
		{
			//Här ska in en turnery eller if sats gällande fria filmer eller ej
			try
			{
				await _db.IncludeAsync<Film>();
                await _db.IncludeReferenceAsync<FilmGenre>();
				return await _db.HttpGetAsync<Genre, GenreDTO>();
			}
			catch (Exception ex) { }
			return Results.BadRequest();
		}

		// GET api/<GenresController>/5
		[HttpGet("{id}")]
		public async Task<IResult> Get(int id) =>
				await _db.HttpGetAsync<Genre, GenreDTO>(id);

		// POST api/<GenresController>
		[HttpPost]
		public async Task<IResult> Post([FromBody] GenreCreateDTO dto) =>
			await _db.HttpPostAsync<Genre, GenreCreateDTO>(dto);


		// PUT api/<GenresController>/5
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] GenreEditDTO dto) =>
				await _db.HttpPutAsync<Genre, GenreEditDTO>(dto, id);

		// DELETE api/<GenresController>/5
		[HttpDelete("{id}")]
		public async Task<IResult> Delete(int id) =>
				await _db.HttpDeleteAsync<Genre>(id);
	}
}
