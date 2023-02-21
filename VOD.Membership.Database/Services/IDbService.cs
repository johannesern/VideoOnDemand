namespace VOD.Films.Database;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class, IEntity
        where TDto : class;

    Task<TDto> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;

    Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IEntity
        where TDto: class;

    void Update<TEntity,TDto>(int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class;

    Task<bool> AnyAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity;

    Task<bool> DeleteAsync<TEntity>(int id)
        where TEntity : class, IEntity;

    Task IncludeAsync<TEntity>()
        where TEntity: class, IEntity;

    Task<bool> SaveChangesAsync();

    //Referencetables
    Task<List<TDto>> GetReferenceAsync<TReferenceEntity, TDto>()
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class;

	Task<TReferenceEntity> AddReferenceAsync<TReferenceEntity, TDto>(TDto dto)
		where TReferenceEntity : class, IReferenceEntity
		where TDto : class;

	Task IncludeReferenceAsync<TReferenceEntity>()
    where TReferenceEntity : class, IReferenceEntity;

    bool DeleteReference<TReferenceEntity, TDto>(TDto dto)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class;
    Task<TDto> SingleRefAsync<TReferenceEntity, TDto>(
        Expression<Func<TReferenceEntity, bool>> expression)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class;
}
