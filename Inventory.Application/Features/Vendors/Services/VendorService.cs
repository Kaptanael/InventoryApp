namespace Inventory.Application.Features;

public class VendorService : IVendorService
{
    private readonly IMapper _mapper;
    private readonly IVendorRepository _vendorRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUserService;

    public VendorService(IMapper mapper,
        IServiceProvider serviceProvider,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService,
        IVendorRepository vendorRepository)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
        _vendorRepository = vendorRepository;
    }

    public async Task<List<VendorForListDto>> GetAll()
    {
        var branchesFromRepo = await _vendorRepository.GetAll();
        var branchesToReturn = _mapper.Map<List<VendorForListDto>>(branchesFromRepo);
        return branchesToReturn;
    }

    public async Task<VendorForListDto> GetById(Guid id)
    {
        var branchFromRepo = await _vendorRepository.GetById(id);
        var branchToReturn = _mapper.Map<VendorForListDto>(branchFromRepo);
        return branchToReturn;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        var isExist = await _vendorRepository.IsExist(name, id);
        return isExist;
    }

    public async Task<BaseCommandResponse> CreateAsync(VendorForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new VendorForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var entity = new Vendor();
        entity.Name = request.Name;
        entity.BusinessSize = request.BusinessSize;
        entity.Description = request.Description;
        entity.StreetAddress = request.StreetAddress;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Country = request.Country;
        entity.Status = request.Status;
        entity.CreatedBy = _currentUserService.UserId;
        entity.CreatedDate = _dateTimeService.Now;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _vendorRepository.Create(entity);

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> UpdateAsync(Guid id, VendorForUpdateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new VendorForUpdateDtoValidator(_serviceProvider);
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

        var entity = await _vendorRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Vendor), id.ToString());
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.BusinessSize = request.BusinessSize;
        entity.Description = request.Description;
        entity.StreetAddress = request.StreetAddress;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Status = request.Status;
        entity.Country = request.Country;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _vendorRepository.Update(entity);

        response.Success = true;
        response.Message = "Updating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> DeleteAsync(Guid id)
    {
        var response = new BaseCommandResponse();
        var entity = await _vendorRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Vendor), id.ToString());
        }

        var result = await _vendorRepository.Delete(entity);

        response.Success = true;
        response.Message = "Deleting Successful";
        return response;
    }
}
