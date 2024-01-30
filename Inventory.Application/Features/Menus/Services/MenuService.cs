namespace Inventory.Application.Features;

public class MenuService : IMenuService
{
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMapper mapper,
        IServiceProvider serviceProvider,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService,
        IMenuRepository menuRepository)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
        _menuRepository = menuRepository;
    }

    public async Task<List<MenuForListDto>> GetAll()
    {
        var menusFromRepo = await _menuRepository.GetAll();
        var menusToReturn = _mapper.Map<List<MenuForListDto>>(menusFromRepo);
        return menusToReturn;
    }

    public async Task<MenuForListDto> GetById(Guid id)
    {
        var menuFromRepo = await _menuRepository.GetById(id);
        var menuToReturn = _mapper.Map<MenuForListDto>(menuFromRepo);
        return menuToReturn;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        var isExist = await _menuRepository.IsExist(name, id);
        return isExist;
    }

    public async Task<BaseCommandResponse> CreateAsync(MenuForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new MenuForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var entity = new Menu();
        entity.Name = request.Name.Trim();
        entity.Status = request.Status;
        entity.ParentMenuId = request.ParentMenuId;
        await _menuRepository.Create(entity);

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> UpdateAsync(Guid id, MenuForUpdateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new MenuForUpdateDtoValidator(_serviceProvider);
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

        var entity = await _menuRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(ProductType), id.ToString());
        }

        entity.Id = request.Id;
        entity.Name = request.Name.Trim();        
        entity.Status = request.Status;
        entity.ParentMenuId = request.ParentMenuId;
        await _menuRepository.Update(entity);

        response.Success = true;
        response.Message = "Updating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> DeleteAsync(Guid id)
    {
        var response = new BaseCommandResponse();
        var entity = await _menuRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Menu), id.ToString());
        }

        var result = await _menuRepository.Delete(entity);

        response.Success = true;
        response.Message = "Deleting Successful";
        return response;
    }
}
