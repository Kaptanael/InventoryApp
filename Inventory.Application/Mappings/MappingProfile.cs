namespace Inventory.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForListDto>().ReverseMap();
        CreateMap<Role, RoleForListDto>().ReverseMap();
    }
}
