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

		//GET: api/<FilmGenresController>
		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				return await _db.HttpGetReferenceAsync<FilmGenre, FilmGenreDTO>();
			}
			catch {	}
			return Results.BadRequest();
		}

        // POST api/<FilmGenresController>
        [HttpPost]
		public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
		{
			var result = await _db.HttpPostReferenceAsync<FilmGenre, FilmGenreDTO>(dto);
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

		// DELETE api/<FilmGenresController>/5                       TA EMOT TVÅ IDN OCH FIXA
		[HttpDelete("{id}")]
        public async Task<IResult> Delete(FilmGenreDTO dto) =>
            await _db.HttpDeleteReferenceAsync<FilmGenre, FilmGenreDTO>(dto);
    }
}
