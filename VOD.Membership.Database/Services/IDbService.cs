namespace VOD.Films.Database
{
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
    }
}
