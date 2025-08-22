using AutoMapper;
using MC.Application.Features.Registration.Address.Command.Create;
using MC.Application.Features.Registration.Address.Command.Update;
using MC.Application.Features.Registration.BankAccount.Command.Create;
using MC.Application.Features.Registration.BankAccount.Command.Update;
using MC.Application.Features.Registration.EmployeeReference.Command.Create;
using MC.Application.Features.Registration.EmployeeReference.Command.Update;
using MC.Application.Features.Registration.ExArmy.Command.Create;
using MC.Application.Features.Registration.ExArmy.Command.Update;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.MappingProfiles
{
    public class RegsitrationProfile : Profile
    {
        public RegsitrationProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            //CreateMap<Address, AddressDetailDto>();
            CreateMap<CreateAddressCmd, Address>();
            CreateMap<UpdateAddressCmd, Address>();

            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            //CreateMap<BankAccount, BankAccountDetailDto>();
            CreateMap<CreateBankAccountCmd, BankAccount>();
            CreateMap<UpdateBankAccountCmd, BankAccount>();

            CreateMap<ExArmy, ExArmyDetailDto>().ReverseMap();
            CreateMap<CreateExArmyCmd, ExArmy>();
            CreateMap<UpdateExArmyCmd, ExArmy>();

            CreateMap<EmployeeReference, EmployeeReferenceDetailDto>().ReverseMap();
            CreateMap<CreateEmpRefCmd, EmployeeReference>();
            CreateMap<UpdateEmpRefCmd, EmployeeReference>();
        }
    }
}
