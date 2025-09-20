using AutoMapper;
using MC.Application.Features.Master.Asset.Command.Update;
using MC.Application.Features.Registration.Address.Command.Create;
using MC.Application.Features.Registration.Address.Command.Update;
using MC.Application.Features.Registration.BankAccount.Command.Create;
using MC.Application.Features.Registration.BankAccount.Command.Update;
using MC.Application.Features.Registration.BodyMeasurement.Command.Create;
using MC.Application.Features.Registration.BodyMeasurement.Command.Update;
using MC.Application.Features.Registration.Communication.Command.Create;
using MC.Application.Features.Registration.Communication.Command.Update;
using MC.Application.Features.Registration.EmployeeReference.Command.Create;
using MC.Application.Features.Registration.EmployeeReference.Command.Update;
using MC.Application.Features.Registration.EmployeeVerification.Command.Create;
using MC.Application.Features.Registration.EmployeeVerification.Command.Update;
using MC.Application.Features.Registration.ExArmy.Command.Create;
using MC.Application.Features.Registration.ExArmy.Command.Update;
using MC.Application.Features.Registration.Family.Command.Create;
using MC.Application.Features.Registration.Family.Command.Update;
using MC.Application.Features.Registration.GunMan.Command.Create;
using MC.Application.Features.Registration.GunMan.Command.Update;
using MC.Application.Features.Registration.Insurance.Command.Create;
using MC.Application.Features.Registration.Insurance.Command.Update;
using MC.Application.Features.Registration.InsuranceNominee.Command.Create;
using MC.Application.Features.Registration.InsuranceNominee.Command.Update;
using MC.Application.Features.Registration.PoliceVerification.Command.Create;
using MC.Application.Features.Registration.PoliceVerification.Command.Update;
using MC.Application.Features.Registration.PreviousExperience.Command.Create;
using MC.Application.Features.Registration.PreviousExperience.Command.Update;
using MC.Application.Features.Registration.Resignation.Command.Create;
using MC.Application.Features.Registration.Resignation.Command.Update;
using MC.Application.Features.Registration.SecurityDeposit.Command.Create;
using MC.Application.Features.Registration.SecurityDeposit.Command.Update;
using MC.Application.Features.Registration.Training.Command.Create;
using MC.Application.Features.Registration.Training.Command.Update;
using MC.Application.Features.Registration.UserAsset.Command.Create;
using MC.Application.Features.Registration.UserAsset.Command.Update;
using MC.Application.Features.Registration.UserAsset.Command.UpdateStatus;
using MC.Application.Features.Registration.UserDocument.Command.Create;
using MC.Application.Features.Registration.UserDocument.Command.Update;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Create;
using MC.Application.Features.Registration.UserGeneralDetail.Command.Update;
using MC.Application.Features.Registration.UserProfile.Command.Create;
using MC.Application.Features.Registration.UserProfile.Command.Update;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Master;
using MC.Domain.Entity.Registration;

namespace MC.Application.MappingProfiles
{
    public class RegsitrationProfile : Profile
    {
        public RegsitrationProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressDetailDto>();
            CreateMap<CreateAddressCmd, Address>();
            CreateMap<UpdateAddressCmd, Address>();

            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            CreateMap<BankAccount, BankAccountDetailDto>();
            CreateMap<CreateBankAccountCmd, BankAccount>();
            CreateMap<UpdateBankAccountCmd, BankAccount>();
            CreateMap<BankAccountDetailDto, BankAccountDto>();

            CreateMap<BodyMeasurement, BodyMeasurementDetailDto>().ReverseMap();
            //CreateMap<BodyMeasurement, BodyMeasurementDto>();
            CreateMap<CreateBodyMeasCmd, BodyMeasurement>();
            CreateMap<UpdateBodyMeasCmd, BodyMeasurement>();

            CreateMap<Communication, CommunicationDetailDto>().ReverseMap();
            //CreateMap<Communication, CommunicationDto>();
            CreateMap<CreateCommunicationCmd, Communication>();
            CreateMap<UpdateCommunicationCmd, Communication>();

