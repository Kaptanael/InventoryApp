namespace Inventory.Application.Features;

public class UserService: IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserForListDto> GetUser(string userName, string password)
    {
        var userFromRepo = await _userRepository.GetUser(userName,password);
        var userToReturn = _mapper.Map<UserForListDto>(userFromRepo);
        return userToReturn;
    }

    public async Task<UserForListDto> GetUser(Guid id)
    {
        var userFromRepo = await _userRepository.GetUser(id);
        var userToReturn = _mapper.Map<UserForListDto>(userFromRepo);
        return userToReturn;
    }

    public async Task<bool> IsActiveUser(Guid id)
    {
        return await _userRepository.IsActiveUser(id);
    }
}
