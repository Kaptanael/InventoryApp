namespace Inventory.Application.Features;

public class WarehouseService 
{
    private readonly IMapper _mapper;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUserService;

    public WarehouseService(IMapper mapper,
        IServiceProvider serviceProvider,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService,
        IWarehouseRepository warehouseRepository)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
        _warehouseRepository = warehouseRepository;
    }

    public async Task<List<WarehouseForListDto>> GetAll()
    {
        var warehouseFromRepo = await _warehouseRepository.GetAll();
        var warehousesToReturn = _mapper.Map<List<WarehouseForListDto>>(warehouseFromRepo);
        return warehousesToReturn;
    }

    public async Task<WarehouseForListDto> GetById(Guid id)
    {
        var warehouseFromRepo = await _warehouseRepository.GetById(id);
        var warehouseToReturn = _mapper.Map<WarehouseForListDto>(warehouseFromRepo);
        return warehouseToReturn;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        var isExist = await _warehouseRepository.IsExist(name, id);
        return isExist;
    }

    public async Task<BaseCommandResponse> CreateAsync(WarehouseForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new WarehouseForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var entity = new Warehouse();
        entity.BranchId = request.BranchId;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.StreetAddress = request.StreetAddress;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Country = request.Country;
        entity.CreatedBy = _currentUserService.UserId;
        entity.CreatedDate = _dateTimeService.Now;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _warehouseRepository.Create(entity);

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> UpdateAsync(Guid id, WarehouseForUpdateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new WarehouseForUpdateDtoValidator(_serviceProvider);
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

        var entity = await _warehouseRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Warehouse), id.ToString());
        }

        entity.Id = request.Id;
        entity.BranchId = request.BranchId;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.StreetAddress = request.StreetAddress;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Country = request.Country;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _warehouseRepository.Update(entity);

        response.Success = true;
        response.Message = "Updating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> DeleteAsync(Guid id)
    {
        var response = new BaseCommandResponse();
        var entity = await _warehouseRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Warehouse), id.ToString());
        }

        var result = await _warehouseRepository.Delete(entity);

        response.Success = true;
        response.Message = "Deleting Successful";
        return response;
    }
}
