using VOD.Films.Database.Entities;
using VOD.Films.Database.Services;

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

    // Kopplingstabeller
    public static async Task<IResult> HttpGetReferenceAsync<TReferenceEntity, TDto>(this IDbService db)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class
    {
        var entities = await db.GetReferenceAsync<TReferenceEntity, TDto>();
        return Results.Ok(entities);
    }

    public static async Task<IResult> HttpPostReferenceAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto)
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class
    {
        try
        {
            var entity = await db.AddReferenceAsync<TReferenceEntity, TDto>(dto);
            if (await db.SaveChangesAsync())
            {
                var node = typeof(TReferenceEntity).Name.ToLower();
                return Results.Ok();
            }

            return Results.Created("api/filmgenres", entity);
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't add the {typeof(TReferenceEntity).Name} entity.\n{ex}.");
        }
    }

    public static async Task<IResult> HttpDeleteReferenceAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto)
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class
    {       
        try
        {
            var success = db.DeleteReference<TReferenceEntity, TDto>(dto);
            if (success is false) 
            { 
                return Results.NotFound();
            }

            success = await db.SaveChangesAsync();
            if (success is false)
            {
                return Results.NoContent(); 
            }
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't delete the {typeof(TReferenceEntity).Name} entity.\n{ex}.");
        }
    }
    //public static GetURI se OneNote för implementering

}
