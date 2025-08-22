using AutoMapper;
using MC.Application.Features.Menu.Menu.Command.Create;
using MC.Application.Features.Menu.Menu.Command.Update;
using MC.Application.Features.Menu.MenuItem.Command.Create;
using MC.Application.Features.Menu.MenuItem.Command.Update;
using MC.Application.ModelDto.Menu;
using MC.Domain.Entity.Menu;

namespace MC.Application.MappingProfiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, MenuDetailDto>();
            CreateMap<CreateMenuCmd, Menu>();
            CreateMap<UpdateMenuCmd, Menu>();

            CreateMap<MenuItem, MenuItemDto>().ReverseMap();
            CreateMap<MenuItem, MenuItemDetailDto>();
            CreateMap<CreateMenuItemCmd, MenuItem>();
            CreateMap<UpdateMenuItemCmd, MenuItem>();
        }
    }
}
