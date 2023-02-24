namespace VOD.Films.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimilarFilmsController : ControllerBase
{
    public readonly IDbService _db;

    public SimilarFilmsController(IDbService db) => _db = db;

    //GET: api/<SimilarFilmsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        await _db.IncludeReferenceAsync<SimilarFilm>();
        return await _db.HttpGetReferenceAsync<SimilarFilm, SimilarFilmsDTO>();
    }

    //GET api/<SimilarFilmsController>?id=5&id=6
    //[HttpGet("{id}")]
    //public async Task<IResult> Get(int id)
    //{
    //    await _db.IncludeReferenceAsync<SimilarFilm>();
    //    return await _db.GetReferenceAsync<SimilarFilm, SimilarFilmsDTO>(e => e.FilmId.Equals(id));
    //}

    // POST api/<SimilarFilmsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] SimilarFilmsDTO dto) =>
        await _db.HttpPostReferenceAsync<SimilarFilm, SimilarFilmsDTO>(dto);

    // DELETE api/<SimilarFilmsController>/5  
    [HttpDelete]
    public async Task<IResult> Delete([FromBody] SimilarFilmsDTO dto) =>
            await _db.HttpDeleteReferenceAsync<SimilarFilm, SimilarFilmsDTO>(dto);
}
