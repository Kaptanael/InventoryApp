namespace Inventory.Application.Features;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper,
        IServiceProvider serviceProvider,
        ICurrentUserService currentUserService,
        IUserRepository userRepository) : base(mapper, serviceProvider, currentUserService)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseCommandResponse> CreateAsync(UserForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new UserForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var userRoles = new List<UserRole>();
        foreach (var roleId in request.Roles)
        {
            var role = new UserRole { UserId = _currentUserService.UserId, RoleId = new Guid(roleId) };
            userRoles.Add(role);
        }

        var entity = new User
        {
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            Email = request.Email,
            Mobile = request.Mobile,
            IsActive = true,
            CreatedBy = _currentUserService.UserId,
            CreatedDate = DateTime.Now,
            UpdatedBy = _currentUserService.UserId,
            UpdatedDate = DateTime.Now,
            UserRoles = userRoles
        };         
        await _userRepository.Insert(entity);        

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<List<UserForListDto>> GetAllUser()
    {
        var userFromRepo = await _userRepository.GetAllUser();
        var userToReturn = _mapper.Map<List<UserForListDto>>(userFromRepo);
        return userToReturn;
    }

    public async Task<UserForListDto> GetUser(string userName, string password)
    {
        var userFromRepo = await _userRepository.GetUser(userName, password);
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
