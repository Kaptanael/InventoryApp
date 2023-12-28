namespace Inventory.Application.Features;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;
    private readonly IServiceProvider _serviceProvider;

    public RoleService(IMapper mapper, IServiceProvider serviceProvider, IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _roleRepository = roleRepository;
    }

    public async Task<List<RoleForListDto>> GetAll()
    {
        var rolesFromRepo = await _roleRepository.GetAll();
        var rolesToReturn = _mapper.Map<List<RoleForListDto>>(rolesFromRepo);
        return rolesToReturn;
    }

    public async Task<RoleForListDto> GetById(Guid id)
    {
        var roleFromRepo = await _roleRepository.GetById(id);
        var roleToReturn = _mapper.Map<RoleForListDto>(roleFromRepo);
        return roleToReturn;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        var isExist = await _roleRepository.IsExist(name, id);
        return isExist;
    }

    public async Task<BaseCommandResponse> CreateAsync(RoleForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new RoleForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var entity = new Role { Name = request.Name };
        await _roleRepository.Create(entity);

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> UpdateAsync(Guid id, RoleForUpdateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new RoleForUpdateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Updating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        if (id != request.Id)
        {
            throw new BadRequestException("Id does not match");
        }

        var entity = await _roleRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Role), id.ToString());
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        await _roleRepository.Update(entity);

        response.Success = true;
        response.Message = "Updating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> DeleteAsync(Guid id)
    {
        var response = new BaseCommandResponse();
        var entity = await _roleRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Role), id.ToString());
        }

        var result = await _roleRepository.Delete(entity);

        response.Success = true;
        response.Message = "Deleting Successful";
        return response;
    }
}
