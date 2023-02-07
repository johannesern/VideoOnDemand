namespace VOD.Films.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmsController : ControllerBase
{
    public readonly IDbService _db;
    public FilmsController(IDbService db) => _db = db;

    // GET: api/<FilmsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            await _db.IncludeAsync<Director>();
            return await _db.HttpGetAsync<Film, FilmDTO>();
        }
        catch (Exception ex) { }
        return Results.BadRequest();
    }

    // GET api/<FilmsController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id) =>
            await _db.HttpGetAsync<Film, FilmDTO>(id);

    // POST api/<FilmsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmCreateDTO dto) =>
        await _db.HttpPostAsync<Film, FilmCreateDTO>(dto);

    // PUT api/<FilmsController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto) =>
            await _db.HttpPutAsync<Film, FilmEditDTO>(dto, id);

    // DELETE api/<FilmsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id) =>
            await _db.HttpDeleteAsync<Film>(id);
}
