namespace Inventory.Application.Features;

public class ProductTypeService : IProductTypeService
{
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypeService(IMapper mapper,
        IServiceProvider serviceProvider,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService,
        IProductTypeRepository roleRepository)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
        _productTypeRepository = roleRepository;
    }

    public async Task<List<ProductTypeForListDto>> GetAll()
    {
        var productTypesFromRepo = await _productTypeRepository.GetAll();
        var productTypesToReturn = _mapper.Map<List<ProductTypeForListDto>>(productTypesFromRepo);
        return productTypesToReturn;
    }

    public async Task<ProductTypeForListDto> GetById(Guid id)
    {
        var productTypeFromRepo = await _productTypeRepository.GetById(id);
        var productTypeToReturn = _mapper.Map<ProductTypeForListDto>(productTypeFromRepo);
        return productTypeToReturn;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        var isExist = await _productTypeRepository.IsExist(name, id);
        return isExist;
    }

    public async Task<BaseCommandResponse> CreateAsync(ProductTypeForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new ProductTypeForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var entity = new ProductType();
        entity.Name = request.Name.Trim();
        entity.Description = request.Description.Trim();
        entity.CreatedBy = _currentUserService.UserId;
        entity.CreatedDate = _dateTimeService.Now;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _productTypeRepository.Create(entity);

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> UpdateAsync(Guid id, ProductTypeForUpdateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new ProductTypeForUpdateDtoValidator(_serviceProvider);
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

        var entity = await _productTypeRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(ProductType), id.ToString());
        }

        entity.Id = request.Id;
        entity.Name = request.Name.Trim();
        entity.Description = request.Description.Trim();
        entity.CreatedBy = _currentUserService.UserId;
        entity.CreatedDate = _dateTimeService.Now;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _productTypeRepository.Update(entity);

        response.Success = true;
        response.Message = "Updating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> DeleteAsync(Guid id)
    {
        var response = new BaseCommandResponse();
        var entity = await _productTypeRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(ProductType), id.ToString());
        }

        var result = await _productTypeRepository.Delete(entity);

        response.Success = true;
        response.Message = "Deleting Successful";
        return response;
    }
}
