using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Religions_Code",
                table: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_RecruitmentTypes_Code",
                table: "RecruitmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_HighestEducations_Code",
                table: "HighestEducations");

            migrationBuilder.DropIndex(
                name: "IX_Genders_Code",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Designations_Code",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Code",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Code",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CasteCategories_Code",
                table: "CasteCategories");

            migrationBuilder.DropIndex(
                name: "IX_Branches_Code",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Banks_Code",
                table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Code",
                table: "Assets");

            migrationBuilder.CreateTable(
                name: "ApprovalWorkflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    table.PrimaryKey("PK_ApprovalWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalWorkflows_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalWorkflows_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalWorkflows_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CurrentStageOrder = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ApprovedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovedByUserProfileId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
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
                name: "ApprovalStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsFinalStage = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_ApprovalStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalStages_ApprovalWorkflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "ApprovalWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalStages_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalStages_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalStages_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalInstanceHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalInstanceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StageOrder = table.Column<int>(type: "int", nullable: false),
                    ApproverUserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_CreatedByUserId",
                table: "ApprovalStages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_DesignationId",
                table: "ApprovalStages",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_ModifiedByUserId",
                table: "ApprovalStages",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_WorkflowId",
                table: "ApprovalStages",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalWorkflows_CompanyId",
                table: "ApprovalWorkflows",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalWorkflows_CreatedByUserId",
                table: "ApprovalWorkflows",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalWorkflows_ModifiedByUserId",
                table: "ApprovalWorkflows",
                column: "ModifiedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalInstanceHistories");

            migrationBuilder.DropTable(
                name: "ApprovalStages");

            migrationBuilder.DropTable(
                name: "ApprovalInstances");

            migrationBuilder.DropTable(
                name: "ApprovalWorkflows");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_Code",
                table: "Religions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentTypes_Code",
                table: "RecruitmentTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HighestEducations_Code",
                table: "HighestEducations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Code",
                table: "Genders",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designations_Code",
                table: "Designations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CasteCategories_Code",
                table: "CasteCategories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Code",
                table: "Branches",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banks_Code",
                table: "Banks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Code",
                table: "Assets",
                column: "Code",
                unique: true);
        }
    }
}
