using AutoMapper;
using MC.Application.Features.Master.Asset.Command.Create;
using MC.Application.Features.Master.Asset.Command.Update;
using MC.Application.Features.Master.Bank.Command.Create;
using MC.Application.Features.Master.Bank.Command.Update;
using MC.Application.Features.Master.Branch.Command.Create;
using MC.Application.Features.Master.Branch.Command.Update;
using MC.Application.Features.Master.CasteCategory.Command.Create;
using MC.Application.Features.Master.CasteCategory.Command.Update;
using MC.Application.Features.Master.Category.Command.Create;
using MC.Application.Features.Master.Category.Command.Update;
using MC.Application.Features.Master.Country.Command.Create;
using MC.Application.Features.Master.Country.Command.Update;
using MC.Application.Features.Master.Designation.Command.Create;
using MC.Application.Features.Master.Designation.Command.Update;
using MC.Application.Features.Master.DocumentType.Command.Create;
using MC.Application.Features.Master.DocumentType.Command.Update;
using MC.Application.Features.Master.Gender.Command.Create;
using MC.Application.Features.Master.Gender.Command.Update;
using MC.Application.Features.Master.HighestEducation.Command.Create;
using MC.Application.Features.Master.HighestEducation.Command.Update;
using MC.Application.Features.Master.RecruitmentType.Command.Create;
using MC.Application.Features.Master.RecruitmentType.Command.Update;
using MC.Application.Features.Master.Religion.Command.Create;
using MC.Application.Features.Master.Religion.Command.Update;
using MC.Application.Features.Master.Title.Command.Create;
using MC.Application.Features.Master.Title.Command.Update;
using MC.Application.Features.Master.ZipCode.Command.Create;
using MC.Application.Features.Master.ZipCode.Command.Update;
using MC.Application.Features.Registration.UserAsset.Command.Create;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.MappingProfiles
{
    public class MasterProfile : Profile
    {
        public MasterProfile()
        {
            CreateMap<Asset, AssetDto>().ReverseMap();
            CreateMap<Asset, AssetDetailDto>();
            CreateMap<CreateUserAssetCmd, Asset>();
            CreateMap<UpdateAssetCmd, Asset>();

            CreateMap<Bank, BankDto>().ReverseMap();
            CreateMap<Bank, BankDetailDto>();
            CreateMap<CreateBankCmd, Bank>();
            CreateMap<UpdateBankCmd, Bank>();

            CreateMap<Branch, BranchDetailDto>().ReverseMap();
            CreateMap<Branch, BranchDetailDto>();
            CreateMap<CreateBranchCmd, Branch>();
            CreateMap<UpdateBranchCmd, Branch>();

            CreateMap<CasteCategory, CasteCategoryDto>().ReverseMap();
            CreateMap<CasteCategory, CasteCategoryDetailDto>();
            CreateMap<CreateCasteCategoryCmd, CasteCategory>();
            CreateMap<UpdateCasteCategoryCmd, CasteCategory>();

            CreateMap<Category, CategoryDetailDto>().ReverseMap();
            CreateMap<Category, CategoryDetailDto>();
            CreateMap<CreateCategoryCmd, Category>();
            CreateMap<UpdateCategoryCmd, Category>();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryDetailDto>();
            CreateMap<CreateCountryCmd, Country>();
            CreateMap<UpdateCountryCmd, Country>();

            CreateMap<Designation, DesignationDetailDto>().ReverseMap();
            CreateMap<Designation, DesignationDetailDto>();
            CreateMap<CreateDesignationCmd, Designation>();
            CreateMap<UpdateDesignationCmd, Designation>();

            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeDetailDto>();
            CreateMap<CreateDocumentTypeCmd, DocumentType>();
            CreateMap<UpdateDocumentTypeCmd, DocumentType>();

            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Gender, GenderDetailDto>();
            CreateMap<CreateGenderCmd, Gender>();
            CreateMap<UpdateGenderCmd, Gender>();

            CreateMap<HighestEducation, HighestEducationDto>().ReverseMap();
            CreateMap<HighestEducation, HighestEducationDetailDto>();
            CreateMap<CreateHighestEducationCmd, HighestEducation>();
            CreateMap<UpdateHighestEducationCmd, HighestEducation>();

            CreateMap<RecruitmentType, RecruitmentTypeDto>().ReverseMap();
            CreateMap<RecruitmentType, RecruitmentTypeDetailDto>();
            CreateMap<CreateRecruitmentTypeCmd, RecruitmentType>();
            CreateMap<UpdateRecruitmentTypeCmd, RecruitmentType>();

            CreateMap<Religion, ReligionDto>().ReverseMap();
            CreateMap<Religion, ReligionDetailDto>();
            CreateMap<CreateReligionCmd, Religion>();
            CreateMap<UpdateReligionCmd, Religion>();

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
