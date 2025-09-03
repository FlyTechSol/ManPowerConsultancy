using MC.Domain.Entity.Navigation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MC.Persistence.Configurations.Navigation
{
    public class NavigationNodeConfiguration : IEntityTypeConfiguration<MC.Domain.Entity.Navigation.NavigationNode>
    {
        public void Configure(EntityTypeBuilder<MC.Domain.Entity.Navigation.NavigationNode> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Title).HasMaxLength(100);
            builder.Property(z => z.Url).HasMaxLength(256);
            builder.Property(z => z.IconUrl).HasMaxLength(100);

            // Self-referencing relationship (tree)
            builder
                .HasOne(n => n.Parent)
                .WithMany(n => n.Children)
                .HasForeignKey(n => n.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
            var userName = "System Admin";

            builder.HasData(
                new NavigationNode
                {
                    Id = Guid.Parse("{359B62B8-F29C-423D-BBA2-78C164C7762C}"),
                    Title = "Dashboard",
                    Url = "dashboard",
                    IconUrl = "dashboard-icon",
                    DisplayOrder = 1,
                    ParentId = null,
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{E591F87A-535E-430E-A38F-20C2228BAB3F}"),
                    Title = "Master Data",
                    Url = "#",
                    IconUrl = "Dashboard",
                    DisplayOrder = 2,
                    ParentId = null,
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    Title = "Company",
                    Url = "#",
                    IconUrl = "Dashboard",
                    DisplayOrder = 2,
                    ParentId = Guid.Parse("{E591F87A-535E-430E-A38F-20C2228BAB3F}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{D7C6B998-C97E-4235-8E9E-E3661AA6753D}"),
                    Title = "Asset",
                    Url = "admin/assets",
                    IconUrl = "Dashboard",
                    DisplayOrder = 1,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{12A135F3-D536-4250-ACBF-A38AAD2D802A}"),
                    Title = "Bank",
                    Url = "admin/banks",
                    IconUrl = "Dashboard",
                    DisplayOrder = 2,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{5A770876-0D03-4841-BFE0-7C56D4B561D2}"),
                    Title = "Branch",
                    Url = "admin/branch",
                    IconUrl = "Dashboard",
                    DisplayOrder = 3,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{C5571635-29DC-4196-9091-A866C1DA3BC4}"),
                    Title = "Category",
                    Url = "admin/categories",
                    IconUrl = "Dashboard",
                    DisplayOrder = 4,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{FC58CB5D-D393-4D89-B0FE-7BCB1B013061}"),
                    Title = "Designation",
                    Url = "admin/designations",
                    IconUrl = "Dashboard",
                    DisplayOrder = 5,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{028F48A9-A50D-495A-A27E-39C84DA74B9A}"),
                    Title = "Document Type",
                    Url = "admin/documenttypes",
                    IconUrl = "Dashboard",
                    DisplayOrder = 6,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{734DB850-8030-4F9E-8A14-20AE10AE8CB3}"),
                    Title = "Recruitment Type",
                    Url = "admin/recruitmenttypes",
                    IconUrl = "Dashboard",
                    DisplayOrder = 7,
                    ParentId = Guid.Parse("{4956B6A2-DD9D-4D7D-85BB-6961076C4F13}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{A394A640-1C19-4949-9795-5321E7E55C90}"),
                    Title = "General",
                    Url = "#",
                    IconUrl = "Dashboard",
                    DisplayOrder = 1,
                    ParentId = Guid.Parse("{E591F87A-535E-430E-A38F-20C2228BAB3F}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{83277279-1AE9-49E5-96F6-579E53918CCA}"),
                    Title = "Caste Category",
                    Url = "admin/caste-categories",
                    IconUrl = "Dashboard",
                    DisplayOrder = 1,
                    ParentId = Guid.Parse("{A394A640-1C19-4949-9795-5321E7E55C90}"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{984FB724-F924-40C8-B667-753ABD515A49}"),
                    Title = "Country",
                    Url = "admin/countries",
                    IconUrl = "Dashboard",
                    DisplayOrder = 2,
                    ParentId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{A51AA7B3-CC4A-4191-A061-8CECE9C11A75}"),
                    Title = "Gender",
                    Url = "admin/genders",
                    IconUrl = "Dashboard",
                    DisplayOrder = 3,
                    ParentId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{E49F315D-4ED0-4002-80AD-D81001FE0D1A}"),
                    Title = "Highest Education",
                    Url = "admin/highesteducations",
                    IconUrl = "Dashboard",
                    DisplayOrder = 4,
                    ParentId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{75D38D82-7F26-488E-8BD9-0EAEA1B08633}"),
                    Title = "Religion",
                    Url = "admin/religions",
                    IconUrl = "Dashboard",
                    DisplayOrder = 5,
                    ParentId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{B73A59F0-CDD5-4895-A0E7-FEEA45FF5511}"),
                    Title = "Title",
                    Url = "admin/titles",
                    IconUrl = "Dashboard",
                    DisplayOrder = 6,
                    ParentId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNode
                {
                    Id = Guid.Parse("{57EC63E1-52D5-44CC-A9D1-CDED389F2014}"),
                    Title = "Zip Code",
                    Url = "admin/zipcodes",
                    IconUrl = "Dashboard",
                    DisplayOrder = 7,
                    ParentId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    IsActive = true,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                }
            );

        }
    }
}
