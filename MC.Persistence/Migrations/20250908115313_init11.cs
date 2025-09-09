using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalStages_Designations_DesignationId",
                table: "ApprovalStages");

            migrationBuilder.DropTable(
                name: "ApprovalInstanceHistories");

            migrationBuilder.DropTable(
                name: "ApprovalInstances");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalStages_DesignationId",
                table: "ApprovalStages");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "ApprovalStages");

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowType",
                table: "ApprovalWorkflows",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalMode",
                table: "ApprovalStages",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_ApprovalWorkflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "ApprovalWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_AspNetUsers_RequestedBy",
                        column: x => x.RequestedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalStageApprovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DesignationId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsMandatory = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStageApprovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalStageApprovers_ApprovalStages_StageId",
                        column: x => x.StageId,
                        principalTable: "ApprovalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalStageApprovers_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalStageApprovers_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalStageApprovers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalStageApprovers_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalRequestStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStages_ApprovalRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "ApprovalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStages_ApprovalStages_StageId",
                        column: x => x.StageId,
                        principalTable: "ApprovalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStages_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStages_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestStageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApproverId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Action = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comments = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalActions_ApprovalRequestStages_RequestStageId",
                        column: x => x.RequestStageId,
                        principalTable: "ApprovalRequestStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalActions_AspNetUsers_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalActions_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalActions_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalActions_ApproverId",
                table: "ApprovalActions",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalActions_CreatedByUserId",
                table: "ApprovalActions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalActions_ModifiedByUserId",
                table: "ApprovalActions",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalActions_RequestStageId",
                table: "ApprovalActions",
                column: "RequestStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_CreatedByUserId",
                table: "ApprovalRequests",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_ModifiedByUserId",
                table: "ApprovalRequests",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_RequestedBy",
                table: "ApprovalRequests",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_WorkflowId",
                table: "ApprovalRequests",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_CreatedByUserId",
                table: "ApprovalRequestStages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_ModifiedByUserId",
                table: "ApprovalRequestStages",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_RequestId",
                table: "ApprovalRequestStages",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_StageId",
                table: "ApprovalRequestStages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_CreatedByUserId",
                table: "ApprovalStageApprovers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_DesignationId",
                table: "ApprovalStageApprovers",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_ModifiedByUserId",
                table: "ApprovalStageApprovers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_StageId",
                table: "ApprovalStageApprovers",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_UserId",
                table: "ApprovalStageApprovers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalActions");

            migrationBuilder.DropTable(
                name: "ApprovalStageApprovers");

            migrationBuilder.DropTable(
                name: "ApprovalRequestStages");

            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropColumn(
                name: "ApprovalMode",
                table: "ApprovalStages");

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowType",
                table: "ApprovalWorkflows",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                table: "ApprovalStages",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "ApprovalInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovedByUserProfileId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStageOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsApproved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModifiedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalInstances_ApprovalWorkflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "ApprovalWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalInstances_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalInstances_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalInstances_UserProfiles_ApprovedByUserProfileId",
                        column: x => x.ApprovedByUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalInstanceHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalInstanceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApproverUserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ApprovedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModifiedByUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StageOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalInstanceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalInstanceHistories_ApprovalInstances_ApprovalInstance~",
                        column: x => x.ApprovalInstanceId,
                        principalTable: "ApprovalInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalInstanceHistories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalInstanceHistories_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalInstanceHistories_UserProfiles_ApproverUserProfileId",
                        column: x => x.ApproverUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_DesignationId",
                table: "ApprovalStages",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstanceHistories_ApprovalInstanceId",
                table: "ApprovalInstanceHistories",
                column: "ApprovalInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstanceHistories_ApproverUserProfileId",
                table: "ApprovalInstanceHistories",
                column: "ApproverUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstanceHistories_CreatedByUserId",
                table: "ApprovalInstanceHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstanceHistories_ModifiedByUserId",
                table: "ApprovalInstanceHistories",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstances_ApprovedByUserProfileId",
                table: "ApprovalInstances",
                column: "ApprovedByUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstances_CreatedByUserId",
                table: "ApprovalInstances",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstances_ModifiedByUserId",
                table: "ApprovalInstances",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalInstances_WorkflowId",
                table: "ApprovalInstances",
                column: "WorkflowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalStages_Designations_DesignationId",
                table: "ApprovalStages",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
