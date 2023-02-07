using Microsoft.AspNetCore.Authorization;

namespace VOD.Films.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeedController : ControllerBase
{
    private readonly IDbService _db;

    public SeedController(IDbService db) => _db = db;

    [AllowAnonymous]
    [HttpPost]
    public async Task<IResult> Post()
    {
        try
        {
            await VODContextExtensions.SeedMembershipData(_db);
            return Results.NoContent();
        }
        catch (Exception ex)
        {

        }
        return Results.BadRequest();
    }
}
