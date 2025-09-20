using MC.Domain.Entity.Navigation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MC.Persistence.Configurations.Navigation
{
    public class NavigationNodeRoleConfiguration : IEntityTypeConfiguration<MC.Domain.Entity.Navigation.NavigationNodeRole>
    {
        public void Configure(EntityTypeBuilder<MC.Domain.Entity.Navigation.NavigationNodeRole> builder)
        {
            // Composite key
            builder.HasKey(nr => new { nr.NavigationNodeId, nr.RoleId });

            // Relationships
            builder
                .HasOne(nr => nr.NavigationNode)
                .WithMany(n => n.NavigationNodeRoles)
                .HasForeignKey(nr => nr.NavigationNodeId);

            builder
                .HasOne(nr => nr.Role)
                .WithMany()
                .HasForeignKey(nr => nr.RoleId);

            Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
            var userName = "System Admin";
            var roleIdAdmin = Guid.Parse("BA2E09D3-8A52-48A5-A4A9-178E53D60FDE"); //Administrator
            var roleIdHR = Guid.Parse("A03DF03E-0CA2-4C5A-808A-626BFC2B9AE8"); //HR
            builder.HasData(
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("359B62B8-F29C-423D-BBA2-78C164C7762C"), // Dashboard
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("E591F87A-535E-430E-A38F-20C2228BAB3F"), // Master Data
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"), // Master Data - General
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("83277279-1AE9-49E5-96F6-579E53918CCA"), // Master Data - General - Caste Categories
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("984FB724-F924-40C8-B667-753ABD515A49"), // Master Data - General - Countries
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("A51AA7B3-CC4A-4191-A061-8CECE9C11A75"), // Master Data - General - Genders
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("E49F315D-4ED0-4002-80AD-D81001FE0D1A"), // Master Data - General - Highest Educations
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("75D38D82-7F26-488E-8BD9-0EAEA1B08633"), // Master Data - General - Religions
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("B73A59F0-CDD5-4895-A0E7-FEEA45FF5511"), // Master Data - General - Titles
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("57EC63E1-52D5-44CC-A9D1-CDED389F2014"), // Master Data - General - Zipcodes
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("4956B6A2-DD9D-4D7D-85BB-6961076C4F13"), // Master Data - Company
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("D7C6B998-C97E-4235-8E9E-E3661AA6753D"), // Master Data - Company - Assets
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("12A135F3-D536-4250-ACBF-A38AAD2D802A"), // Master Data - Company - Banks
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("5A770876-0D03-4841-BFE0-7C56D4B561D2"), // Master Data - Company - Branchs
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("C5571635-29DC-4196-9091-A866C1DA3BC4"), // Master Data - Company - Categories
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("FC58CB5D-D393-4D89-B0FE-7BCB1B013061"), // Master Data - Company - Designations
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("028F48A9-A50D-495A-A27E-39C84DA74B9A"), // Master Data - Company - Document Types
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("734DB850-8030-4F9E-8A14-20AE10AE8CB3"), // Master Data - Company - Recruitment Types
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("4D156919-C672-43DF-AA19-D93E975D5BDA"), // Master Data - Company - Menu
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("F80AB6D3-DADF-45E9-81AD-462679804C33"), // Staff Profiles
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("C414E1D3-C63C-4EAF-AF0D-EAB721CCC5A5"), // Registeration
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("3F484034-AFC6-4853-A76C-C064B34C2C84"), // Organizations
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("358AA86A-FC2E-4BB5-80B5-2A29892E8432"), // Organizations - Companies
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("E32C3111-85B2-46C7-B2C8-3F65C1F0ADEB"), // Organizations - Client Masters
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("F0002561-462E-4767-8F5E-08BFD53F42F0"), // Organizations - Client Units
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("5C8F1888-76E1-4dE2-B848-E2DD181CC2F4"), // Approval
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("E19C5A99-DC2C-4E23-8F73-71C79C2966F7"), // Approval - Approval Workflows
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("8D9A9DDf-B3C3-4E95-B76E-A6BA646D0C01"), // Approval - Approval Stages
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("CA0BB9E6-EE53-4143-9EDB-7CE118804B5B"), // Approval - Approval Stage Approvers
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("BF88A20B-F140-4B74-8E87-C4A1B39F3A7F"), // Reports
                    RoleId = roleIdAdmin,
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("50396E86-CB2E-4884-BEA0-E9083E205E4B"), // Reports - Staff Reports
                    RoleId = roleIdAdmin,
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
