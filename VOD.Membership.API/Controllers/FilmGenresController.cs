using VOD.Films.Database.Services;

namespace VOD.Films.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmGenresController : ControllerBase
{
	public readonly IDbService _db;

	public FilmGenresController(IDbService db) => _db = db;

	//GET: api/<FilmGenresController>
	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			await _db.IncludeReferenceAsync<FilmGenre>();
			return await _db.HttpGetReferenceAsync<FilmGenre, FilmGenreDTO>();
		}
		catch {	}
		return Results.BadRequest();
	}

    // GET api/<FilmGenresController>?id=5&id=6
	// [HttpGet("idn")]
	//public async Task<IResult> Get([FromQuery] int[] id)
	//{
	//	await _db.IncludeReferenceAsync<FilmGenre>();
	//	var result = await _db.SingleRefAsync<FilmGenre, FilmGenreDTO>(e => e.FilmId.Equals(id[0]) && e.GenreId.Equals(id[1]));
	//	return Results.Ok(result);
 //       }

        // POST api/<FilmGenresController>
        [HttpPost]
	public async Task<IResult> Post([FromBody] FilmGenreCreateDTO dto) =>
		await _db.HttpPostReferenceAsync<FilmGenre, FilmGenreCreateDTO>(dto);
		
        // DELETE api/<FilmGenresController>/5  
        [HttpDelete]
        public async Task<IResult> Delete([FromBody] FilmGenreDeleteDTO dto) =>
			await _db.HttpDeleteReferenceAsync<FilmGenre, FilmGenreDeleteDTO>(dto);
	
}
