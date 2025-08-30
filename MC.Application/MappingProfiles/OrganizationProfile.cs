using AutoMapper;
using MC.Application.Features.Organization.ClientMaster.Command.Create;
using MC.Application.Features.Organization.ClientMaster.Command.Update;
using MC.Application.Features.Organization.ClientUnit.Command.Create;
using MC.Application.Features.Organization.ClientUnit.Command.Update;
using MC.Application.Features.Organization.Company.Command.Create;
using MC.Application.Features.Organization.Company.Command.Update;
using MC.Application.ModelDto.Organization;
using MC.Domain.Entity.Organization;

namespace MC.Application.MappingProfiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<ClientMaster, ClientMasterDetailDto>().ReverseMap();
            //CreateMap<ClientMaster, ClientMasterDetailDto>();
            CreateMap<CreateClientMasterCmd, ClientMaster>();
            CreateMap<UpdateClientMasterCmd, ClientMaster>();

            CreateMap<ClientUnit, UnitDetailDto>().ReverseMap();
            //CreateMap<ClientUnit, UnitDetailDto>();
            CreateMap<CreateUnitCmd, ClientUnit>();
            CreateMap<UpdateUnitCmd, ClientUnit>();

            CreateMap<Company, CompanyDetailDto>().ReverseMap();
            //CreateMap<Company, CompanyDetailDto>();
            CreateMap<CreateCompanyCmd, Company>();
            CreateMap<UpdateCompanyCmd, Company>();
        }
    }
}
