namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly AppDbContext _appDbContext;

    public RepositoryBase(AppDbContext appDbContext)
    {
        _dbSet = appDbContext.Set<TEntity>();
        _appDbContext = appDbContext;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return _appDbContext.Entry(entity).Entity;
    }

    public async Task<IEnumerable<TEntity>> CreateManyAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _appDbContext.SaveChangesAsync();
        return  _appDbContext.Entry(entities).Entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return _appDbContext.Entry(entity).Entity;
    }

    public async Task<IEnumerable<TEntity>> DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        await _appDbContext.SaveChangesAsync();
        return _appDbContext.Entry(entities).Entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<Expression<Func<TEntity, object>>>? includes = null)
    {
        IQueryable<TEntity> query = _dbSet
            .AsQueryable()
            .AsNoTracking()
            .Where(filter);

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity!;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<Expression<Func<TEntity, object>>>? includes = null)
    {
        IQueryable<TEntity> query = _dbSet
            .AsQueryable()
            .Where(filter)
            .AsNoTracking();

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        var entity = await query.FirstOrDefaultAsync();
        return entity!;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return _appDbContext.Entry(entity).Entity;
    }

    public async Task<bool> CheckIfExists(Expression<Func<TEntity, bool>> filter)
    {
        IQueryable<TEntity> query = _dbSet
            .AsQueryable()
            .Where(filter)
            .AsNoTracking();

        var result = await query.AnyAsync();

        return result;
    }

    public async Task<List<T>> ExecuteRawSqlAsync<T>(string sql, Func<DbDataReader, T> map, params object[] parameters)
    {
        await using var connection = _appDbContext.Database.GetDbConnection();
        await connection.OpenAsync();

        await using var command = connection.CreateCommand();
        command.CommandText = sql;

        // Adiciona os parâmetros à consulta
        for (int i = 0; i < parameters.Length; i++)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = $"@p{i}";
            parameter.Value = parameters[i] ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        var result = new List<T>();
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            result.Add(map(reader));
        }

        return result;
    }
}
