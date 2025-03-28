namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IUserRepository
{
    public Task<User> CreateAsync(User entity);
    public Task<User> GetAsync(long id);
    public Task<User> GetAsync(Expression<Func<User, bool>> filter, IEnumerable<Expression<Func<User, object>>>? includes = null);
    public Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter, IEnumerable<Expression<Func<User, object>>>? includes = null);
    public Task<User> UpdateAsync(User entity);
    public Task<bool> CheckIfExists(Expression<Func<User, bool>> filter);
}
