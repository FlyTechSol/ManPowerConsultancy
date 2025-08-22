using AutoMapper;
using MC.Application.Features.Master.Gender.Command.Create;
using MC.Application.Features.Master.Gender.Command.Update;
using MC.Application.Features.Master.Title.Command.Create;
using MC.Application.Features.Master.Title.Command.Update;
using MC.Application.Features.Master.ZipCode.Command.Create;
using MC.Application.Features.Master.ZipCode.Command.Update;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.MappingProfiles
{
    public class MasterProfile : Profile
    {
        public MasterProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Gender, GenderDetailDto>();
            CreateMap<CreateGenderCmd, Gender>();
            CreateMap<UpdateGenderCmd, Gender>();

            CreateMap<Title, TitleDto>().ReverseMap();
            CreateMap<Title, TitleDetailDto>();
            CreateMap<CreateTitleCmd, Title>();
            CreateMap<UpdateTitleCmd, Title>();

            CreateMap<ZipCode, ZipCodeDto>().ReverseMap();
            CreateMap<ZipCode, ZipCodeDetailDto>();
            CreateMap<CreateZipCodeCmd, ZipCode>();
            CreateMap<UpdateZipCodeCmd, ZipCode>();
        }
    }
}
