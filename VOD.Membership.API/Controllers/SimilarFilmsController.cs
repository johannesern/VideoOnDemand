namespace VOD.Films.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimilarFilmsController : ControllerBase
{
    public readonly IDbService _db;

    public SimilarFilmsController(IDbService db) => _db = db;

    //GET: api/<SimilarFilmsController>
    [HttpGet]
    public async Task<IResult> Get() => 
        await _db.HttpGetReferenceAsync<SimilarFilm, SimilarFilmsDTO>();

    // GET api/<SimilarFilmsController>?id=5&id=6
    [HttpGet("idn")]
    public async Task<IResult> Get([FromQuery] int[] id)
    {
        await _db.IncludeReferenceAsync<SimilarFilm>();
        var result = await _db.SingleRefAsync<SimilarFilm, SimilarFilmsDTO>(e => e.FilmId.Equals(id[0]) && e.SimilarFilmId.Equals(id[1]));
        return Results.Ok(result);
    }
    // POST api/<SimilarFilmsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] SimilarFilmsDTO dto) =>
        await _db.HttpPostReferenceAsync<SimilarFilm, SimilarFilmsDTO>(dto);

    // DELETE api/<SimilarFilmsController>/5  
    [HttpDelete]
    public async Task<IResult> Delete([FromBody] SimilarFilmsDTO dto) =>
            await _db.HttpDeleteReferenceAsync<SimilarFilm, SimilarFilmsDTO>(dto);
}
