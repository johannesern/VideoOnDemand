using Microsoft.AspNetCore.Mvc;
using VOD.Films.Database.Entities;

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

        // GET api/<FilmGenresController>?id=5&id=6
        [HttpGet("idn")]
		public async Task<IResult> Get([FromQuery] int[] id)
		{
			await _db.IncludeReferenceAsync<FilmGenre>();
			var result = await _db.SingleRefAsync<FilmGenre, FilmGenreDTO>(e => e.FilmId.Equals(id[0]) && e.GenreId.Equals(id[1]));
			return Results.Ok(result);
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
        //public async Task<IResult> Delete([FromQuery] int[] id)
        // DELETE api/<FilmGenresController>/5  
        [HttpDelete("{filmId:int}/{genreId:int}", Name = "Delete")]
        public async Task<IResult> Delete([FromQuery] int[] id) //[HttpDelete("{filmId:int}/{genreId:int}", Name = "Delete")]
        {
            var dto = await _db.SingleRefAsync<FilmGenre, FilmGenreDTO>(e => e.FilmId.Equals(id[0]) && e.GenreId.Equals(id[1]));
			if(dto != null)
			{
				await _db.HttpDeleteReferenceAsync<FilmGenre, FilmGenreDTO>(dto);
                return Results.Ok(dto);
            }
			else
			{
				return Results.BadRequest();
			}
		}
    }
}
