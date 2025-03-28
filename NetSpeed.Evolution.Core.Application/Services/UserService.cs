namespace NetSpeed.Evolution.Core.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> BlockAsync(long id)
    {
        var user = await _userRepository.GetAsync(id);

        if (user is null)
            throw new UserNotFoundException();

        user.Block();

        var userUpdated = await _userRepository.UpdateAsync(user);

        return _mapper.Map<UserDto>(userUpdated);
    }

    public async Task<bool> CheckIfExists(UserFilter filter)
    {
        var exists = await _userRepository.CheckIfExists(x => x.Login.Equals(filter.Login));
        return exists;
    }

    public async Task<UserDto> CreateAsync(UserInsertDto entity)
    {
        if(await CheckIfExists(new UserFilter() { Login = entity.Login}))
            throw new UserAlreadyExistsException();

        var user = new User(entity.Login, entity.Password);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(UserFilter filter)
    {
        Expression<Func<User, bool>> expressionFilter =
            x => (
                (!filter.Id.HasValue || x.Id == filter.Id.Value)
                && (string.IsNullOrEmpty(filter.Login) || x.Login.Equals(filter.Login))
                && (!filter.Blocked.HasValue || x.Blocked == filter.Blocked.Value)
            );

        IEnumerable<Expression<Func<User, object>>> includes = new List<Expression<Func<User, object>>>()
        {
            x => x.Employee
        };

        IEnumerable<User> users = await _userRepository.GetAllAsync(expressionFilter, includes);
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetAsync(long id)
    {
        var user = await _userRepository.GetAsync(id);

        if (user is null)
            throw new UserNotFoundException();

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetAsync(UserFilter filter)
    {
        if (await CheckIfExists(new UserFilter() { Login = filter.Login }))
            throw new UserAlreadyExistsException();

        IEnumerable<Expression<Func<User, object>>> includes = new List<Expression<Func<User, object>>>()
        {
            x => x.Employee
        };
;
        var user = await _userRepository.GetAsync(x => x.Login.Equals(filter.Login), includes);

        return _mapper.Map<UserDto>(user);
    }
}
