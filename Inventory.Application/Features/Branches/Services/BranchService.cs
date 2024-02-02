namespace Inventory.Application.Features;

public class BranchService : IBranchService
{
    private readonly IMapper _mapper;
    private readonly IBranchRepository _branchRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUserService;

    public BranchService(IMapper mapper,
        IServiceProvider serviceProvider,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService,
        IBranchRepository branchRepository)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
        _branchRepository = branchRepository;
    }

    public async Task<List<BranchForListDto>> GetAll(string? search)
    {
        var branchesFromRepo = await _branchRepository.GetAll(search);
        var branchesToReturn = _mapper.Map<List<BranchForListDto>>(branchesFromRepo);
        return branchesToReturn;
    }

    public async Task<BranchForListDto> GetById(Guid id)
    {
        var branchFromRepo = await _branchRepository.GetById(id);
        var branchToReturn = _mapper.Map<BranchForListDto>(branchFromRepo);
        return branchToReturn;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        var isExist = await _branchRepository.IsExist(name, id);
        return isExist;
    }

    public async Task<BaseCommandResponse> CreateAsync(BranchForCreateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new BranchForCreateDtoValidator(_serviceProvider);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creating Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            return response;
        }

        var entity = new Branch();
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.StreetAddress = request.StreetAddress;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Country = request.Country;
        entity.Status =request.Status;
        entity.CreatedBy = _currentUserService.UserId;
        entity.CreatedDate = _dateTimeService.Now;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _branchRepository.Create(entity);

        response.Success = true;
        response.Message = "Creating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> UpdateAsync(Guid id, BranchForUpdateDto request)
    {
        var response = new BaseCommandResponse();
        var validator = new BranchForUpdateDtoValidator(_serviceProvider);
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

        var entity = await _branchRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Branch), id.ToString());
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.StreetAddress = request.StreetAddress;
        entity.City = request.City;
        entity.Province = request.Province;
        entity.Status = request.Status;
        entity.Country = request.Country;
        entity.UpdatedBy = _currentUserService.UserId;
        entity.UpdatedDate = _dateTimeService.Now;
        await _branchRepository.Update(entity);

        response.Success = true;
        response.Message = "Updating Successful";
        return response;
    }

    public async Task<BaseCommandResponse> DeleteAsync(Guid id)
    {
        var response = new BaseCommandResponse();
        var entity = await _branchRepository.GetById(id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Branch), id.ToString());
        }

        var result = await _branchRepository.Delete(entity);

        response.Success = true;
        response.Message = "Deleting Successful";
        return response;
    }
}
