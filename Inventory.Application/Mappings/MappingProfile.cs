namespace Inventory.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForListDto>().ReverseMap();
        CreateMap<Role, RoleForListDto>().ReverseMap();
        CreateMap<Branch, BranchForListDto>().ReverseMap();
        CreateMap<Warehouse, WarehouseForListDto>().ReverseMap();
        CreateMap<ProductType, ProductTypeForListDto>().ReverseMap();
        CreateMap<Menu, MenuForListDto>().ReverseMap();
    }
}
