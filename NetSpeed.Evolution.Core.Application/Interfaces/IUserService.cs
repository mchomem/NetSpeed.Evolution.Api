namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IUserService
{
    public Task<bool> CheckIfExists(UserFilter filter);
    public Task<UserDto> CreateAsync(UserInsertDto entity);
    public Task<UserDto> GetAsync(long id);
    public Task<UserDto> GetAsync(UserFilter filter);
    public Task<IEnumerable<UserDto>> GetAllAsync(UserFilter filter);
    public Task<UserDto> BlockAsync(long id);
}
