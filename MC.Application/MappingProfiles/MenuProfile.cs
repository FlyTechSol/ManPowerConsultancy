using AutoMapper;
using MC.Application.Features.Menu.Menu.Command.Create;
using MC.Application.Features.Menu.Menu.Command.Update;
using MC.Application.Features.Menu.MenuItem.Command.Create;
using MC.Application.Features.Menu.MenuItem.Command.Update;
using MC.Application.Features.Navigation.NavigationNode.Command.Create;
using MC.Application.Features.Navigation.NavigationNode.Command.Update;
using MC.Application.ModelDto.Menu;
using MC.Application.ModelDto.Navigation;
using MC.Domain.Entity.Menu;
using MC.Domain.Entity.Navigation;

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

            CreateMap<NavigationNode, NavigationNodeDto>().ReverseMap();
            CreateMap<NavigationNode, NavigationNodeDropdownDto>();
            CreateMap<UpdateNavigationNodeCmd, NavigationNode>();
            CreateMap<CreateNavigationNodeCmd, NavigationNode>();
        }
    }
}
