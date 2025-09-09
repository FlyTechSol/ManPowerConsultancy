using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApprovalWorkflows",
                columns: new[] { "Id", "CompanyId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "WorkflowType" },
                values: new object[] { new Guid("b8517dd6-6c6d-4c2c-8db7-95cae11791a6"), new Guid("489d4544-5461-4132-aa29-688758627c98"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "StaffApproval" });

            migrationBuilder.InsertData(
                table: "ApprovalStages",
                columns: new[] { "Id", "ApprovalMode", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "IsDeleted", "IsFinalStage", "ModifiedByUserId", "ModifiedByUserName", "Order", "WorkflowId" },
                values: new object[,]
                {
                    { new Guid("b003080e-2752-4b5a-abf3-d2da565ee750"), "Sequential", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, true, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", 3, new Guid("b8517dd6-6c6d-4c2c-8db7-95cae11791a6") },
                    { new Guid("b1ef1e9f-f327-4a47-8c2d-e94414872f77"), "Sequential", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", 2, new Guid("b8517dd6-6c6d-4c2c-8db7-95cae11791a6") },
                    { new Guid("dbc65a3b-142a-4a90-a46c-168ab69ca695"), "Sequential", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", 1, new Guid("b8517dd6-6c6d-4c2c-8db7-95cae11791a6") }
                });

            migrationBuilder.InsertData(
                table: "ApprovalStageApprovers",
                columns: new[] { "Id", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DesignationId", "IsDeleted", "IsMandatory", "ModifiedByUserId", "ModifiedByUserName", "StageId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4cec1bdc-a38c-480f-b227-38fcab69d949"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, true, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("b003080e-2752-4b5a-abf3-d2da565ee750"), new Guid("08dded4a-1f34-4190-86c3-bf1dc04eff50") },
                    { new Guid("6a122142-5f03-4087-b533-2627bbdf7805"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a2d980ac-3fb9-4eed-a5e1-918b64285f05"), false, true, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("b1ef1e9f-f327-4a47-8c2d-e94414872f77"), null },
                    { new Guid("db1f43f1-77f1-40b5-93ac-10209f66a4f7"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, true, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("dbc65a3b-142a-4a90-a46c-168ab69ca695"), new Guid("08ddeecf-697f-4ac9-8c62-6bc3e7ed5640") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApprovalStageApprovers",
                keyColumn: "Id",
                keyValue: new Guid("4cec1bdc-a38c-480f-b227-38fcab69d949"));

            migrationBuilder.DeleteData(
                table: "ApprovalStageApprovers",
                keyColumn: "Id",
                keyValue: new Guid("6a122142-5f03-4087-b533-2627bbdf7805"));

            migrationBuilder.DeleteData(
                table: "ApprovalStageApprovers",
                keyColumn: "Id",
                keyValue: new Guid("db1f43f1-77f1-40b5-93ac-10209f66a4f7"));

            migrationBuilder.DeleteData(
                table: "ApprovalStages",
                keyColumn: "Id",
                keyValue: new Guid("b003080e-2752-4b5a-abf3-d2da565ee750"));

            migrationBuilder.DeleteData(
                table: "ApprovalStages",
                keyColumn: "Id",
                keyValue: new Guid("b1ef1e9f-f327-4a47-8c2d-e94414872f77"));

            migrationBuilder.DeleteData(
                table: "ApprovalStages",
                keyColumn: "Id",
                keyValue: new Guid("dbc65a3b-142a-4a90-a46c-168ab69ca695"));

            migrationBuilder.DeleteData(
                table: "ApprovalWorkflows",
                keyColumn: "Id",
                keyValue: new Guid("b8517dd6-6c6d-4c2c-8db7-95cae11791a6"));
        }
    }
}