            CreateMap<EmployeeReference, EmployeeReferenceDetailDto>().ReverseMap();
            //CreateMap<EmployeeReference, EmployeeReferenceDto>();
            CreateMap<CreateEmpRefCmd, EmployeeReference>();
            CreateMap<UpdateEmpRefCmd, EmployeeReference>();

            CreateMap<EmployeeVerification, EmployeeVerificationDetailDto>().ReverseMap();
            //CreateMap<EmployeeVerification, EmployeeVerificationDetailDto>();
            CreateMap<CreateEmployeeVerificationCmd, EmployeeVerification>();
            CreateMap<UpdateEmployeeVerificationCmd, EmployeeVerification>();


            CreateMap<ExArmy, ExArmyDetailDto>().ReverseMap();
            //CreateMap<ExArmy, ExArmyDetailDto>().ReverseMap();
            CreateMap<CreateExArmyCmd, ExArmy>();
            CreateMap<UpdateExArmyCmd, ExArmy>();

            CreateMap<Family, FamilyDetailDto>().ReverseMap();
            //CreateMap<Family, FamilyDetailDto>().ReverseMap();
            CreateMap<CreateFamilyCmd, Family>();
            CreateMap<UpdateFamilyCmd, Family>();

            CreateMap<GunMan, GunManDetailDto>().ReverseMap();
            //CreateMap<GunMan, FamilyDetailDto>().ReverseMap();
            CreateMap<CreateGunManCmd, GunMan>();
            CreateMap<UpdateGunManCmd, GunMan>();

            CreateMap<InsuranceNominee, InsuranceNomineeDetailDto>().ReverseMap();
            CreateMap<CreateInsNomineeCmd, InsuranceNominee>();
            CreateMap<UpdateInsNomineeCmd, InsuranceNominee>();

            CreateMap<Insurance, InsuranceDetailDto>().ReverseMap();
            CreateMap<CreateInsuranceCmd, Insurance>();
            CreateMap<UpdateInsuranceCmd, Insurance>();

            CreateMap<PoliceVerification, PoliceVerificationDetailDto>().ReverseMap();
            CreateMap<CreatePoliceVeriCmd, PoliceVerification>();
            CreateMap<UpdatePoliceVeriCmd, PoliceVerification>();

            CreateMap<PreviousExperience, PreviousExperienceDetailDto>().ReverseMap();
            CreateMap<CreatePreviousExpCmd, PreviousExperience>();
            CreateMap<UpdatePreviousExpCmd, PreviousExperience>();

            CreateMap<Resignation, ResignationDetailDto>().ReverseMap();
            CreateMap<CreateResignationCmd, Resignation>();
            CreateMap<UpdateResignationCmd, Resignation>();

            CreateMap<SecurityDeposit, SecurityDepositDetailDto>().ReverseMap();
            CreateMap<CreateSecurityDepositCmd, SecurityDeposit>();
            CreateMap<UpdateSecurityDepositCmd, SecurityDeposit>();

            CreateMap<Training, TrainingDetailDto>().ReverseMap();
            CreateMap<CreateTrainingCmd, Training>();
            CreateMap<UpdateTrainingCmd, Training>();

            CreateMap<UserAsset, UserAssetDetailDto>().ReverseMap();
            //CreateMap<UserAsset, UserAssetDetailDto>().ReverseMap();
            CreateMap<CreateUserAssetCmd, UserAsset>();
            CreateMap<UpdateStatusUserAssetCmd, UserAsset>();
            CreateMap<UpdateUserAssetCmd, UserAsset>();

            CreateMap<UserDocument, UserDocumentDetailDto>().ReverseMap();
            CreateMap<UserDocument, UserDocumentDetailDto>();
            CreateMap<CreateUserDocCmd, UserDocument>();
            CreateMap<UpdateUserDocCmd, UserDocument>();
       
            CreateMap<UserGeneralDetail, UserGeneralDetailDto>().ReverseMap();
            CreateMap<CreateUserGeneralDetailCmd, UserGeneralDetail>();
            CreateMap<UpdateUserGeneralDetailCmd, UserGeneralDetail>();

            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<CreateUserProfileCmd, UserProfile>();
            CreateMap<UpdateUserProfileCmd, UserProfile>();
        }
    }
}
