namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepositoryBase<User> _repositoryBase;

    public UserRepository(IRepositoryBase<User> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<User, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<User> CreateAsync(User entity)
    {
        var user = await _repositoryBase.CreateAsync(entity);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter, IEnumerable<Expression<Func<User, object>>>? includes = null)
    {
        var users = await _repositoryBase.GetAllAsync(filter, includes);
        return users;
    }

    public async Task<User> GetAsync(long id)
    {
        var user = await _repositoryBase.GetAsync(id);
        return user;
    }

    public async Task<User> GetAsync(Expression<Func<User, bool>> filter, IEnumerable<Expression<Func<User, object>>>? includes = null)
    {
        var user = await _repositoryBase.GetAsync(filter, includes);
        return user;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var user = await _repositoryBase.UpdateAsync(entity);
        return user;
    }
}
