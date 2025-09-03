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
                    NavigationNodeId = Guid.Parse("359B62B8-F29C-423D-BBA2-78C164C7762C"), //navigation Node
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("E591F87A-535E-430E-A38F-20C2228BAB3F"),
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
                    NavigationNodeId = Guid.Parse("4956B6A2-DD9D-4D7D-85BB-6961076C4F13"), 
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("D7C6B998-C97E-4235-8E9E-E3661AA6753D"),
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
                    NavigationNodeId = Guid.Parse("12A135F3-D536-4250-ACBF-A38AAD2D802A"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("5A770876-0D03-4841-BFE0-7C56D4B561D2"),
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
                    NavigationNodeId = Guid.Parse("C5571635-29DC-4196-9091-A866C1DA3BC4"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("FC58CB5D-D393-4D89-B0FE-7BCB1B013061"),
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
                    NavigationNodeId = Guid.Parse("028F48A9-A50D-495A-A27E-39C84DA74B9A"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("734DB850-8030-4F9E-8A14-20AE10AE8CB3"),
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
                    NavigationNodeId = Guid.Parse("A394A640-1C19-4949-9795-5321E7E55C90"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("83277279-1AE9-49E5-96F6-579E53918CCA"),
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
                    NavigationNodeId = Guid.Parse("984FB724-F924-40C8-B667-753ABD515A49"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("A51AA7B3-CC4A-4191-A061-8CECE9C11A75"),
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
                    NavigationNodeId = Guid.Parse("E49F315D-4ED0-4002-80AD-D81001FE0D1A"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("75D38D82-7F26-488E-8BD9-0EAEA1B08633"),
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
                    NavigationNodeId = Guid.Parse("B73A59F0-CDD5-4895-A0E7-FEEA45FF5511"),
                    RoleId = roleIdAdmin, // Admin role
                    DateCreated = DateCreatedUtc,
                    DateModified = DateCreatedUtc,
                    CreatedByUserId = UserId,
                    ModifiedByUserId = UserId,
                    CreatedByUserName = userName,
                    ModifiedByUserName = userName,
                },
                new NavigationNodeRole
                {
                    NavigationNodeId = Guid.Parse("57EC63E1-52D5-44CC-A9D1-CDED389F2014"),
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
