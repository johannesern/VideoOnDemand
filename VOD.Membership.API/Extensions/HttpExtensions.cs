namespace VOD.Films.API.Extensions;

public static class HttpExtensions
{
    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
        where TEntity : class, IEntity
        where TDto : class
    {
            var entities = await db.GetAsync<TEntity, TDto>();
            return Results.Ok(entities);
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db, int id)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = await db.SingleAsync<TEntity, TDto>(e => e.Id.Equals(id));
        if(entity== null) { return Results.NotFound(); }
        return Results.Ok(entity);
    }

    public static async Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService db, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        try
        {
            var entity = await db.AddAsync<TEntity, TDto>(dto);
            if (await db.SaveChangesAsync())
            {
                var node = typeof(TEntity).Name.ToLower();
                return Results.Created($"/{node}s/{entity.Id}", entity);
            }

            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't add the {typeof(TEntity).Name} entity.\n{ex}.");
        }
    }

    public static async Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService db, TDto dto, int id)
        where TEntity : class, IEntity 
        where TDto : class
    {
        try
        {
            if (dto == null) return Results.BadRequest();

            if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id))) { return Results.NotFound(); }

            db.Update<TEntity, TDto>(id, dto);

            if (await db.SaveChangesAsync()) { return Results.NoContent(); }
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't update the {typeof(TEntity).Name} entity.\n{ex}.");
        }
        return Results.Ok();
    }

    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
        where TEntity : class, IEntity            
    {
        try
        {
            if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id))) { return Results.NotFound(); }

            if (!await db.DeleteAsync<TEntity>(id)) { return Results.NotFound(); }

            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.\n{ex}.");
        }
        return Results.Ok();
    }

    //public static GetURI se OneNote för implementering
    
}
