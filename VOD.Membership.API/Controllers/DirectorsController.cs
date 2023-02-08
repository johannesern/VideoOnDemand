namespace VOD.Films.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{
    public readonly IDbService _db;

    public DirectorsController(IDbService db) => _db = db;

    // GET: api/<DirectorsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        //Här ska in en turnery eller if sats gällande fria filmer eller ej
        try
        {
            await _db.IncludeAsync<Film>();
            return await _db.HttpGetAsync<Director, DirectorDTO>();
        }
        catch (Exception ex) { }
        return Results.BadRequest();
    }

    // GET api/<DirectorsController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id) =>
            await _db.HttpGetAsync<Director, DirectorDTO>(id);

    // POST api/<DirectorsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] DirectorCreateDTO dto) =>
        await _db.HttpPostAsync<Director, DirectorCreateDTO>(dto);
    

    // PUT api/<DirectorsController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto) =>
            await _db.HttpPutAsync<Director, DirectorEditDTO>(dto, id);

    // DELETE api/<DirectorsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id) =>
            await _db.HttpDeleteAsync<Director>(id);
}
