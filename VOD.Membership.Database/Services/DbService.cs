﻿namespace VOD.Films.Database
{
    public class DbService : IDbService
    {
        private readonly VODContext _db;
        private readonly IMapper _mapper;
        public DbService(VODContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        //GET All
        public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class, IEntity
        where TDto : class
        {
            var entities = await _db.Set<TEntity>().ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        //GET by ID
        public async Task<TDto> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class
        {
            var entity = await SingleAsync(expression);
            return _mapper.Map<TDto>(entity);
        }

        //POST AddAsync
        public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
             where TEntity : class, IEntity
             where TDto : class
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _db.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        
        //PUT
        public void Update<TEntity, TDto>(int id, TDto dto)
            where TEntity : class, IEntity
            where TDto : class
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.Id = id;
            _db.Set<TEntity>().Update(entity);
        }

        //Used by other methods
        private async Task<TEntity?> SingleAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity =>
            await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

        //SaveChanges
        public async Task<bool> SaveChangesAsync() =>
            await _db.SaveChangesAsync() >= 0;

        //AnyAsync
        public async Task<bool> AnyAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity =>
            await _db.Set<TEntity>().AnyAsync(expression);

        //DELETE
        public async Task<bool> DeleteAsync<TEntity>(int id)
            where TEntity : class, IEntity
        {
            try
            {
                var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
                if (entity == null) { return false; }
                _db.Remove(entity);
            }
            catch { throw; }
            
            return true;
        }

        public async Task IncludeAsync<TEntity>()
            where TEntity : class, IEntity
        {
            var propertyNames = _db.Model.FindEntityType(typeof(TEntity))?.GetNavigations().Select(e => e.Name);
            if(propertyNames != null) 
            {
                foreach( var name in propertyNames)
                {
                    _db.Set<TEntity>().Include(name).Load();
                }
            }
        }
    }
}