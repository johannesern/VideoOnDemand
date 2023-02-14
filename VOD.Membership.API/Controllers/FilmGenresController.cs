using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VOD.Films.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmGenresController : ControllerBase
	{
		public readonly IDbService _db;

		public FilmGenresController(IDbService db) => _db = db;

		// GET: api/<SimilarFilmsController>
		//[HttpGet]
		//public async Task<IResult> Get()
		//{
		//Här ska in en turnery eller if sats gällande fria filmer eller ej
		//try
		//{
		//	return await _db.HttpGetAsync<Director, DirectorDTO>();
		//}
		//catch (Exception ex) { }
		//return Results.BadRequest();
		//}

		// GET api/<SimilarFilmsController>/5
		//[HttpGet("{id}")]
		//public async Task<IResult> Get(int id) =>
		//		await _db.HttpGetAsync<Director, DirectorDTO>(id);

		// POST api/<SimilarFilmsController>
		[HttpPost]
		public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
		{
			var result = await _db.AddReferenceAsync<FilmGenre, FilmGenreDTO>(dto);
			if (result != null)
			{
				await _db.SaveChangesAsync();
				return Results.Ok(result);
			}
			else
			{
				return Results.BadRequest();
			}

		}


		// PUT api/<SimilarFilmsController>/5
		//[HttpPut("{id}")]
		//public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto) =>
		//		await _db.HttpPutAsync<Director, DirectorEditDTO>(dto, id);

		//// DELETE api/<SimilarFilmsController>/5
		//[HttpDelete("{id}")]
		//public async Task<IResult> Delete(int id) =>
		//		await _db.HttpDeleteAsync<Director>(id);
	}
}
