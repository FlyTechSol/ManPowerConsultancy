using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Banks_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CasteCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CasteCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasteCategories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasteCategories_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompanyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LegalName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationNumber = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPan = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DialCode = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Designations_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Purpose = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TemplateName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Genders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genders_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genders_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HighestEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_HighestEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighestEducations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HighestEducations_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuDisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NavigationURL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NavigationNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
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
                    table.PrimaryKey("PK_NavigationNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavigationNodes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NavigationNodes_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NavigationNodes_NavigationNodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "NavigationNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecruitmentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RecruitmentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruitmentTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitmentTypes_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Religions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Religions_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Religions_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFemale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titles_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Titles_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Zipcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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
                    table.PrimaryKey("PK_ZipCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZipCodes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZipCodes_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalWorkflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkflowType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
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
                name: "ClientMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClientName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectCost = table.Column<double>(type: "double", precision: 18, scale: 2, nullable: false),
                    ProjectLocation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_ClientMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientMasters_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientMasters_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientMasters_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistrationSequences",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LastRegistrationId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationSequences", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_RegistrationSequences_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationSequences_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationSequences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuItemDisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NavigationNodeRoles",
                columns: table => new
                {
                    NavigationNodeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationNodeRoles", x => new { x.NavigationNodeId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_NavigationNodeRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavigationNodeRoles_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NavigationNodeRoles_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NavigationNodeRoles_NavigationNodes_NavigationNodeId",
                        column: x => x.NavigationNodeId,
                        principalTable: "NavigationNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalWorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                        name: "FK_ApprovalRequests_ApprovalWorkflows_ApprovalWorkflowId",
                        column: x => x.ApprovalWorkflowId,
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
                name: "ApprovalStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalWorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsFinalStage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ApprovalMode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
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
                    table.PrimaryKey("PK_ApprovalStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalStages_ApprovalWorkflows_ApprovalWorkflowId",
                        column: x => x.ApprovalWorkflowId,
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClientMasterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UnitName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitLocation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxHeadCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_ClientUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientUnits_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientUnits_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientUnits_ClientMasters_ClientMasterId",
                        column: x => x.ClientMasterId,
                        principalTable: "ClientMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApprovalRequestStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalRequestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalStageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                        name: "FK_ApprovalRequestStages_ApprovalRequests_ApprovalRequestId",
                        column: x => x.ApprovalRequestId,
                        principalTable: "ApprovalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStages_ApprovalStages_ApprovalStageId",
                        column: x => x.ApprovalStageId,
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
                name: "ApprovalStageApprovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ApprovalStageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
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
                        name: "FK_ApprovalStageApprovers_ApprovalStages_ApprovalStageId",
                        column: x => x.ApprovalStageId,
                        principalTable: "ApprovalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalStageApprovers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ApprovalStageApprovers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ClientMasterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ClientUnitId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DesignationId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RegistrationId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TitleId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecruitmentTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AadhaarNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PanNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UanNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsicNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlternatePhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfJoining = table.Column<DateTime>(type: "date", nullable: true),
                    GenderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdentityMarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserProfileStatus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
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
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_ClientMasters_ClientMasterId",
                        column: x => x.ClientMasterId,
                        principalTable: "ClientMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_ClientUnits_ClientUnitId",
                        column: x => x.ClientUnitId,
                        principalTable: "ClientUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_RecruitmentTypes_RecruitmentTypeId",
                        column: x => x.RecruitmentTypeId,
                        principalTable: "RecruitmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
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

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PinCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BankId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IFSCCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPassbookAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PassbookUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    HeightCm = table.Column<double>(type: "double", precision: 5, scale: 2, nullable: true),
                    WeightKg = table.Column<double>(type: "double", precision: 5, scale: 2, nullable: true),
                    ChestCm = table.Column<double>(type: "double", precision: 5, scale: 2, nullable: true),
                    ShoulderCm = table.Column<double>(type: "double", precision: 5, scale: 2, nullable: true),
                    HairColour = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EyeColour = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_BodyMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Communications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonalMobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfficialMobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LandlineNumber1 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LandlineNumber2 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalEmail = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfficialEmail = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_Communications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communications_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communications_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communications_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeDesignation = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeDepartment = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeContactNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeRelationship = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_EmployeeReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeVerifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VerificationType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgencyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InitiatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Result = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgencyReportUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_EmployeeVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeVerifications_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeVerifications_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeVerifications_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExArmies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServiceNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rank = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchOfService = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalService = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnlistmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ReasonForDischarge = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DischargeCertificateUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_ExArmies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExArmies_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExArmies_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExArmies_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Famlies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Relationship = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPFNominee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PFPercentage = table.Column<double>(type: "double", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelationTo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMinor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDependent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsResidingWithEmployee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_Famlies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Famlies_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Famlies_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Famlies_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GunMen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GunLicenceName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GunLicenseNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeaponNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeaponType = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MakeOfCompany = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GunLicenseIssuedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GunLicenseIssuedDate = table.Column<DateTime>(type: "date", nullable: true),
                    GunLicenseExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    GunLicenseRemarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Jurisdiction = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicenceAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_GunMen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GunMen_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GunMen_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GunMen_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InsuranceNominees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NominatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NominatedByFather = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoldierNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoldierRank = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoldierUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NominatedByDoB = table.Column<DateTime>(type: "date", nullable: false),
                    NominatedByPermanentAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NominatedByCorrespondenceAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomineeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelationWithNominee = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomineeFather = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomineeDoB = table.Column<DateTime>(type: "date", nullable: false),
                    NomineeByPermanentAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomineeByCorrespondenceAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_InsuranceNominees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceNominees_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceNominees_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceNominees_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InsuranceCompanyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PolicyNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PolicyStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    PolicyEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PolicyRemarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insurances_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insurances_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoliceVerifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PoliceStationName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerificationStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    VerificationRemarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_PoliceVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceVerifications_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoliceVerifications_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoliceVerifications_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreviousExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompanyWorked = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Place = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonForLeft = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: true),
                    LeftDate = table.Column<DateTime>(type: "date", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_PreviousExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousExperiences_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreviousExperiences_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreviousExperiences_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resignations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResignationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reason = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
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
                    table.PrimaryKey("PK_Resignations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resignations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resignations_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resignations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SecurityDeposits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReciptNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false),
                    RefundableAmount = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false),
                    NonRefundableAmount = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    Remark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_SecurityDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityDeposits_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecurityDeposits_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecurityDeposits_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TrainingName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrainingInstitute = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrainingStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    TrainingEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    TrainingRemarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrainingCertificateUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AssetId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateOfIssue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SerialNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssetValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    Remarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReturnable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsReturned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ReturnStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReturnRemarks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_UserAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAssets_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAssets_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAssets_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocumentTypeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FilePath = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocuments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDocuments_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDocuments_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDocuments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserGeneralDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FatherName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotherName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpouseName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReligionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CountryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CasteCategoryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DifferentlyAbled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HighestEducationId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    MaritalStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdentityMarks = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    table.PrimaryKey("PK_UserGeneralDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_CasteCategories_CasteCategoryId",
                        column: x => x.CasteCategoryId,
                        principalTable: "CasteCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_HighestEducations_HighestEducationId",
                        column: x => x.HighestEducationId,
                        principalTable: "HighestEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGeneralDetails_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayOrder", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("13ba1d43-1f90-466b-8b67-6aeb5e32581f"), null, 1, "Employee", "EMPLOYEE" },
                    { new Guid("2c157266-193a-4f44-8512-950b1d025408"), null, 3, "SiteIncharge", "SITEINCHARGE" },
                    { new Guid("2cdf7283-eaf0-4f5a-b44a-4def5ed91da8"), null, 5, "GeneralManager", "GENERALMANAGER" },
                    { new Guid("2d149421-8f16-4a0a-869e-ea05653c89f3"), null, 3, "Director", "DIRECTOR" },
                    { new Guid("5e7d2008-e189-48ac-b7b2-b7291c697715"), null, 4, "Accountant", "ACCOUNTANT" },
                    { new Guid("88bd4b2e-bc97-4666-b032-ac61f5c00477"), null, 6, "HR Head", "Hr Head" },
                    { new Guid("94231286-f784-4141-9087-08050f9c0acf"), null, 2, "Supervisor", "SUPERVISOR" },
                    { new Guid("a03df03e-0ca2-4c5a-808a-626bfc2b9ae8"), null, 6, "HR", "HR" },
                    { new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), null, 6, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2e9cfc1e-c228-41b5-bada-2f859ec9de32"), 0, "A494A604-0DEA-42B2-B262-BDEAFC80F7E1", "hr@localhost.com", true, true, false, null, "HR@LOCALHOST.COM", "HR@LOCALHOST.COM", "AQAAAAIAAYagAAAAECGbYsKKzFkirUhdIdsX5TILfgFqOGd4ahSusBphPeyIET5sywM7o7zfaTXbWNpKeQ==", null, false, null, false, "hr@localhost.com" },
                    { new Guid("38ccee5b-9eab-49a0-a30f-d6cb52e7d11d"), 0, "A494A604-0DEA-42B2-B262-BDEAFC80F7E1", "hrhead@localhost.com", true, true, false, null, "HRHEAD@LOCALHOST.COM", "HRHEAD@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHnbMxFSYD2om+wFtkEh2Arc9PZSDcfmJMAbQ3K5tQn8NRBx5rp9pwzi6DxxE4bQgg==", null, false, null, false, "hrhead@localhost.com" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, "905afbf7-cb82-4046-aab6-2e634a9fc0cc", "admin@localhost.com", true, true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIZEnobWLWVm+KqYua3eConzPpMHEraORI5xGWGyIXsrYHZGO8Z/Fgvj2Frc+Wex8A==", null, false, null, false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a03df03e-0ca2-4c5a-808a-626bfc2b9ae8"), new Guid("2e9cfc1e-c228-41b5-bada-2f859ec9de32") },
                    { new Guid("88bd4b2e-bc97-4666-b032-ac61f5c00477"), new Guid("38ccee5b-9eab-49a0-a30f-d6cb52e7d11d") },
                    { new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("7f94266b-59c9-4414-ad04-dba60100f74e"), "Adapter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Adapter" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000001"), "All In One Desktop", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "All In One Desktop" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000002"), "Bluetooth Wireless Mouse", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Bluetooth Wireless Mouse" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000003"), "Combo Keyboard Mouse", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Combo Keyboard Mouse" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000004"), "Desktop", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Desktop" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000005"), "External Hard Disk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "External Hard Disk" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000006"), "Hard Disk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hard Disk" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000007"), "Keyboard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Keyboard" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000008"), "Keys", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Keys" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000009"), "Laptop", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Laptop" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00000a"), "Laptop Bag", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Laptop Bag" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00000b"), "Legal Documents", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Legal Documents" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00000c"), "Mobile", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mobile" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00000d"), "Monitor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Monitor" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00000e"), "Mouse", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mouse" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00000f"), "Mouse Paid", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mouse Paid" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000010"), "Pen Drive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pen Drive" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000011"), "Petro Card", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Petro Card" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000012"), "Portable Wi Fi", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Portable Wi Fi" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000013"), "Projector", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Projector" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000014"), "Rack", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Rack" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000015"), "Registers", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Registers" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000016"), "Samsung Tab (T295)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Samsung Tab (T295)" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000017"), "Apple Tab", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Apple Tab" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000018"), "Sim Card", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sim Card" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000019"), "Sound Speaker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sound Speaker" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00001a"), "Stationary", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 27, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Stationary" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00001b"), "Type-C To Lan Adapter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Type-C To Lan Adapter" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00001c"), "Type-C USB Hub", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Type-C USB Hub" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00001d"), "UPS", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UPS" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00001e"), "USB To Lan Connector", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "USB To Lan Connector" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef00001f"), "USB Wifi", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "USB Wifi" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000020"), "Vehicle", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Vehicle" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000021"), "Web-Cam", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 34, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Web-Cam" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000022"), "Wifi Router", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Wifi Router" },
                    { new Guid("a1b2c3d4-e5f6-4711-8899-abcdef000023"), "Wireless Mouse", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Wireless Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("007e68d1-99b7-43c7-a84e-118874adcdd3"), "GOPINATH PATIL PARSIK JANATA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 66, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GOPINATH PATIL PARSIK JANATA SAHAKARI BANK LTD" },
                    { new Guid("009eb91a-9bfb-400b-a080-92d87af9c5f8"), "VIDHARBHA KONKAN GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 224, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "VIDHARBHA KONKAN GRAMIN BANK" },
                    { new Guid("00d1a0b7-6c0c-43bb-9a6d-badda3ef27b9"), "DOMBIVLI NAGARI SAHAKARI BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 59, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DOMBIVLI NAGARI SAHAKARI BANK LIMITED" },
                    { new Guid("02389832-11f7-44f3-b3db-c6e8c2e79395"), "THE WEST BENGAL STATE COOPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 203, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE WEST BENGAL STATE COOPERATIVE BANK LTD" },
                    { new Guid("025b255c-12fd-42c4-939d-b269f1456480"), "AXIS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "AXIS BANK" },
                    { new Guid("074c4fab-6a47-4267-bb32-75d70d68dfa3"), "NKGSB CO-OP BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 120, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NKGSB CO-OP BANK LTD." },
                    { new Guid("074cc2d0-8a54-48cc-9a5e-de32527c2e8b"), "KOTAK MAHINDRA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 104, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KOTAK MAHINDRA BANK" },
                    { new Guid("07911c5f-aaa9-46c1-ad91-ff73cf9d6041"), "UTKAL GRAMYA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 214, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTKAL GRAMYA BANK" },
                    { new Guid("083d844f-2679-48a3-8be6-f7d70c4399d6"), "SVC CO-OPERATIVE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 164, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SVC CO-OPERATIVE BANK LTD." },
                    { new Guid("084a40be-fa93-40bc-b07d-3bd1118f6355"), "ARYAVART UP GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ARYAVART UP GRAMIN BANK" },
                    { new Guid("0861f82b-97e8-4caf-8753-48dd9bd75f32"), "ASSAM COOPERATIVE APEX BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ASSAM COOPERATIVE APEX BANK" },
                    { new Guid("08b3d7c8-2f93-498c-9008-227a56795699"), "UTTARAKHAND STATE CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 221, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTARAKHAND STATE CO-OPERATIVE BANK LTD" },
                    { new Guid("09147bf6-6c31-4e22-8495-8496ea5e4fcb"), "SHARAD NAGARI SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 151, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SHARAD NAGARI SAHAKARI BANK LTD" },
                    { new Guid("0ad7b967-4e06-46be-ad73-f03b4180948b"), "BHAGIRATH GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BHAGIRATH GRAMIN BANK" },
                    { new Guid("0c0944c1-8304-4b11-9289-92d0d8f41505"), "NAINITAL BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 113, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NAINITAL BANK" },
                    { new Guid("0d0f14ff-d4b8-43d4-aac7-ec1278f03fba"), "THE SATARA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 197, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE SATARA SAHAKARI BANK LTD" },
                    { new Guid("0d30f1e2-c8de-4e7b-a123-1fb15dfd89c5"), "THE KARUR VYSYA BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 187, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE KARUR VYSYA BANK LIMITED" },
                    { new Guid("0d667980-7a91-4510-88a4-90e14ac9a458"), "URBAN CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 212, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "URBAN CO-OPERATIVE BANK LTD" },
                    { new Guid("0fc3071a-a205-44f1-b01a-dea02f40e44d"), "THE JALGAON DISTRICT CENTRAL CO-OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 181, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE JALGAON DISTRICT CENTRAL CO-OPERATIVE BANK" },
                    { new Guid("0fd3d106-31af-4ade-abc4-e44f974d1cf6"), "KARUR VYSYA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 99, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KARUR VYSYA BANK" },
                    { new Guid("10047970-d4d3-4b5f-a83d-2e3a95729bb7"), "MANSAROVAR URBAN COOPRATIVE BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 111, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "MANSAROVAR URBAN COOPRATIVE BANK LIMITED" },
                    { new Guid("1025537c-1ad4-4f4c-8c8e-e64f8bd06299"), "SARVA UP GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 148, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SARVA UP GRAMIN BANK" },
                    { new Guid("10717b2a-4663-4617-92bb-518d7b9ce925"), "STANDARD CHARTERED BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 154, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STANDARD CHARTERED BANK" },
                    { new Guid("11d341bb-fd22-4b5b-80c2-c2e5cbe17a28"), "KARNATAKA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 96, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KARNATAKA BANK" },
                    { new Guid("14e6fbca-fe93-4656-b541-3905af47760d"), "PUNJAB NATIONAL BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 138, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PUNJAB NATIONAL BANK" },
                    { new Guid("16fc8083-06bc-4021-9ce3-3630b1103343"), "NAINITAL DISTRICT COOPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 114, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NAINITAL DISTRICT COOPERATIVE BANK" },
                    { new Guid("17749cd7-6c60-4ff0-b2d4-c5f8c0d8fe5b"), "STATE BANK OF HYDERABAD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 156, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STATE BANK OF HYDERABAD" },
                    { new Guid("17a08039-0109-4035-8289-3a5e28dc27a9"), "PRATHMA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 132, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PRATHMA BANK" },
                    { new Guid("1943ea69-4ce2-424d-a8bf-22fa4155e22b"), "BASSEIN CATHOLIC CO-OP BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BASSEIN CATHOLIC CO-OP BANK LTD" },
                    { new Guid("1b756edb-e4f6-4aa3-aeec-1f758d9e4eda"), "THE KANAKAMAHALAKSHMI CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 185, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE KANAKAMAHALAKSHMI CO-OPERATIVE BANK LTD" },
                    { new Guid("1cbaa997-f5ef-4de8-8e13-3e5bfb67ddec"), "JALGAON JANTA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 85, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JALGAON JANTA SAHAKARI BANK LTD" },
                    { new Guid("1d40b380-395d-46d4-89f0-465acd681341"), "INDIAN OVERSEAS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 82, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "INDIAN OVERSEAS BANK" },
                    { new Guid("1d8158dd-394f-4f0b-be1d-ddc316d629f6"), "JALGAON PEOPLES CO-OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 86, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JALGAON PEOPLES CO-OPERATIVE BANK" },
                    { new Guid("1dab31da-a847-4b4c-a032-94c03f702731"), "NEW INDIA CO-OPERATIVE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 119, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NEW INDIA CO-OPERATIVE BANK LTD." },
                    { new Guid("1e72b96b-f49f-4c6f-878d-6302d75d8185"), "KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 105, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KSHETRIYA GRAMIN BANK" },
                    { new Guid("1e7add2a-56cc-4f97-8326-58881199b2d2"), "J D C C BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 84, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "J D C C BANK LTD" },
                    { new Guid("1e93e87f-9ffa-4403-ae3f-4a9edf04f278"), "UTTAR BIHAR GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 217, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTAR BIHAR GRAMIN BANK" },
                    { new Guid("1eefeb0e-eb56-4520-88ca-057e467973c7"), "KHAMGAON URBAN CO-OP BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 103, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KHAMGAON URBAN CO-OP BANK LTD" },
                    { new Guid("20142b1d-2cfc-45e8-b0d6-cb97b795e5d4"), "CHHATTISHGARH RAJYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CHHATTISHGARH RAJYA GRAMIN BANK" },
                    { new Guid("2079d0e5-e7f5-44cb-a629-155584478427"), "ABHYUDAYA CO-OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ABHYUDAYA CO-OPERATIVE BANK" },
                    { new Guid("20fa46f2-d611-4e22-b6a0-fd8ab010aa8f"), "BANDHAN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BANDHAN BANK" },
                    { new Guid("22441372-21a3-49b0-8154-fac693f0c4bf"), "NONE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 121, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NONE" },
                    { new Guid("26181a95-2fe8-4c76-97ce-d280c0a6ac18"), "ANDHRA PRADESH GRAMEENA VIKAS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ANDHRA PRADESH GRAMEENA VIKAS BANK" },
                    { new Guid("2824800f-0f0d-4b59-bd8b-f8bd46da0813"), "FEDERAL BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 63, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "FEDERAL BANK" },
                    { new Guid("28b82d0e-2203-4084-a728-30f4ffd0a7f5"), "ALLAHABAD UP GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ALLAHABAD UP GRAMIN BANK" },
                    { new Guid("2af0b91c-335e-4337-bdb2-1f4abc4f1af7"), "CENTRAL BANK OF INDIA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CENTRAL BANK OF INDIA" },
                    { new Guid("2b479133-9d7d-4bbd-83e0-4447c541f8cf"), "THE THANE BHARAT SAHAKARI BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 200, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE THANE BHARAT SAHAKARI BANK LIMITED" },
                    { new Guid("2b7c1cd8-f170-4c32-bbd5-dca367ae91ca"), "LUCKNOW KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 108, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "LUCKNOW KSHETRIYA GRAMIN BANK" },
                    { new Guid("2d62cb2c-d295-4889-8c44-21a54adf5020"), "DAKSHIN BIHAR GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DAKSHIN BIHAR GRAMIN BANK" },
                    { new Guid("2ef05166-eee9-40a2-aaa5-47d0558f1014"), "RAJASTHAN MARUDHARA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 141, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "RAJASTHAN MARUDHARA GRAMIN BANK" },
                    { new Guid("2f592e05-fc23-4029-bf1c-02141e339997"), "BANK OF BARODA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BANK OF BARODA" },
                    { new Guid("31c938ea-b082-421a-ab6c-e14980aed73a"), "GP PARSIK JANATA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 67, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GP PARSIK JANATA SAHAKARI BANK LTD" },
                    { new Guid("31de070c-96e2-487c-b491-57ceaf97a212"), "THE NAWANAGAR CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 194, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE NAWANAGAR CO-OPERATIVE BANK LTD" },
                    { new Guid("326ba258-460e-4a7f-8259-7db6df73e24e"), "ORIENTAL BANK OF COMMERCE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 123, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ORIENTAL BANK OF COMMERCE" },
                    { new Guid("32d03d7c-1cd6-4b26-8213-84444f0e0912"), "JANTA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 91, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JANTA SAHAKARI BANK LTD" },
                    { new Guid("37dc06ee-fde4-4210-b399-87bd21f83691"), "STATE BANK OF PATIALA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 159, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STATE BANK OF PATIALA" },
                    { new Guid("3928a2ae-b5b1-41b4-83e2-69b7d248cd15"), "UTTARANCHAL GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 222, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTARANCHAL GRAMIN BANK" },
                    { new Guid("3959ae43-cf9e-40d1-95e2-e839002bcf01"), "THE COSMOS CO-OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 174, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE COSMOS CO-OPERATIVE BANK" },
                    { new Guid("3988eeb8-dc98-489e-bf08-51146b5e0298"), "BAREILLY KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BAREILLY KSHETRIYA GRAMIN BANK" },
                    { new Guid("3c182fd0-c1ed-4db2-8850-ce653654e478"), "UTTARAKHAND GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 220, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTARAKHAND GRAMIN BANK" },
                    { new Guid("3c195c5b-04a2-4fc6-84a8-26be17484c49"), "PUNE CANTOMENT SAHAKARI BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 134, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PUNE CANTOMENT SAHAKARI BANK LTD." },
                    { new Guid("3fda0cd1-9b03-40cf-929c-74ae02a3ab80"), "FINCARE SMALL FINANCE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 64, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "FINCARE SMALL FINANCE BANK" },
                    { new Guid("3ffe37e8-ff8c-4956-a7e7-d7e6310b64c5"), "BANK OF INDIA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BANK OF INDIA" },
                    { new Guid("453477bd-dbad-48e4-95a3-42c945d7e879"), "STATE BANK OF TRAVANCORE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 160, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STATE BANK OF TRAVANCORE" },
                    { new Guid("475506dd-7255-43e3-9f35-45b472889ff3"), "THE KANGRA CENTRAL CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 186, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE KANGRA CENTRAL CO-OPERATIVE BANK LTD" },
                    { new Guid("475a8c81-3497-4cb1-9fdf-927c5cf79b44"), "SURYODAY SMALL FINANCE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 163, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SURYODAY SMALL FINANCE BANK LTD" },
                    { new Guid("475e14e0-edc5-4407-9aa9-6c451b7a9ced"), "APNA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "APNA SAHAKARI BANK LTD" },
                    { new Guid("4768c653-8f00-4d1e-b959-dc9f05665e20"), "THE GAYATRI COOPERATIVE URBAN BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 178, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE GAYATRI COOPERATIVE URBAN BANK LTD" },
                    { new Guid("485eab65-286f-4f06-8e3b-837e6b322b2d"), "SARASWAT BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 146, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SARASWAT BANK" },
                    { new Guid("48bc2f6f-373e-4538-86cf-e3b102805138"), "DENA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DENA BANK" },
                    { new Guid("4a57a69e-b303-4ca3-90f7-3188795504f5"), "INDUSLND BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 83, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "INDUSLND BANK" },
                    { new Guid("4ae80e09-1261-4098-b5da-c2df2b15e76e"), "THE SARASWAT CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 196, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE SARASWAT CO-OPERATIVE BANK LTD" },
                    { new Guid("4ccd81c3-cc3a-493a-a490-737ce82cca1a"), "UCO BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 207, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UCO BANK" },
                    { new Guid("4cd9fdd0-a5b1-4cad-bb00-0d588ddb6a09"), "TELANGANA STATE CO-OPERATIVE APEX BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 170, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TELANGANA STATE CO-OPERATIVE APEX BANK LTD" },
                    { new Guid("4d100f12-5cfc-471a-b5e3-8d4c6ec72ec5"), "ARYAVART GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ARYAVART GRAMIN BANK" },
                    { new Guid("4dc7c776-9b8b-4b0d-888d-35213cf8673a"), "SAPTAGIRI GRAMEENA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 145, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SAPTAGIRI GRAMEENA BANK" },
                    { new Guid("4fd7931d-8483-4e04-9e07-08118ea218d6"), "THE JAMMU &amp; KASHMIR BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 183, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE JAMMU &amp; KASHMIR BANK" },
                    { new Guid("506e065c-1145-445c-8e44-3bc2ae61795f"), "HE SHAMRAO VITHAL CO-?OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 73, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HE SHAMRAO VITHAL CO-?OPERATIVE BANK LTD" },
                    { new Guid("50884196-df3c-4ff0-a531-de9e77eaee86"), "THE ANDHRA PRADESH STATE COOP BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 172, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE ANDHRA PRADESH STATE COOP BANK LTD" },
                    { new Guid("509e595b-14b5-475f-8afd-54ff889b2146"), "PRERANA CO OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 133, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PRERANA CO OPERATIVE BANK LTD" },
                    { new Guid("50d5452e-376f-401c-b75c-2d92173952a2"), "THE FEDERAL BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 177, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE FEDERAL BANK" },
                    { new Guid("538dc659-ca3e-4aa6-ad19-a3be90feddde"), "CANARA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 37, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CANARA BANK" },
                    { new Guid("551183d4-5e5e-4b10-9081-82677c2bb1a7"), "PRAGATHI KRISHNA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 130, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PRAGATHI KRISHNA GRAMIN BANK" },
                    { new Guid("556ebcf7-8691-4f8d-a6d3-72580d4a5e81"), "DARUSSALAM BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 51, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DARUSSALAM BANK" },
                    { new Guid("57c17b5a-f8cb-4704-834a-d52e4dfc6de5"), "CITI BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 44, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CITI BANK" },
                    { new Guid("5881f4e9-88d7-45c7-a17f-612c4dda0c78"), "COSMOS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 48, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "COSMOS BANK" },
                    { new Guid("59d3dc35-ee3a-47ea-bc6a-5c3bde26cd36"), "KANPUR KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 95, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KANPUR KSHETRIYA GRAMIN BANK" },
                    { new Guid("5aa43a26-b4e1-450a-8f43-6216c5ac650f"), "UTTAR PRADESH GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 219, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTAR PRADESH GRAMIN BANK" },
                    { new Guid("5bbd93ba-96f2-438f-9725-1712267cdbe6"), "ESAF SMALL FINANCE BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 61, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ESAF SMALL FINANCE BANK LIMITED" },
                    { new Guid("5bfea989-2e26-477f-a8bd-bc46f94dd8e8"), "KARNATAKA VIKASH GRAMEEN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 98, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KARNATAKA VIKASH GRAMEEN BANK" },
                    { new Guid("5d16dc6b-4cd9-442d-b9eb-7443adaeba78"), "UJJIVAN SMALL FINANCE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 208, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UJJIVAN SMALL FINANCE BANK" },
                    { new Guid("5d909461-f189-4c73-9f53-9fa8c67a1640"), "UTTAR BANGA KHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 216, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTAR BANGA KHETRIYA GRAMIN BANK" },
                    { new Guid("5dfca64d-15d2-41d8-a18e-9cae3f6a9420"), "THE RATNAKAR BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 195, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE RATNAKAR BANK LTD" },
                    { new Guid("5e546a14-b6e7-4bf0-aa4d-6de4dfcb46f1"), "HSBC", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 75, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HSBC" },
                    { new Guid("5ec923c7-ca28-4d66-ad79-3eb0e2be9785"), "BHAGINI NIVEDITA SAHAKARI BANK LTD PUNE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BHAGINI NIVEDITA SAHAKARI BANK LTD PUNE" },
                    { new Guid("6667c3bf-caeb-4df4-94c4-7731840e0d58"), "HDFC BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 72, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HDFC BANK" },
                    { new Guid("66c93611-d25b-47ab-9dca-9cccc99c5b22"), "JAMMU AND KASHMIR BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 87, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JAMMU AND KASHMIR BANK LIMITED" },
                    { new Guid("67fca534-82c9-4711-8ad2-2d5435ec5f8a"), "THE NAINITAL BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 191, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE NAINITAL BANK LTD" },
                    { new Guid("687ab5ba-a7f7-4b02-88a2-427c3b9b5853"), "URBAN CO-OPERATIVE BANK LTD. BAREILLY", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 213, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "URBAN CO-OPERATIVE BANK LTD. BAREILLY" },
                    { new Guid("68cf47b6-05c0-447f-9ea1-d4d07feffa54"), "THE HINDUSTAN CO-OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 179, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE HINDUSTAN CO-OPERATIVE BANK" },
                    { new Guid("6976e70f-87f6-4267-9ed8-45c10cb73226"), "DHANLAKSHMI BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DHANLAKSHMI BANK" },
                    { new Guid("6ae1e141-64f9-4ccc-9836-9ef6cd8851ed"), "JANASEVA SAHAKARI BANK (BORIVLI) LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 90, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JANASEVA SAHAKARI BANK (BORIVLI) LTD" },
                    { new Guid("700cbe4b-dae5-4395-b34c-b553fa5ee0f9"), "STATE BANK OF INDIA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 157, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STATE BANK OF INDIA" },
                    { new Guid("7199840d-b48f-4bf7-9a49-a066d31099b7"), "THE VISAKHAPATNAM CO-OP BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 202, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE VISAKHAPATNAM CO-OP BANK LTD" },
                    { new Guid("728126d8-4ad8-409f-8139-dd4e3f72cbdc"), "PITHORAGARH JILA SAHKARI BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 129, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PITHORAGARH JILA SAHKARI BANK" },
                    { new Guid("769a7c61-7077-4a6c-a9b9-c1d8f9841a50"), "ALMORA URBAN CO-OPERATIVE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ALMORA URBAN CO-OPERATIVE BANK LTD." },
                    { new Guid("7808d875-549c-4921-96cd-8504d68d0545"), "THE SHAMRAO VITHAL CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 198, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE SHAMRAO VITHAL CO-OPERATIVE BANK LTD" },
                    { new Guid("7a5b936f-d429-42c8-b3a8-9e8bcd5e70fe"), "STERLING URBAN COOPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 161, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STERLING URBAN COOPERATIVE BANK LTD" },
                    { new Guid("7d30573a-0381-459f-bb8a-464673b042b3"), "SARVA HARAYANA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 147, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SARVA HARAYANA GRAMIN BANK" },
                    { new Guid("7d92d409-4312-4d78-ada2-71d8bb268d61"), "CSB BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 49, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CSB BANK" },
                    { new Guid("80101a88-d27c-4866-8f2c-22bad564dab9"), "THE DECCAN MERCHANTS CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 175, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE DECCAN MERCHANTS CO-OPERATIVE BANK LTD" },
                    { new Guid("81af9ae5-bea1-4b5d-97dc-0fdc53e257f0"), "GUJARAT STATE COOPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 69, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GUJARAT STATE COOPERATIVE BANK" },
                    { new Guid("8339f95e-ffbb-4027-a26b-1120d5f6294e"), "KERALA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 102, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KERALA GRAMIN BANK" },
                    { new Guid("8906f565-ecde-4e95-85fa-0bc1458887ad"), "CHHATTISGARH GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 42, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CHHATTISGARH GRAMIN BANK" },
                    { new Guid("89273570-31cc-439f-a41d-ea73c9bcd9f4"), "COASTAL LOCAL AREA BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "COASTAL LOCAL AREA BANK LTD" },
                    { new Guid("89a3b2d3-243c-4b5d-b601-fa5273885145"), "AIRTEL PAYMENTS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "AIRTEL PAYMENTS BANK" },
                    { new Guid("8a75c77f-6989-4ca9-8aa9-729f6908b65a"), "DEUTSCHE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 55, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DEUTSCHE BANK" },
                    { new Guid("8b2b6420-6456-443d-aeb5-833ab1ba8d78"), "JAMSHEDPUR URBAN CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 88, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JAMSHEDPUR URBAN CO-OPERATIVE BANK LTD" },
                    { new Guid("8b3fe5d9-98d2-456d-800a-99d26ee41fc1"), "THE BUNDI CENTRAL CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 173, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE BUNDI CENTRAL CO-OPERATIVE BANK LTD" },
                    { new Guid("8c39c267-02c5-4250-8129-1afd23ea6589"), "AU SMALL FINANCE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "AU SMALL FINANCE BANK" },
                    { new Guid("8c91a354-e332-4506-be4a-66c625283b06"), "NAGAR VIKAS SAHKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 112, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NAGAR VIKAS SAHKARI BANK LTD" },
                    { new Guid("8d38a42c-1f6a-4fa1-ac2d-12dfeda9c0c2"), "RBL BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 143, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "RBL BANK" },
                    { new Guid("9249654e-45f5-4595-8794-90b24f0c89d3"), "SYNDICATE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 165, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SYNDICATE BANK" },
                    { new Guid("98774dad-9769-416b-9be5-be6b3c48f3a7"), "TEHRI GARHWAL ZILA SAHKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 168, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TEHRI GARHWAL ZILA SAHKARI BANK LTD" },
                    { new Guid("999bcb61-5781-4946-9708-bd5f64f77f32"), "SAHKARI BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 144, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SAHKARI BANK" },
                    { new Guid("9a655a53-6255-4649-8ee2-90caa7650da5"), "THE TAMILNADU STATE APEX COOPERATIVE BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 199, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE TAMILNADU STATE APEX COOPERATIVE BANK LIMITED" },
                    { new Guid("9b10c320-7aa9-46d9-ab0f-37a728e0c0c8"), "KANGRA CENTRAL COOPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 94, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KANGRA CENTRAL COOPERATIVE BANK" },
                    { new Guid("9c95b08c-6728-427f-ae86-5c4c33bdcb64"), "CHAMPARAN KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CHAMPARAN KSHETRIYA GRAMIN BANK" },
                    { new Guid("9deb42c0-4834-41f4-b66e-c274a5f4c361"), "DCB BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 53, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DCB BANK" },
                    { new Guid("a1502c73-540c-4c42-a21b-b6b9c19cbcf2"), "TELANGANA GRAMEENA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 169, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TELANGANA GRAMEENA BANK" },
                    { new Guid("a180a5b2-0e38-499e-aa06-1a87974ef0fb"), "BARODA UP BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BARODA UP BANK" },
                    { new Guid("a1bce2ee-eb63-48ae-b587-11c8733a8604"), "CASH", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CASH" },
                    { new Guid("a1ea2c61-7df8-40cd-a96a-224929f9b930"), "BARODA EASTERN UP GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BARODA EASTERN UP GRAMIN BANK" },
                    { new Guid("a208be69-88fc-4776-85ae-1080312fd1db"), "YES BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 226, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "YES BANK" },
                    { new Guid("a2954730-4438-4c77-b6e2-8b8278ba04d1"), "THE KALYAN JANATA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 184, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE KALYAN JANATA SAHAKARI BANK LTD" },
                    { new Guid("a2f4be03-7db7-45ff-8cdc-4f7b0485918c"), "ICICI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 76, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ICICI BANK LTD" },
                    { new Guid("a32b4d47-de6e-48ba-b17f-c78bd7a12c3b"), "TAMIL NADU GRAMA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 166, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TAMIL NADU GRAMA BANK" },
                    { new Guid("a35a5698-6958-496b-8557-a0be39fb6264"), "BOMBAY MERCANTILE COOPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BOMBAY MERCANTILE COOPERATIVE BANK LTD" },
                    { new Guid("a41dcdf2-26fb-4b5c-8873-7fa237672202"), "PURVANCHAL GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 139, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PURVANCHAL GRAMIN BANK" },
                    { new Guid("a5a5f1d1-91a6-4853-a45e-7cd98a7e382a"), "EQUITAS SMALL FINANCE BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 60, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "EQUITAS SMALL FINANCE BANK LIMITED" },
                    { new Guid("a6239563-3e25-47f5-b40f-b7c339b8bc1b"), "THE HUBALI URBAN COOPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 180, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE HUBALI URBAN COOPERATIVE BANK" },
                    { new Guid("a64ea08c-32f1-48ff-81e4-486784bb86fb"), "SHINHAN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 152, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SHINHAN BANK" },
                    { new Guid("a70feff6-dcad-4509-b4a4-8da027ae6a43"), "TAMILNAD MERCANTILE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 167, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TAMILNAD MERCANTILE BANK LTD" },
                    { new Guid("a7549d42-7774-452a-ac5d-2e444eb674d0"), "DISTRICT CO OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 57, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DISTRICT CO OPERATIVE BANK LTD" },
                    { new Guid("a76cf399-d4f4-4f3e-913f-a5c510a57685"), "ANDHRA PRADESH GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ANDHRA PRADESH GRAMIN BANK" },
                    { new Guid("a84433da-f09f-4955-ad79-9150f59626ba"), "AWADH GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "AWADH GRAMIN BANK" },
                    { new Guid("a8f13e58-1083-44ce-b366-7dd4aa6cd37f"), "NAVANAGARA URBAN COOP BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 117, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NAVANAGARA URBAN COOP BANK LTD" },
                    { new Guid("a95d41f6-9727-4708-aab9-763fb5efcf2d"), "JHARKHAND RAJYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 92, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JHARKHAND RAJYA GRAMIN BANK" },
                    { new Guid("a9933762-7b96-484e-b653-40d90035a28b"), "JANAKALYAN SAHAKRI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 89, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JANAKALYAN SAHAKRI BANK LTD" },
                    { new Guid("ab1320da-abfa-42be-9b6c-c001ab5ee82f"), "KARNATAKA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 97, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KARNATAKA GRAMIN BANK" },
                    { new Guid("ab5ae5b3-de81-41eb-af6c-52fec2bbfb16"), "CORPORATION BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 47, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CORPORATION BANK" },
                    { new Guid("acf27871-27a0-4016-8f4a-8a46cfbefa52"), "PALLAVAN GRAMA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 124, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PALLAVAN GRAMA BANK" },
                    { new Guid("adf48968-eb4e-4f99-b0ae-f8aa915da4fc"), "ALLAHABAD BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ALLAHABAD BANK" },
                    { new Guid("aeb27e92-88a5-4ada-8c53-70d7e0973c7e"), "UNION BANK OF INDIA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 210, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UNION BANK OF INDIA" },
                    { new Guid("b0021989-a576-4672-a20e-e7188b4edf6f"), "THE NATIONAL BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 193, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE NATIONAL BANK" },
                    { new Guid("b2f1c747-f6b6-4708-bf08-6361c634417f"), "RAJDHANI NAGAR SAHKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 142, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "RAJDHANI NAGAR SAHKARI BANK LTD" },
                    { new Guid("b392c8c2-42f8-4719-9fe4-7ff6fde8023a"), "BHARAT CO-OPERATIVE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BHARAT CO-OPERATIVE BANK LTD." },
                    { new Guid("b3f9f3a2-2b0c-4165-a4e3-8c454f4d498f"), "THE NASIK MERCHANTS CO-OP BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 192, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE NASIK MERCHANTS CO-OP BANK LTD" },
                    { new Guid("b464e5a5-9e1a-46db-9af1-dd474a819f76"), "THE MUMBAI DISTRICT CENTRAL COOPERATIVE BANK LIMIT", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 190, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE MUMBAI DISTRICT CENTRAL COOPERATIVE BANK LIMIT" },
                    { new Guid("b537362e-fd65-45c0-aa37-821f0b722875"), "DMK JAOLI BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DMK JAOLI BANK" },
                    { new Guid("b744db4a-6528-401e-826d-78c3b9713569"), "SUCO BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 162, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SUCO BANK" },
                    { new Guid("b845b89c-7fc5-48ff-b37a-e0da6fe49c6c"), "BHARAT BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 34, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BHARAT BANK" },
                    { new Guid("b94c2851-07b3-4f52-bacd-31a4026667fe"), "STATE BANK OF BIKANER &amp; JAIPUR", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 155, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STATE BANK OF BIKANER &amp; JAIPUR" },
                    { new Guid("bad3c242-a880-4685-b0bc-6f9f01fb1fe5"), "ETAWAH DISTRICT CO-OPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 62, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ETAWAH DISTRICT CO-OPERATIVE BANK LTD" },
                    { new Guid("bc2b58b5-1a07-4a88-8c01-f27bf8f5af2a"), "DBS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DBS BANK" },
                    { new Guid("bcd54457-0447-4a2a-800b-9c0281055670"), "FINO PAYMENTS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 65, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "FINO PAYMENTS BANK" },
                    { new Guid("bd1a6d12-48e4-4512-b198-f7db484c7517"), "BARODA RAJSTHAN KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 27, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BARODA RAJSTHAN KSHETRIYA GRAMIN BANK" },
                    { new Guid("bdf0f3de-28c9-4d89-9c81-7c653a918993"), "IDFC FIRST BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 79, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "IDFC FIRST BANK" },
                    { new Guid("be0ab054-adcf-412c-8846-e72213c2552d"), "SHAHJAHANPUR KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 150, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SHAHJAHANPUR KSHETRIYA GRAMIN BANK" },
                    { new Guid("be47744a-9dee-4e48-8a16-3e43d43076d7"), "NEW DELHI - ORIENTAL BANK OF COMMERCE -", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 118, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NEW DELHI - ORIENTAL BANK OF COMMERCE -" },
                    { new Guid("bfcbbbad-d85f-4146-8d0e-8e10f540a1b9"), "ANDHRA PRAGATHI GRAMEENA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ANDHRA PRAGATHI GRAMEENA BANK" },
                    { new Guid("c085de7e-4ad9-4e4f-8e58-092094daf631"), "UTKARSH SMALL FINANCE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 215, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTKARSH SMALL FINANCE BANK" },
                    { new Guid("c2c28f8c-6d90-4707-a383-d3915c910962"), "SARYU GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 149, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SARYU GRAMIN BANK" },
                    { new Guid("c35c7e86-8060-4b24-ba75-4270489e1d60"), "ODISHA GRAMYA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 122, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ODISHA GRAMYA BANK" },
                    { new Guid("c48f72a8-63f8-479b-af11-3c3e0680e299"), "LONAVALA SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 107, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "LONAVALA SAHAKARI BANK LTD" },
                    { new Guid("c6a0a30f-bacf-4f42-8e70-bfb6cb2488b8"), "THE KURMANCHAL NAGR SAHKARI BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 188, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE KURMANCHAL NAGR SAHKARI BANK LTD." },
                    { new Guid("ca90e938-9f03-423b-a68a-8e951d2e9f3c"), "THE THANE DISTRICT CENTRAL CO. OP. BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 201, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE THANE DISTRICT CENTRAL CO. OP. BANK LTD" },
                    { new Guid("cc280009-0b08-4b82-833d-d7748ea80c8b"), "GULSHAN MERCANTILE URBAN CO OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 70, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GULSHAN MERCANTILE URBAN CO OPERATIVE BANK" },
                    { new Guid("ccad733b-6e9e-4bd0-8ac4-d90b6395a5ef"), "ASHOK SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ASHOK SAHAKARI BANK LTD" },
                    { new Guid("ccccfdef-1fa9-4de0-9e7b-bf2b22dca92e"), "CITY UNION BANK LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 45, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CITY UNION BANK LIMITED" },
                    { new Guid("cdd50902-9585-4e33-98cd-972756a623f2"), "HIMACHAL PRADESH STATE COOPERATIVE BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 74, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HIMACHAL PRADESH STATE COOPERATIVE BANK LTD" },
                    { new Guid("cfdcb715-b85e-4824-b4b4-b8f5af424853"), "ARYAVART BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ARYAVART BANK" },
                    { new Guid("d03474f8-db96-4ecb-a169-37aa8e1a7892"), "PAYTM BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 128, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PAYTM BANK" },
                    { new Guid("d289797d-d204-47b3-8b62-c53097537c57"), "PARSIK SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 125, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PARSIK SAHAKARI BANK LTD" },
                    { new Guid("d29e8fb6-32fd-4d77-878e-4737d164dfe5"), "THE DELHI STATE COOPERATIVE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 176, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE DELHI STATE COOPERATIVE BANK LTD." },
                    { new Guid("d2b58ba4-26d7-4a81-8c25-286ac853c2df"), "INDIAN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 81, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "INDIAN BANK" },
                    { new Guid("d3af658a-fc77-4c80-b262-1d039eb1dec2"), "IDFC BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 78, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "IDFC BANK" },
                    { new Guid("d63edf62-a28c-423b-8c96-5e5dc850c37c"), "NARMADA JHABUA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 115, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NARMADA JHABUA GRAMIN BANK" },
                    { new Guid("d7544d0c-e369-46bc-bd4a-1d5431f1bd07"), "PUNJAB AND SINDH BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 136, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PUNJAB AND SINDH BANK" },
                    { new Guid("d851b272-f5fc-4658-8105-3946332fcf40"), "INDIA POST PAYMENTS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 80, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "INDIA POST PAYMENTS BANK" },
                    { new Guid("d8983048-21d6-495a-bf02-06e88290750a"), "VIJAYA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 225, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "VIJAYA BANK" },
                    { new Guid("d96d32a1-b858-42f8-82dd-9f17f4637712"), "ARYAVART KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ARYAVART KSHETRIYA GRAMIN BANK" },
                    { new Guid("d97e10f6-7d1d-47c0-af5f-049bd608cf64"), "PATLIPUTRA CENTRAL CO-OPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 126, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PATLIPUTRA CENTRAL CO-OPERATIVE BANK" },
                    { new Guid("d9aaf2dc-c8eb-4f91-9c9d-5a27a90e4bf6"), "HARYANA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 71, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HARYANA GRAMIN BANK" },
                    { new Guid("da20892f-6629-4bc2-967c-10569ad5523b"), "KAVERI GRAMEENA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 101, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KAVERI GRAMEENA BANK" },
                    { new Guid("dcff5c6e-704b-49c2-92c9-22bfa27de152"), "RAEBARELI KSHETRIYA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 140, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "RAEBARELI KSHETRIYA GRAMIN BANK" },
                    { new Guid("ddd90498-2d2d-4a1f-ba16-d29ad0a4fe3e"), "ANDHRA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ANDHRA BANK" },
                    { new Guid("de597b4f-adcd-4dcb-99d5-3094ea036561"), "TJSB SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 204, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TJSB SAHAKARI BANK LTD" },
                    { new Guid("de7bd02c-219a-45e2-b81e-817b47b62656"), "UNITED BANK OF INDIA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 211, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UNITED BANK OF INDIA" },
                    { new Guid("dea048dd-d06c-4343-af2f-38c399a8494d"), "BASTI GRAMEEN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BASTI GRAMEEN BANK" },
                    { new Guid("dee4a6db-e808-4cfa-9f75-2b310937218e"), "BARODA UTTAR PRADESH GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BARODA UTTAR PRADESH GRAMIN BANK" },
                    { new Guid("e05c3403-518c-4356-8a48-16885fdd998e"), "VASAI VIKAS SAHAKARI BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 223, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "VASAI VIKAS SAHAKARI BANK LTD" },
                    { new Guid("e401236f-4423-4349-8407-afb198778b89"), "ZILA SAHKARI BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 227, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ZILA SAHKARI BANK" },
                    { new Guid("e417e32c-fbf9-446e-ae31-7932d2834c5f"), "MADHYA BIHAR GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 109, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "MADHYA BIHAR GRAMIN BANK" },
                    { new Guid("e4336178-8291-4edd-8206-dbff849a2b96"), "THE LAKSHMI VILAS BANK LTD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 189, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE LAKSHMI VILAS BANK LTD" },
                    { new Guid("e44140e2-66ee-4160-95c4-f8b7f0bda992"), "BANK OF MAHARASHTRA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BANK OF MAHARASHTRA" },
                    { new Guid("e4f4417b-6c02-4329-995a-b0c1ac90960c"), "PAYMENTS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 127, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PAYMENTS BANK" },
                    { new Guid("e53b9ca7-f1d0-40eb-af88-a2fe9e692aea"), "LAKSHMI VILAS BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 106, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "LAKSHMI VILAS BANK" },
                    { new Guid("e8c96811-42a8-46f1-a6c4-25460011e17d"), "UTTAR PRADESH COOPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 218, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTAR PRADESH COOPERATIVE BANK" },
                    { new Guid("eb496b6e-81f0-417f-8885-94acea5005f6"), "GRAMIN BANK OF ARYAVART", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 68, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GRAMIN BANK OF ARYAVART" },
                    { new Guid("ebba3866-aa39-4495-bbbe-f9b89e3ff47f"), "PUNE DISTRICT CENTRAL CO-OP BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 135, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PUNE DISTRICT CENTRAL CO-OP BANK" },
                    { new Guid("f38b35bf-5ce6-4903-ac3e-c9af77381c95"), "THE JALGAON PEOPLES CO-OPERATIVE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 182, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "THE JALGAON PEOPLES CO-OPERATIVE BANK LTD." },
                    { new Guid("f3be7c43-fab1-477d-adae-899a0399a767"), "KASHI GOMTI SAMYUT GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KASHI GOMTI SAMYUT GRAMIN BANK" },
                    { new Guid("f55889f8-a69d-4228-b571-cc0d00a9c62a"), "STATE BANK OF MYSORE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 158, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "STATE BANK OF MYSORE" },
                    { new Guid("f90fcece-d8cb-48d4-9f5d-a8ca86c87127"), "MAHARASHTRA GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 110, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "MAHARASHTRA GRAMIN BANK" },
                    { new Guid("f913648a-4020-4da7-b162-a20f41bffeab"), "CHAITANYA GODAVARI GRAMEENA BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 40, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CHAITANYA GODAVARI GRAMEENA BANK" },
                    { new Guid("fa9a6e7c-2fcc-425b-95d6-7bfb77509b69"), "PUNJAB GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 137, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PUNJAB GRAMIN BANK" },
                    { new Guid("facef942-c5af-4932-a5c9-5400ddd2ced7"), "PRATHAMA UP GRAMIN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 131, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PRATHAMA UP GRAMIN BANK" },
                    { new Guid("faf8c4cb-a7bf-47eb-8f7e-6e2ff79cc64b"), "NATIONAL SECURITIES DEPOSITORY LIMITED", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 116, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NATIONAL SECURITIES DEPOSITORY LIMITED" },
                    { new Guid("fb1931d2-b3d0-4fac-b2fb-0b33aabbb8cb"), "JHARKHAND STATE COOPERATIVE BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 93, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JHARKHAND STATE COOPERATIVE BANK" },
                    { new Guid("fb913603-a66e-4541-bda2-4e4ad69b0420"), "SOUTH INDIAN BANK", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 153, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "SOUTH INDIAN BANK" },
                    { new Guid("fc6680fa-99c9-4646-8dd2-12887d7661e2"), "IDBI BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 77, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "IDBI BANK LTD." },
                    { new Guid("fe74423b-2e4e-4caf-bbcf-d6224414f433"), "UJJIVAN SMALL FINANCE BANK LTD.", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 209, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UJJIVAN SMALL FINANCE BANK LTD." }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000001"), "ANDHRA PRADESH", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ANDHRA PRADESH" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000002"), "ASSAM", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ASSAM" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000003"), "BIHAR", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "BIHAR" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000004"), "CHHATTISHGARH", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CHHATTISHGARH" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000005"), "CORPORATE OFFICE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "CORPORATE OFFICE" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000006"), "DELHI", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "DELHI" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000007"), "GOA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GOA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000008"), "GUJARAT", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "GUJARAT" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000009"), "HARYANA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HARYANA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000010"), "HEAD OFFICE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HEAD OFFICE" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000011"), "HIMACHAL PRADESH", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "HIMACHAL PRADESH" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000012"), "JAMMU & KASHMIR", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JAMMU & KASHMIR" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000013"), "JHARKHAND", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "JHARKHAND" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000014"), "KARNATAKA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KARNATAKA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000015"), "KERALA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "KERALA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000016"), "MADHYA PRADESH", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "MADHYA PRADESH" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000017"), "MAHARASHTRA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "MAHARASHTRA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000018"), "NONE", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NONE" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000019"), "NORTH EAST STATES", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "NORTH EAST STATES" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000020"), "ODISHA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "ODISHA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000021"), "PUNJAB", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PUNJAB" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000022"), "RAJASTHAN", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "RAJASTHAN" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000023"), "TAMIL NADU", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TAMIL NADU" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000024"), "TELANGANA", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "TELANGANA" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000025"), "UTTAR PRADESH", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTAR PRADESH" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000026"), "UTTRAKHAND", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "UTTRAKHAND" },
                    { new Guid("c1a1d1e1-f1a1-4711-8899-000000000027"), "WEST BENGAL", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 27, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "WEST BENGAL" }
                });

            migrationBuilder.InsertData(
                table: "CasteCategories",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("001a635e-d1ab-41c4-84aa-50c8b2ab5b69"), "SC", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Scheduled Caste" },
                    { new Guid("88deaa1c-c775-4f23-a5bc-99d2ded0a482"), "Gen", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "General" },
                    { new Guid("c41dde3e-d44b-44e0-856c-7b5cb1bf2fc3"), "OBC", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Other Backward Classes" },
                    { new Guid("f513d877-2d3d-4499-96ef-45e4b21cb6f1"), "ST", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Scheduled Tribe" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("25082ec5-82bf-4d5c-86f6-42f50aff16a6"), "Staff", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Staff" },
                    { new Guid("3e91df26-a6db-47b4-91b8-4dd08f3529bb"), "Facility", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facility" },
                    { new Guid("e5663953-e560-4582-afbf-95d99777c299"), "Guard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guard" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyName", "CompanyPan", "Country", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "Email", "IsActive", "IsDeleted", "LegalName", "ModifiedByUserId", "ModifiedByUserName", "Phone", "RegistrationNumber", "State", "Website", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("489d4544-5461-4132-aa29-688758627c98"), "address line 1", "address line 2", "Lucknow", "My First Company", "ABCDE1234F", "India", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test@test.com", true, false, "My First Company Pvt Ltd", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, "1234567890", "1234567890", "Uttar Pradesh", "https://www.test.com", "123456" },
                    { new Guid("74c8b851-922f-45b9-9c28-0c53c06120aa"), "address line 1", "address line 2", "Lucknow", "My Second Company", "ABCDE1234F", "India", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test@test.com", true, false, "My Second Company Pvt Ltd", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, "1234567890", "1234567890", "Uttar Pradesh", "https://www.test.com", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DialCode", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("7252f718-78be-4423-8e11-eab6700490ce"), "IN", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+91", 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "India" },
                    { new Guid("ea5e777c-6290-4232-b97f-09ac7902b6ce"), "NP", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+977", 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Nepal" }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("00282c75-8ee5-40c0-b726-187199d0450f"), "Cleaning Staff", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 95, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cleaning Staff" },
                    { new Guid("0080bdd8-fa6e-4c75-8fa1-b080ce69031f"), "Assistant-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 46, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant-Hr" },
                    { new Guid("01a41ea6-07b4-4038-a39d-c42405dcafe8"), "Admin Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Admin Officer" },
                    { new Guid("021767c2-05f6-4e3b-933a-b6aff22428e8"), "Mis-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 387, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mis-Scm" },
                    { new Guid("02507810-a511-44c3-b7d1-cd1ab1f5776d"), "Center Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 84, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Center Manager" },
                    { new Guid("02c8ab0b-8d09-4af9-aa6d-61a767cdb34f"), "Security Staff", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 484, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Staff" },
                    { new Guid("02ebe68d-7b80-43d7-90fd-8deac8ffa6b6"), "Worker-Ncb", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 657, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker-Ncb" },
                    { new Guid("032e4b9f-3eb1-437a-af8c-a796e430f1eb"), "Planning Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 446, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Planning Assistant" },
                    { new Guid("03b005b5-11d2-47d2-b512-977c0d8fddbf"), "Housekeeping-Station", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 305, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping-Station" },
                    { new Guid("03feface-c2fc-4938-a5de-b3d66983d501"), "Driver(Cdm)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 164, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Driver(Cdm)" },
                    { new Guid("05376138-2545-45ea-a35c-06ae354c97cc"), "Fata Thumby Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 207, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fata Thumby Helipad" },
                    { new Guid("056ac331-1f6c-4700-8e8e-c9cf35153756"), "Audit Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 54, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Audit Officer" },
                    { new Guid("05ab1265-2dc4-4927-b47a-8d4b15e110f3"), "Junior Assistant  Typist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 320, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Junior Assistant  Typist" },
                    { new Guid("05eec5f6-36ad-473d-82dd-217b053f5148"), "Plumber Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 450, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Plumber Helper" },
                    { new Guid("05f14480-c98f-417d-9f4c-8610620fe10e"), "Operator - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 425, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Operator - Sw" },
                    { new Guid("06066381-598c-4b8d-8596-75de3b868073"), "Office Associate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 411, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Associate" },
                    { new Guid("0607c05a-22a1-4720-ac9b-7d5f3af19d5b"), "Gun Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 255, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gun Man" },
                    { new Guid("062e54f5-6385-4135-96c3-db1650829612"), "Kitchen Stewarding Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 325, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Kitchen Stewarding Supervisor" },
                    { new Guid("0638de24-142e-4f01-a109-436a5f2184f5"), "Technology Support Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 614, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Technology Support Engineer" },
                    { new Guid("065aac5a-36ea-4a4c-bee0-a941c96b11b2"), "Gateman", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 234, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gateman" },
                    { new Guid("0695ba0d-af22-4fbb-9568-4f97fbc194e0"), "Technical", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 610, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Technical" },
                    { new Guid("069bdfac-c3ea-4db5-9dfc-77ec3a078804"), "Nayab Tehsildar 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 398, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Nayab Tehsildar 1" },
                    { new Guid("07103c68-9646-4ca0-b627-bd945db24707"), "(Epabx) C.Ope", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "(Epabx) C.Ope" },
                    { new Guid("079bf5f1-acf3-4518-854f-ed72e2cac826"), "Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 423, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Operator" },
                    { new Guid("07b8513f-f3cb-482e-810d-9f888c207daf"), "Office Boy Semi-Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 416, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Boy Semi-Skilled" },
                    { new Guid("08901fed-fa35-4f88-bfcc-e5b2c64e61ee"), "Cook Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 122, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cook Helper" },
                    { new Guid("09e03444-e10c-4c19-a0c6-7eeccf0e86f1"), "Gynecologist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 261, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gynecologist" },
                    { new Guid("0a62440d-1ffa-47d3-9168-3f6928ee5150"), "Site Engineer Iii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 537, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Engineer Iii" },
                    { new Guid("0af576d0-4324-4995-b64d-636e3dbafa6a"), "Marketing Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 367, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Marketing Executive" },
                    { new Guid("0b1bb289-1626-4a99-8a40-461a123abf29"), "Hostel Boy Clerk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 285, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hostel Boy Clerk" },
                    { new Guid("0bf82bfd-1e26-4700-9c3e-37ec3bbc78e7"), "Estate Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 178, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Estate Supervisor" },
                    { new Guid("0c18314e-1426-486e-b2e8-37972bee4456"), "Media Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 379, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Media Executive" },
                    { new Guid("0c78f7c1-1278-406d-a64d-6e8ec375e667"), "Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 613, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Technician" },
                    { new Guid("0c846c20-d64a-44ff-8e7f-0a14cf48e684"), "Assistant Manager-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 36, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Hr" },
                    { new Guid("0d5b4d23-f60c-4196-8f56-43111bad9db1"), "Receptionist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 467, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Receptionist" },
                    { new Guid("0da683d2-30e8-4365-979a-2d3d9eb44f57"), "Cook-Delhi", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 123, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cook-Delhi" },
                    { new Guid("0dc3f396-e00d-4aa9-bf47-426e69c60310"), "Worker-Noq", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 658, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker-Noq" },
                    { new Guid("0dd3506a-138a-4002-b0dd-9177d703e0b0"), "Female Warden", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 209, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Female Warden" },
                    { new Guid("0dedf7d7-6117-4d03-b6dd-38b7387f27ff"), "Md Paediatrics", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 374, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Md Paediatrics" },
                    { new Guid("0e208014-ee42-4503-8d35-9699445709d8"), "Record Keeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 468, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Record Keeper" },
                    { new Guid("0e45d7ba-14c2-4184-836a-efbfd6d9a854"), "Care Taker (Esm)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 78, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Care Taker (Esm)" },
                    { new Guid("0e8834e1-17ee-4135-a28b-034da355d79f"), "Sport'S Boy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 551, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sport'S Boy" },
                    { new Guid("0e9b6202-47f4-404f-b2f8-712e95a7b148"), "Executive-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 188, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive-Hr" },
                    { new Guid("0ec7a076-926f-46cd-a487-6523045dd3a6"), "Night Male", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 403, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Night Male" },
                    { new Guid("0ef5dbf7-42ad-4ab1-bbab-4c117ae63c5e"), "Sweeper - Buffing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 598, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sweeper - Buffing" },
                    { new Guid("0f035e05-557b-45a5-997c-2b2097084f91"), "Office Boy - Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 415, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Boy - Usw" },
                    { new Guid("0f0b41d1-f4a6-45c4-b27c-bff41737fe1b"), "Security Guard Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 479, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard Female" },
                    { new Guid("1000c537-4049-4c5f-82e3-3c15a9779070"), "Site Engineer Iv", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 538, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Engineer Iv" },
                    { new Guid("10c87c9c-d28a-4075-8dd1-35a10b9160fb"), "Operator Garbage Collection - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 426, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Operator Garbage Collection - Sw" },
                    { new Guid("1138fe6e-1dd3-4fcf-856b-c98efaa17d70"), "Senior Carpenter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 499, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Carpenter" },
                    { new Guid("11aa07e1-1ee5-4cca-a8a9-2c1de99dc7e1"), "Supervisor - Ehk (Fix)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 577, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Ehk (Fix)" },
                    { new Guid("11b18c70-bf4f-4b11-9724-8a1f11008369"), "Manager Learning Centre", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 353, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager Learning Centre" },
                    { new Guid("1201deae-f4ea-415a-a32e-7f20e2189b79"), "Purchase Section", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 464, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Purchase Section" },
                    { new Guid("13237ec5-1fd9-4065-be37-194a73b8da68"), "Revenue Inspector", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 470, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Revenue Inspector" },
                    { new Guid("13627946-8309-4275-8e74-0fe53fb9715a"), "Pharmacist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 441, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pharmacist" },
                    { new Guid("1460c9b3-0333-4299-8d29-c9086860d307"), "Mis - Repair  Maintenance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 385, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mis - Repair  Maintenance" },
                    { new Guid("147805a3-261f-4f79-8aa9-dcf9f96b4022"), "Lady Care Taker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 331, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lady Care Taker" },
                    { new Guid("15108b03-1752-48be-97f4-a6a32f3bf726"), "Horticulture", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 281, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Horticulture" },
                    { new Guid("15cfe386-bbc0-4933-b798-48c753b5608c"), "Mis  It Trainer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 384, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mis  It Trainer" },
                    { new Guid("162eb180-7d62-4376-aae0-067a271b3ddc"), "Ticket Issuer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 619, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ticket Issuer" },
                    { new Guid("1658f377-eb49-4ca6-b436-fbf19795650e"), "Security - Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 475, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security - Supervisor" },
                    { new Guid("16b82c22-8b00-405b-8246-227de7ddc3ab"), "Supervisor - Watering - F", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 596, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor-Watering - F" },
                    { new Guid("16c9c904-db5c-408d-af82-2dd4f5b4e4e5"), "Senior Executive Accounts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 504, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive Accounts" },
                    { new Guid("16ca24d7-7038-44b4-81d8-59e0e4b394f9"), "Aaya", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Aaya" },
                    { new Guid("16e78f0e-0fef-42f2-a800-b7f0910a2b23"), "Trainee Care Taker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 620, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee Care Taker" },
                    { new Guid("17c7a4f6-5ae1-4041-9dc4-11e71020e43b"), "Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 159, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Driver" },
                    { new Guid("17df994f-386a-4b1e-a7e4-73e229ae2bc5"), "Machinist - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 348, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Machinist - Sw" },
                    { new Guid("17e270c1-74b2-4ea3-baac-a4600f0be64c"), "Assistant Engineer (Electrical)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Engineer (Electrical)" },
                    { new Guid("1835a71f-765f-4e94-b7db-8902ae1e2de6"), "Guptkashi Helipad 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 258, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guptkashi Helipad 1" },
                    { new Guid("18966fd7-7172-4ccc-9e6d-b69d3ceddfc1"), "Moblizer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 388, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Moblizer" },
                    { new Guid("1919a20b-ed36-48e0-9d83-114db8614b04"), "Assistant - Branch Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant - Branch Manager" },
                    { new Guid("19ad06ea-a801-42d7-b83c-a71cf7716092"), "Skilled Worker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 544, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Skilled Worker" },
                    { new Guid("19c63693-7faa-42df-8ead-3469cefe1687"), "Manager-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 357, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Finance" },
                    { new Guid("1ac174b3-8c29-434b-9cd4-1302ac6bb37d"), "Chief Technical Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 91, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Chief Technical Officer" },
                    { new Guid("1ad8d9ec-dcdd-4b88-8c21-fd58d3e8f0dc"), "Ground Staff - I", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 248, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ground Staff - I" },
                    { new Guid("1aff7203-2b2a-4844-b5e1-f3f0ef2c6229"), "Multi Tasking Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 396, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Multi Tasking Helper" },
                    { new Guid("1b086c9b-5c31-41ca-a03d-142ee1e2f37a"), "Lab Assistant (Monthly)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 328, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lab Assistant (Monthly)" },
                    { new Guid("1b85794f-d14f-43cf-8d47-2a5d9a239eea"), "Cloak Room", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 97, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cloak Room" },
                    { new Guid("1bbb7cec-9f57-46fc-99e6-9ee723ff3339"), "Office Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 417, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Executive" },
                    { new Guid("1bf91c75-ca8d-4e72-9201-fd5d33db3aa3"), "Conductor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 117, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Conductor" },
                    { new Guid("1c03aa32-27c9-4930-b2f1-2747e9452237"), "General Physician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 237, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "General Physician" },
                    { new Guid("1c7ada6e-9efb-46dd-a0db-f0f5900c7ab7"), "Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 349, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager" },
                    { new Guid("1d9edcff-d01a-48d5-a8fa-e826c0661ca1"), "Project Stop", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 461, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Stop" },
                    { new Guid("1e36c4d3-0173-4b80-b3fb-20f76af3ad68"), "Executive-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 192, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive-Scm" },
                    { new Guid("1e406a26-ec0f-4a14-81f8-45b5c9db8368"), "Senior Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 496, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Assistant" },
                    { new Guid("1f4f34de-7571-4d44-b04d-2993afcbc3f4"), "Electrician Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 170, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Electrician Helper" },
                    { new Guid("1f583895-e787-4c42-a972-137e3d8782e9"), "It Trainer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 316, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "It Trainer" },
                    { new Guid("1f97fed8-b555-40e4-8aa0-44ecf238c8b7"), "Field Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 212, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Field Executive" },
                    { new Guid("1fab77d0-ed5b-4ed5-a5cc-19c7de8a522c"), "Night Brc Male", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 401, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Night Brc Male" },
                    { new Guid("1fb6e960-3c31-46d0-afec-d0865b92fcd5"), "Senior Assistant 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 498, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Assistant 2" },
                    { new Guid("202081b8-9a71-4c54-ab8c-49af476554b2"), "Denter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 139, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Denter" },
                    { new Guid("20bec2ae-0608-48fb-b67a-d6211cc6d486"), "Linene Counting", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 345, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Linene Counting" },
                    { new Guid("20ec15c2-693a-49a4-ad63-5b51fd851cbe"), "Placement And Moblizer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 444, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Placement And Moblizer" },
                    { new Guid("2140c259-26a8-44b2-b165-ef41c54f9de8"), "Technical Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 611, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Technical Assistant" },
                    { new Guid("216cd112-61f3-4cbf-a369-5888a8ed91ed"), "Waiter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 641, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Waiter" },
                    { new Guid("218e86f4-8f1d-4f7f-b8eb-ea3a57398ef3"), "Eot Operator - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 175, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Eot Operator - Sw" },
                    { new Guid("21a3e203-8fb9-46a2-b52c-638bb15af74e"), "Commi-Ii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 103, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Commi-Ii" },
                    { new Guid("21b72e64-37ff-4eef-b96e-2049b216fc26"), "Special Educator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 549, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Special Educator" },
                    { new Guid("224e9441-8e21-4d4f-a92b-897ccf238631"), "Deputy Genral Manager-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 148, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Genral Manager-Scm" },
                    { new Guid("2264890f-a39e-4b35-a98a-0f169bdbf5e8"), "Facilities Management Associate (Ac)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 193, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Ac)" },
                    { new Guid("228d04b1-f55b-4ba6-8839-bd1e004ffb7f"), "Senior Executive-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 511, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive-Marketing" },
                    { new Guid("22f33c7a-aef7-4147-932e-0d7d007f9552"), "Senior Executive Mis", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 506, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive Mis" },
                    { new Guid("232f9587-461a-4fc7-86fa-a65fd17892d9"), "Programmer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 454, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Programmer" },
                    { new Guid("23e530cf-ae29-45cf-95a6-bcd529dbbd2b"), "Team Leader", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 609, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Team Leader" },
                    { new Guid("24c75c1f-8487-4c28-abfa-66f17a2ec4dd"), "Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 558, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ssw" },
                    { new Guid("24e48c6b-4bcd-4885-a6e8-ba6cd5504319"), "Beldar Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 57, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Beldar Helper" },
                    { new Guid("25aa6cd3-08d6-42e3-8dfb-57cd278263bd"), "Cook", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 121, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cook" },
                    { new Guid("262a3d41-bf25-4d82-a695-5afc6a9357ef"), "Training Assistant-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 632, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Marketing" },
                    { new Guid("267492f5-9f60-4ede-a65b-adfe6e708f06"), "Head Of Department-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 267, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department-Finance" },
                    { new Guid("27d11113-ae76-46cb-9db9-bbf515b3c42d"), "Sweeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 597, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sweeper" },
                    { new Guid("28659966-92bc-4bfc-8c7e-33840d99040a"), "Worker-Watering", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 659, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker-Watering" },
                    { new Guid("298cc47e-4186-4aa5-97ca-7b5af3c10618"), "Meson", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 382, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Meson" },
                    { new Guid("2a2624d6-1e80-4897-98ac-776615358d9a"), "Ground Staff - Ii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 249, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ground Staff - Ii" },
                    { new Guid("2a5273f5-1ef7-4f4e-a975-928fba221282"), "House Keeping -  Mcc", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 289, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping -  Mcc" },
                    { new Guid("2babaf2d-6fed-42fc-805c-928f4e4640b9"), "Mazdoor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 371, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mazdoor" },
                    { new Guid("2ccd8fa7-19aa-4b44-a016-b6abb26896a9"), "Sugar Engineering", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 565, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sugar Engineering" },
                    { new Guid("2dc72664-8844-4c41-be17-2b6b146d10e1"), "Night Brc Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 400, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Night Brc Female" },
                    { new Guid("2e9c8512-a9ba-4003-9a69-fa39243baee0"), "Zonal Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 665, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Zonal Head" },
                    { new Guid("2ebfb28a-f9af-46e2-b36a-39cd2281cc47"), "Legal Consultant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 339, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Legal Consultant" },
                    { new Guid("2f025c1e-bdd9-43f1-883f-14d4d64af4df"), "Stone Keeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 561, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Stone Keeper" },
                    { new Guid("2f2ef8d4-429d-4f6e-9fcc-4b0bc58df514"), "Dak Runner", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 128, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dak Runner" },
                    { new Guid("2f7c7d8f-e797-43f9-b7e5-22c39e001d91"), "Senior Assistant 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 497, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Assistant 1" },
                    { new Guid("30465327-623a-4d4e-9fdc-e46a9ec46576"), "Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 181, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive" },
                    { new Guid("308d9bef-1230-4c09-964b-cd7c49461991"), "Manager-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 360, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Marketing" },
                    { new Guid("308f512f-4029-423d-8f07-866ab76e873a"), "Life Guard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 341, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Life Guard" },
                    { new Guid("31186846-a47f-4e49-9429-71af6ec66b1d"), "Video Studio Production Asst. Manage", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 640, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Video Studio Production Asst. Manage" },
                    { new Guid("32cbe7fd-4f6e-400c-b41d-d774fb78fdbe"), "Supervisor - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 585, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Sw" },
                    { new Guid("32d07865-8d56-4070-8eba-d722a126fd93"), "Supervisior-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 570, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior-Hr" },
                    { new Guid("33452708-ceb2-49de-bae4-a0aea2d2e8a5"), "Care Taker Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 79, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Care Taker Supervisor" },
                    { new Guid("33b8d69a-c695-4ebc-a914-c52c8260ce88"), "Housekeeping-Intensive Coach", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 302, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping-Intensive Coach" },
                    { new Guid("33c58dc4-0551-43ff-8413-e78fe91dbdc7"), "Head Cashier", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 263, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Cashier" },
                    { new Guid("33d5be1e-255b-4cf6-a0ad-50c44559cb4e"), "Bss", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 67, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Bss" },
                    { new Guid("340b6cfa-4d12-4ac1-9fca-c4c9e6c96e23"), "Area Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Area Manager" },
                    { new Guid("34f816be-20f5-4610-9425-38088a590276"), "Technical Co-Ordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 612, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Technical Co-Ordinator" },
                    { new Guid("358464cb-f8f5-4f55-ac28-3f17baad8924"), "Guest House", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 253, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guest House" },
                    { new Guid("358f07bb-7db1-4131-b569-e3b2e1b87376"), "Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 543, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Skilled" },
                    { new Guid("35f85f16-e729-4afd-a2e9-141ff5427827"), "Center Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 83, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Center Head" },
                    { new Guid("36344a49-c529-429f-95ad-1e42e544b081"), "Office Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 409, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Assistant" },
                    { new Guid("369c15c1-88d7-4b3e-9a2c-44ed55830ee7"), "Helper - Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 277, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Helper - Ssw" },
                    { new Guid("36ad97fc-df5f-4356-9f84-735fead1b735"), "Hr Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 306, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hr Executive" },
                    { new Guid("37c89c65-b538-452c-95be-364fd1820bf7"), "State Bank Of Mysore", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 559, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "State Bank Of Mysore" },
                    { new Guid("38a7da7f-afe3-4fb8-aecd-f675534fdbb6"), "Drawing Section", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 158, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Drawing Section" },
                    { new Guid("391f7a87-712c-4d6b-b9da-7d1c50d13e6c"), "Ward Boy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 643, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ward Boy" },
                    { new Guid("39450158-b769-4b32-a2e5-4a4770161b4c"), "Masson", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 369, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Masson" },
                    { new Guid("396a1d9c-bd96-4963-919c-f313738175b2"), "Labour", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 329, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Labour" },
                    { new Guid("39f56b95-0333-458d-bc8f-8bf0855c5832"), "Md Medicine", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 373, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Md Medicine" },
                    { new Guid("3a15ab7e-8662-4473-832b-cdd67ea0be74"), "Semi Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 490, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Semi Skilled" },
                    { new Guid("3a527a1f-bb20-4d10-bd23-fe8e77579fc4"), "Sweeper - Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 599, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sweeper - Female" },
                    { new Guid("3a64729f-5816-4ac1-84ac-f84009f7a4ab"), "Supervisor - Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 589, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Head" },
                    { new Guid("3a787701-411f-41ea-a5a2-6fd280cc70d3"), "A C Coach Attendent", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "A C Coach Attendent" },
                    { new Guid("3aa60ff1-9818-4829-a8da-e686d394006b"), "Tele Caller", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 616, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Tele Caller" },
                    { new Guid("3ba39b93-ac93-4876-9035-f8cfb071102f"), "Sr. Service Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 556, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sr. Service Engineer" },
                    { new Guid("3bb3ca12-ab0f-4e25-ba21-9ac01a82d156"), "Store Incharge", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 562, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Store Incharge" },
                    { new Guid("3bd74892-7012-4e51-9151-7b21a9a160a9"), "Nayab Tehsildar", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 397, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Nayab Tehsildar" },
                    { new Guid("3c0acee8-fae7-4626-b30c-9e0b11f8d887"), "Security-Guard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 489, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security-Guard" },
                    { new Guid("3c7eaefa-403a-4f0d-bf0d-665f2e612599"), "Nurse", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 406, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Nurse" },
                    { new Guid("3c8e6ead-2679-4511-bf07-66bbdc959d9a"), "Creach", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 124, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Creach" },
                    { new Guid("3e486e83-425d-404b-b74c-01390c47db9f"), "Senior Executive-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 512, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive-Operation" },
                    { new Guid("3e4bafe3-d92c-45ef-83af-d0b53a357657"), "Worker- Trc", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 655, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker- Trc" },
                    { new Guid("3efef072-028f-4200-9dae-2745aab5ff52"), "Project Scientist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 460, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Scientist" },
                    { new Guid("3f3fa369-a941-469b-a2db-187f3bba265f"), "Dentist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 140, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dentist" },
                    { new Guid("3f5cf996-6a31-45f4-84f1-afc70058e086"), "Manager - Business Development", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 350, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager - Business Development" },
                    { new Guid("42991b50-c4ac-46ce-a6c1-1ff4996eafaf"), "Senior Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 502, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive" },
                    { new Guid("42bc39c7-f2cf-4893-9635-e6a752d5eaf6"), "Worker - Toilet  Cleaning", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 651, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker - Toilet  Cleaning" },
                    { new Guid("42d7fa20-575e-41bc-83d5-c89095319ed6"), "Field Collector", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 211, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Field Collector" },
                    { new Guid("43374c79-bb4c-499f-b7b7-9946c18413fd"), "Swimming Coach 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 604, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Swimming Coach 1" },
                    { new Guid("434f2359-7c54-477b-96d9-83e47a551096"), "Janitor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 317, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Janitor" },
                    { new Guid("43bfd474-8144-4a91-b14b-e2d31095da31"), "Training Assistant-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 630, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Hr" },
                    { new Guid("4451b622-2259-453d-bf13-2ae82368d067"), "Supervisor - Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 584, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Ssw" },
                    { new Guid("445a07c4-bfc1-4bd5-b209-f8a8c8d05626"), "Planning-Assistance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 447, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Planning-Assistance" },
                    { new Guid("44766931-efe2-49be-bb9d-d7340df49eb3"), "Sr. Executive-Taxation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 554, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sr. Executive-Taxation" },
                    { new Guid("44bfd832-f6d6-409a-bdf7-7e7b82f7547f"), "Training Assistant-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 634, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Scm" },
                    { new Guid("4566cf7e-399b-4200-86c9-27ea07d5e33e"), "Bio.Chem Division", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 59, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Bio.Chem Division" },
                    { new Guid("45c5452a-bee0-48c0-91dd-c38f2412b7c8"), "Md Physician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 375, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Md Physician" },
                    { new Guid("468a9c68-5f2e-412d-a8b4-612d59dbd26a"), "Chef", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 88, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Chef" },
                    { new Guid("469a802a-7c98-469b-b9bf-0bbaf736b5c1"), "Senior Technical Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 523, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Technical Assistant" },
                    { new Guid("46d7ab97-b67a-4407-be05-e9b74c513c43"), "Training Assistant-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 633, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Operation" },
                    { new Guid("47b10408-0bc4-45a0-af7c-85bf99bf6c03"), "Cashier", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 81, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cashier" },
                    { new Guid("47fff391-ac82-42df-949e-50cfc1e5c4d9"), "Pantry", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 431, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pantry" },
                    { new Guid("482cb2e2-c46b-4e8d-a0de-1ff5a7e471e5"), "Pantry Boy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 432, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pantry Boy" },
                    { new Guid("484ab269-9779-40a4-9639-48035a271344"), "Young Horticulture", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 664, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Young Horticulture" },
                    { new Guid("49258b07-c6e1-45c9-8e5d-023685e0d974"), "Plumber", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 449, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Plumber" },
                    { new Guid("49ecf167-7d29-4fb2-949c-3541d9bfa583"), "Worker-Watering Spl 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 661, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker-Watering Spl 2" },
                    { new Guid("4a135986-4733-483b-af08-a90472dbfeac"), "Field Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 210, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Field Assistant" },
                    { new Guid("4a2f6380-c2a7-4e1a-b010-d5deedb40cdf"), "Guards Without Arms", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 252, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guards Without Arms" },
                    { new Guid("4a642da3-47dd-4a72-a2f9-a087eefc2463"), "Electrician - O", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 168, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Electrician - O" },
                    { new Guid("4aa96618-b5f0-4289-b86d-6afea37d3f69"), "Supervisor - Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 578, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Female" },
                    { new Guid("4aed71d3-211c-4ed3-84a4-c74666504fe7"), "Senior Executive-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 510, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive-Hr Admin" },
                    { new Guid("4b1cd6e9-e2c3-4c3e-a1db-5948ad407c40"), "Pit Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 443, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pit Manager" },
                    { new Guid("4c418dca-0ebc-4707-8278-d229db96119b"), "Mate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 370, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mate" },
                    { new Guid("4ce2694c-4118-4a91-a884-1f4c0479bfd0"), "Land Surveyor I", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 334, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Land Surveyor I" },
                    { new Guid("4d009166-81ca-49a1-a6fd-d695826dfc8c"), "Executive-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 190, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive-Marketing" },
                    { new Guid("4d12379f-d43b-4269-81e7-ad2277cdbee3"), "Supervisor - Ehk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 576, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Ehk" },
                    { new Guid("4d6bf24a-b1af-4921-ae3b-b86a4d029aaa"), "Trainee Lady Care Taker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 622, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee Lady Care Taker" },
                    { new Guid("4d9a8312-1fd4-426f-b689-32d8e676898a"), "Gardner Highly Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 228, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gardner Highly Skilled" },
                    { new Guid("4dfa2ae4-6e95-44b3-bf59-77a0f3b62e5b"), "Data Entry Operator 3", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 134, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data Entry Operator 3" },
                    { new Guid("4ece7727-d27c-4d64-92e3-002edc5edbbe"), "Manager Accounts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 352, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager Accounts" },
                    { new Guid("4ef9e9cc-81a8-47c9-b4c2-f9d3fb0cae4a"), "Head Of Department-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 270, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department-Marketing" },
                    { new Guid("4f145499-14f8-4028-95a9-6b42d8142c05"), "Senior Executive Legal", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 505, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive Legal" },
                    { new Guid("4f454420-b0d9-4aa3-aa27-d40885a89471"), "Assistant Manager-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 38, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Marketing" },
                    { new Guid("4ff93359-87f5-4b5f-9db2-7692b95a2d5d"), "Facilities Management Associate (Technc)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 199, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Technc)" },
                    { new Guid("4ffb66c7-e7de-46e7-b1e7-6925628ace7e"), "Data Entry Operator 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 132, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data Entry Operator 1" },
                    { new Guid("51425ca3-d5aa-4904-be40-d4aa06e40ba6"), "Fitter - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 219, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fitter - Sw" },
                    { new Guid("5182bb8d-b511-4ca1-9df0-90c847831917"), "Photographer Cum Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 442, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Photographer Cum Technician" },
                    { new Guid("51f4fb63-16ad-4423-9eab-a2ad7ee1c9d2"), "Supervisor - Linen", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 591, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Linen" },
                    { new Guid("5255e375-d77e-4e59-984b-f8e961c23b0b"), "Gardner Supervisor - F", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 232, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gardner Supervisor -F" },
                    { new Guid("52b8bb11-491c-4d20-8cb1-afc92a4b5027"), "Data Analytst", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 130, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data Analytst" },
                    { new Guid("530680bd-11aa-4e96-8481-5bf6d9af4213"), "Senior Executive-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 509, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive-Hr" },
                    { new Guid("5307335e-e6e4-41ce-9468-cb6313332d31"), "Peon 15020", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 436, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Peon 15020" },
                    { new Guid("530b5ce8-748d-4706-8dea-75ca07ae7ab3"), "Driver - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 163, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Driver - Sw" },
                    { new Guid("53fdd43d-e670-4158-834a-07547309ac80"), "Skilled Worker - Ehk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 545, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Skilled Worker - Ehk" },
                    { new Guid("553f819b-b9b9-4baa-a7ac-f88b8dffc0cc"), "Senior Accountant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 492, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Accountant" },
                    { new Guid("5544a43b-02f3-4a53-aa19-eb6045fd39d1"), "Computer Programmer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 115, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Programmer" },
                    { new Guid("55710b17-8495-4bc2-9467-9eda113f1483"), "Supervisor - Hk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 579, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Hk" },
                    { new Guid("55932c59-b282-41fa-b005-3a54f9259a3e"), "Executive - It", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 182, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive - It" },
                    { new Guid("562fa6f6-2e0a-49dd-b010-a6fa2a6fc3d9"), "Canteen", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 75, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Canteen" },
                    { new Guid("56343cb9-6906-4296-bf15-97c23f93130b"), "Service Manager - Repair  Maintenance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 529, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Service Manager - Repair  Maintenance" },
                    { new Guid("56735855-80c8-4cde-b098-ebdcb1cecafa"), "Housekeeping Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping Manager" },
                    { new Guid("56a9daf6-c237-4147-9768-69ba3dba2894"), "Head Mali", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 265, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Mali" },
                    { new Guid("5783ba2f-7eec-491d-8914-20bd0cffbe9c"), "Asst. Manager  Taxation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 52, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Asst. Manager  Taxation" },
                    { new Guid("57e09189-64a7-4bfd-a0e5-170aed1bd80a"), "Deputy Genral Manager-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 147, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Genral Manager-Operation" },
                    { new Guid("57f10a27-9975-4409-88f3-5b4f73e86773"), "Manager-Billing  Collection", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 355, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Billing  Collection" },
                    { new Guid("58389843-f40e-434f-9133-c3d202bea73d"), "Chief Engineer Civil", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 90, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Chief Engineer Civil" },
                    { new Guid("5840dfd5-0768-4f10-b780-771b083bbcb3"), "Supervisor - Hsw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 580, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Hsw" },
                    { new Guid("58518299-14fa-407f-b26d-8663c298f298"), "Warden - Admin Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 645, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Warden - Admin Officer" },
                    { new Guid("5912f0b9-4378-400f-b075-cf9fba137eb1"), "Operation Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 421, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Operation Head" },
                    { new Guid("5970d42e-82cf-4b8d-8f59-a7518f8db682"), "Civil Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 93, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Civil Engineer" },
                    { new Guid("5a1c30fb-33dc-4a7e-8d22-dd097ce61ac8"), "Supervisior-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 573, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior-Scm" },
                    { new Guid("5a246c82-bfe2-4fec-9fd0-294f07ff80ab"), "Project Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 455, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Assistant" },
                    { new Guid("5be3e0ce-4f3b-4801-a35b-9efd123a2e90"), "Business Development Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 69, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Business Development Manager" },
                    { new Guid("5d2209a3-a5c8-4ac6-8481-4d08b29bbd78"), "House Keeping - Pfr - Spl", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 293, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping - Pfr - Spl" },
                    { new Guid("5d5595ae-9ed8-4e5c-a7c7-48190d83cd08"), "Lift Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 342, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lift Operator" },
                    { new Guid("5d7b7146-1d12-4844-b385-00f392ac0474"), "Deputy Genral Manager-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 146, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Genral Manager-Marketing" },
                    { new Guid("5d7e6c2f-420c-428a-ad02-d5faeae1377c"), "Swimming Coach (Daily)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 603, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Swimming Coach (Daily)" },
                    { new Guid("5d99441f-dac0-4e5d-92c1-f99bb339d710"), "Fireman", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 217, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fireman" },
                    { new Guid("5e007534-92e4-4459-8f62-4faf91714093"), "Assistant Manager- Technical", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 34, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager- Technical" },
                    { new Guid("5e89ed97-c9f0-43e1-bdbd-6139748ac3f4"), "Cluster Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 98, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cluster Engineer" },
                    { new Guid("5eb46350-4779-42de-88a0-0ba56f675c2a"), "House Keeping", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 288, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping" },
                    { new Guid("5ec5611f-2fcb-43dc-9c03-6b116ee7ddc8"), "Agriculture", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Agriculture" },
                    { new Guid("5ef38100-5d28-41f8-8cc1-2e82723a6487"), "Brush Cutter Operator - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 66, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Brush Cutter Operator - Sw" },
                    { new Guid("5facf70e-0d7d-4e5b-a95f-f5b3beb33529"), "Pest Control", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 440, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pest Control" },
                    { new Guid("5feeccf9-2cd9-4416-a47c-937281aeea51"), "Assitant Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 51, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assitant Manager" },
                    { new Guid("60e33a6e-b22d-4294-90d4-029d5ed87bde"), "Rag Picker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 466, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Rag Picker" },
                    { new Guid("6137c4a2-7134-4f89-80d5-35f29c44c0b8"), "Co-Ordinator Omcr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 101, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Co-Ordinator Omcr" },
                    { new Guid("62038592-4008-4077-a5d6-55ccc4f2bcf2"), "Site Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 533, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Engineer" },
                    { new Guid("62410546-ebc1-4c5a-8f59-95f4be30f715"), "Site Manager Ucada", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 541, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Manager Ucada" },
                    { new Guid("62d1edf7-42f2-4931-bf15-36e9a3aae695"), "Senior Co-Ordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 500, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Co-Ordinator" },
                    { new Guid("62f8c1d4-6d27-4c09-8f7b-72c064f1aa1f"), "Beldar", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 56, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Beldar" },
                    { new Guid("6447009f-dc1a-4866-a126-17128cd927ea"), "Business Development Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 70, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Business Development Officer" },
                    { new Guid("64bca7ae-66f4-4ab1-817e-48f82598dcfb"), "Grievance Redressal Co-Ordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 247, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Grievance Redressal Co-Ordinator" },
                    { new Guid("65f26ba6-c0a9-4035-b2e6-69f6cb21e375"), "Communications Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 105, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Communications Executive" },
                    { new Guid("65f6f176-eba1-4fe4-89d3-752b5c7b7d77"), "Assistant Lineman", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Lineman" },
                    { new Guid("6605234b-dc32-423d-a5d8-c58e7af4afaa"), "Assistant Manager - Business Development", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 32, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager - Business Development" },
                    { new Guid("67202858-55a2-4181-bdd2-28ffd3fec3bb"), "S  I", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 473, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "S  I" },
                    { new Guid("678aac2d-214d-4e98-86af-7f1914e18d2a"), "Director Office", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 153, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Director Office" },
                    { new Guid("67cadb87-e94d-48f9-aec4-63b0aeef81db"), "Deputy Genral Manager-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 145, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Genral Manager-Hr Admin" },
                    { new Guid("67e6e91d-e650-4d09-82b9-83a55a609f1b"), "Lady Guard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 332, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lady Guard" },
                    { new Guid("68055e84-c7e2-4e38-9c1e-22fc6d0fbd7e"), "Supervisor - NCB", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 592, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - NCB" },
                    { new Guid("688c6f82-f6fe-4986-b9a1-f7a7c9760ea0"), "Marketing  Consultant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 365, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Marketing  Consultant" },
                    { new Guid("68a31196-bd4a-4af5-b720-7fc7de5f5e0d"), "Manager-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 358, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Hr" },
                    { new Guid("6933b1d0-5d36-4bfb-a7b5-0b3f815a7f08"), "Farmer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 204, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Farmer" },
                    { new Guid("696fb5a0-096e-4fdc-a736-6b430f6ae0ef"), "Training Assistant-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 629, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Finance" },
                    { new Guid("69939cd9-f801-47d1-89bb-47e6c1f4ff6a"), "Commi-I", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 102, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Commi-I" },
                    { new Guid("6a4f18c0-6768-44f9-b36e-7d84951ccee2"), "Recruitment Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 469, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Recruitment Executive" },
                    { new Guid("6b8fb9ee-d089-4ecc-a0f2-4c1c8ac7be7e"), "Draft Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 157, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Draft Man" },
                    { new Guid("6c0d1e21-96b4-4262-b62c-0c9ef7fec181"), "Worker-Watering Spl 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 660, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker-Watering Spl 1" },
                    { new Guid("6c67a51a-fcbe-4b24-b0a3-862ffe5ea2c0"), "Supervisor - Mcc", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 581, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Mcc" },
                    { new Guid("6cb9fbd7-2284-44a3-90bd-8b874a400ef9"), "Pathology Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 434, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pathology Technician" },
                    { new Guid("6ccb616a-dced-4625-855b-0d3e0874744b"), "Sewer Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 530, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sewer Man" },
                    { new Guid("6d5708da-ecdc-4ca3-bc82-199ef7504db2"), "Trainee Office Associate 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 624, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee Office Associate 1" },
                    { new Guid("6d9d3338-7843-4d3c-911e-cf23282e7196"), "Data Entry Operator 4", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 135, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data Entry Operator 4" },
                    { new Guid("6dd5c744-6874-4323-aeec-401ca12b7fb5"), "Office Boy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 414, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Boy" },
                    { new Guid("6e050fbc-8b51-4ec6-8b49-45b57bb03fe7"), "Genral Manager-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 242, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Genral Manager-Operation" },
                    { new Guid("6e1dd29c-d9f2-4ed1-8364-afe4e4a00fc0"), "Project Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 459, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Manager" },
                    { new Guid("6e6a46dd-2b8f-4e13-912a-6db8722cc09b"), "Head Of Department-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 269, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department-Hr Admin" },
                    { new Guid("6eb4083e-e540-4e4b-b414-5a2d6e2ca139"), "Nayab Tehsildar 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 399, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Nayab Tehsildar 2" },
                    { new Guid("6ef301c3-ec09-41bd-ab68-641fe3329c90"), "Health Attendant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 274, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Health Attendant" },
                    { new Guid("6f661d13-fdf3-4f09-a751-00a3e864a20c"), "Soit", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 548, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Soit" },
                    { new Guid("70169008-6426-4aa2-8a6d-d0410353ccd8"), "Peon Cum Mate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 437, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Peon Cum Mate" },
                    { new Guid("7024db21-4bcb-43bb-88fd-e880421faf47"), "Driver (Lmv)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 162, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Driver (Lmv)" },
                    { new Guid("7068e535-58d5-489f-862b-b1ee53c67408"), "Roomboy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 472, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Roomboy" },
                    { new Guid("726a27f8-d17d-4222-91c5-60f100979c36"), "Operation Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 422, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Operation Manager" },
                    { new Guid("7275156a-02a6-45ee-a52f-098b8e854b6f"), "Worker - Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 650, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker - Ssw" },
                    { new Guid("734279b1-4ec0-45e7-a6c9-3737ece7fc2c"), "Executive - Legal", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 183, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive - Legal" },
                    { new Guid("73893fb2-8bfb-4706-a2ee-478911e72724"), "Assistant Manager-Mis", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Mis" },
                    { new Guid("740a5164-8827-485f-bdd1-46d2cecb914c"), "Computer Personnel", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 114, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Personnel" },
                    { new Guid("7489bcc9-84e4-4227-bedb-a44d06a2e941"), "Gardner", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 227, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gardner" },
                    { new Guid("749cb9d5-2a75-49b3-ad69-1b0e99928c6d"), "Car Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 76, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Car Driver" },
                    { new Guid("74b6ba4a-0ff9-4a94-864a-fd51909eebd2"), "Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 276, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Helper" },
                    { new Guid("75cf70a0-27ff-43b4-b889-e4c0890fbcb5"), "Security Guard Cash", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 477, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard Cash" },
                    { new Guid("768230d9-0987-4bd0-8559-0ee2e1cfb894"), "Supervisor - NOQ", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 593, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor -NOQ" },
                    { new Guid("771467bb-4f6d-4a70-ba05-c35c8850b1e2"), "Night Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 402, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Night Female" },
                    { new Guid("77a4b88c-6271-47cb-bd58-0c31add1b975"), "Computer Operator - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 107, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator - Sw" },
                    { new Guid("780a2d23-0f31-4f62-a4ae-4d41c4f0383c"), "Office Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 418, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Helper" },
                    { new Guid("78167f12-ee37-4491-99af-a33bedd1c7f3"), "Pump Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 463, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pump Operator" },
                    { new Guid("785f42be-4c0e-4a2b-81e8-c10676d40c93"), "Sr. Secretarial Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 555, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sr. Secretarial Assistant" },
                    { new Guid("78b787f1-5c9f-485d-ac21-d7a3b54d3096"), "T.Ope", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 606, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "T.Ope" },
                    { new Guid("7934cb51-7c9f-445c-ad80-0f826743bdf8"), "Assistant Manager Accounts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 33, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager Accounts" },
                    { new Guid("79548d71-407d-401e-ab4a-21bd36887110"), "Project Co-Ordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 456, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Co-Ordinator" },
                    { new Guid("7987f87b-1bbc-42ea-830b-ec460a8d7aa1"), "Supervisor - Trc", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 586, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Trc" },
                    { new Guid("7a3a875f-d331-4244-a67b-5b0465deea2b"), "Highly Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 280, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Highly Skilled" },
                    { new Guid("7a9de9d8-e715-4383-8ab6-c1bd57c7e64e"), "Day Brc Male", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 137, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Day Brc Male" },
                    { new Guid("7b3f829b-4aeb-4d84-90a6-fd9ddc8c7d6f"), "Class Room Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 94, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Class Room Technician" },
                    { new Guid("7b405d0d-7df4-4dc5-ac0b-7ef560f84719"), "MCC  Depot", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 372, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "MCC  Depot" },
                    { new Guid("7c4da41b-1e9b-4beb-8234-c12862a24c75"), "Gun-Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 256, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gun-Man" },
                    { new Guid("7ca88367-7739-47b9-aba7-8cf82b26adca"), "Unskilled - Prayag Raj", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 637, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Unskilled - Prayag Raj" },
                    { new Guid("7e1cc8d1-c826-4e9a-a7d8-c31e741cb167"), "Security Guard Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 482, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard Supervisor" },
                    { new Guid("7ea17dc7-a304-4caf-b380-307a686803f0"), "Worker-Apdj", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 656, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker-Apdj" },
                    { new Guid("7ec74376-5bbc-4bbe-b015-c93cb00977a3"), "Mts 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 395, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mts 1" },
                    { new Guid("7f44e7a5-a819-497d-be95-6202b974a1da"), "Supervisor - Repair  Maintenance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 583, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Repair  Maintenance" },
                    { new Guid("7fd453ac-3e48-4292-93af-c216f23ac1ae"), "Site Engineer Ii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 536, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Engineer Ii" },
                    { new Guid("809ef357-b46a-4ac5-b8b0-5126f646594b"), "Land Surveyor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 333, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Land Surveyor" },
                    { new Guid("80e4290d-29c8-462b-941d-4d9b8d078a07"), "Assistant General Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 29, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant General Manager" },
                    { new Guid("80f0afe1-5902-4468-b070-2222e801f384"), "Deputy General Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 142, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy General Manager" },
                    { new Guid("81f030d6-babf-4acd-981b-43a275fc82f8"), "Senior Executive-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 508, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive-Finance" },
                    { new Guid("8273ed4d-2b51-44f0-988b-133b07c8c7ea"), "Assistant Security Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 43, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Security Officer" },
                    { new Guid("82ca8875-2b29-4636-8302-5cf77eefafa7"), "Carpenter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 80, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Carpenter" },
                    { new Guid("8368fd8d-195c-4db5-a07f-38f38e7ee491"), "Senior Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 516, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Manager" },
                    { new Guid("83abce5c-c3b1-4f20-b94f-dc6d856e7261"), "Daftari", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 127, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Daftari" },
                    { new Guid("83cb7dcc-f8d9-4f73-9cb5-a0bee7135a16"), "Computer Teacher", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 116, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Teacher" },
                    { new Guid("83ebe436-acf9-478d-a5ea-92c7217d050b"), "Ex - Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 179, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ex - Man" },
                    { new Guid("849b2def-87ad-48e9-9c95-e162ca7ad199"), "Co-Ordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 99, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Co-Ordinator" },
                    { new Guid("84f02053-3c2d-417e-8d58-0fc1a009e217"), "Chemical Sprayer And Handler", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 89, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Chemical Sprayer And Handler" },
                    { new Guid("855e76a9-c896-42ed-8b8f-6e138f52d485"), "Deputy Genral Manager-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 143, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Genral Manager-Finance" },
                    { new Guid("8560754f-6975-4364-9ff2-0644504d6947"), "Hr Executive Payroll", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 308, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hr Executive Payroll" },
                    { new Guid("85aca07e-c6d9-4d8d-b64a-b16bbbae6735"), "Manager-Mis", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 361, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Mis" },
                    { new Guid("860a076c-dff7-4c09-967c-b40b87e8526d"), "Senior Accounts Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 495, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Accounts Officer" },
                    { new Guid("8738f0f2-2562-488e-824c-58bc1be8eec6"), "C.Ope", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 71, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "C.Ope" },
                    { new Guid("880010c8-d69c-406d-a1b9-03b580425bf0"), "Junior Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 322, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Junior Engineer" },
                    { new Guid("886255b4-ab4b-43aa-8070-4980625c1bd1"), "Assistant Engineer (Electronics)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 28, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Engineer (Electronics)" },
                    { new Guid("88a3b0cb-227a-4f3d-8c72-1af1ccfdd11d"), "Housekeeping-Depot", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 301, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping-Depot" },
                    { new Guid("88bde858-7f73-411e-b9fc-2dec54af7ecc"), "Moblizer Cum Placement Cordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 389, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Moblizer Cum Placement Cordinator" },
                    { new Guid("897788c3-a409-4e34-b2df-d987578f750d"), "District Project Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 156, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "District Project Manager" },
                    { new Guid("89e0e60f-5465-4cd7-a145-ba3c1524c05e"), "Epbax Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 176, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Epbax Operator" },
                    { new Guid("8a26e74a-202f-4c70-bd9d-033582648d7b"), "Trainee-Business Development", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 626, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee-Business Development" },
                    { new Guid("8a4b1202-f8f4-4ba1-bce5-b8a61522a216"), "Guptkashi Helipad 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 259, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guptkashi Helipad 2" },
                    { new Guid("8a4f11ca-69c3-4ff5-ba44-f978d1e5377a"), "Head Cook", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 264, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Cook" },
                    { new Guid("8b1cfc80-ff1d-4b90-b670-a59d6133115b"), "Site Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 542, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Supervisor" },
                    { new Guid("8b5c64ee-d48a-49ee-9920-c2e29761fc81"), "Junior Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 319, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Junior Assistant" },
                    { new Guid("8baf68c6-d8f1-4f04-a41f-8ef5328522ad"), "Pso", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 462, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pso" },
                    { new Guid("8bfd77bd-8014-4a12-a758-48d3f4d1c97a"), "Executive-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 191, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive-Operation" },
                    { new Guid("8c006bba-85bf-4951-81b4-24b259d3274f"), "Electrician-Mst", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 171, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Electrician-Mst" },
                    { new Guid("8c38493a-c91f-4221-9593-5db7641aebe0"), "Assistant Manager-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Finance" },
                    { new Guid("8c8d24b1-3658-4bc8-aec3-901446b9b12b"), "District Coordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 154, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "District Coordinator" },
                    { new Guid("8d6f9e59-8d3c-463b-8896-a4886231d79a"), "Trainee Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 625, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee Technician" },
                    { new Guid("8daedcdc-c070-489d-9632-f135d72ce36d"), "Worker - Usw (Fix)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 653, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker - Usw (Fix)" },
                    { new Guid("8e30a695-995e-4c6e-9e87-d454ff638107"), "Senior Executive - It", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 503, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive - It" },
                    { new Guid("8e518dfe-8ed8-440b-ac4d-f16b59240118"), "Clerk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 96, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Clerk" },
                    { new Guid("8f21902f-514e-400d-bcd3-964df3985175"), "Sershi Himalayan Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 524, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sershi Himalayan Helipad" },
                    { new Guid("8f6293eb-1115-4bca-91ac-17c1ff74ad27"), "Security Trainer Special", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 487, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Trainer Special" },
                    { new Guid("8f8a8e38-9454-4f12-b3fd-5106de0bebaf"), "Head Of Department-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 268, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department-Hr" },
                    { new Guid("9012d3ec-2db4-46fb-9f8e-3a23967f90ce"), "Supervisor - Station(Hk/Cts)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 595, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Station(Hk/Cts)" },
                    { new Guid("90140cfd-96be-407d-bc90-d2e14f576865"), "Bell Bay", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 58, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Bell Bay" },
                    { new Guid("90372629-435f-4ed8-a1de-594551a56041"), "Sanitation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 474, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sanitation" },
                    { new Guid("90824d19-b327-438d-b072-35758b35a02b"), "Education", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 166, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Education" },
                    { new Guid("90b418af-3348-4004-be84-aedcb43dcac2"), "Accountant Cum Cashier", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Accountant Cum Cashier" },
                    { new Guid("91b585ff-5613-4da3-a1bb-e5f18267e92b"), "Fireman B", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 218, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fireman B" },
                    { new Guid("91e6026f-13b7-4fde-afef-83e3e6fa3d28"), "Tailor Master", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 607, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Tailor Master" },
                    { new Guid("926d2982-2a48-4cfd-b661-fd5471123693"), "Assistant Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Driver" },
                    { new Guid("92702f6d-ea5a-44e6-9924-2273bda23d13"), "Md-Director", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 376, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Md-Director" },
                    { new Guid("92a40b7f-9145-4f34-9bb7-eac0ec3bcefc"), "Ceo/Coo-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 87, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ceo/Coo-Operation" },
                    { new Guid("933df998-2301-425e-8e4d-f769a791b00c"), "Moblizer Cum Quailty Member", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 390, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Moblizer Cum Quailty Member" },
                    { new Guid("9372ce6b-5bcd-4a98-ad15-f0081f459cce"), "Store Keeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 563, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Store Keeper" },
                    { new Guid("942ad24d-809b-4b4c-b760-ba675532b223"), "Call Centre Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 74, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Call Centre Operator" },
                    { new Guid("946391f4-a928-4863-8db0-b592f1e19b2a"), "Gardner Semi-Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 230, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gardner Semi-Skilled" },
                    { new Guid("9478b09e-c3fa-410d-a7d0-3a46fe7ffb29"), "Personal Security Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 438, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Personal Security Officer" },
                    { new Guid("9485d68a-2238-4de3-9ff9-22b81fad6c02"), "Night Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 404, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Night Supervisor" },
                    { new Guid("948808ec-df79-4a24-9110-19430d125777"), "Branch Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 63, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Branch Head" },
                    { new Guid("94ce85dc-f172-42f1-9a6c-3adb7fa9917c"), "Ac Tech", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ac Tech" },
                    { new Guid("94ce9908-1702-470e-aa38-01954a520edd"), "Project Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 457, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Head" },
                    { new Guid("9551d420-98cc-45a4-a29b-bc82da7f0a69"), "House Keeping - Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 290, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping - Female" },
                    { new Guid("95548eba-0879-4ebb-8aa2-fb06bad4772d"), "Office Housekeeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 419, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Housekeeper" },
                    { new Guid("9598ea1b-167a-47e4-9c81-2234d1bd5042"), "Kedarnath Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 324, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Kedarnath Helipad" },
                    { new Guid("959b49be-3a44-4d00-a309-489fa57e5427"), "Facilities Management Associate (Plmbng)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 197, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Plmbng)" },
                    { new Guid("95b3ca70-52db-4920-b139-4232f157e222"), "Medical Consultant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 381, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Medical Consultant" },
                    { new Guid("96421cb9-b2d8-4f8a-896e-59c776b005a7"), "Business Development Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 68, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Business Development Executive" },
                    { new Guid("9670182c-4801-45a4-9f86-cfaa7c0f4b40"), "Senior Executive-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 513, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive-Scm" },
                    { new Guid("9670da81-5f5b-42e5-b2c8-bed54efa78bd"), "Assistant Manager-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 37, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Hr Admin" },
                    { new Guid("96e0f31e-2b71-47d2-98fb-2ae143a268bc"), "Fire Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 216, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fire Technician" },
                    { new Guid("973c8652-d075-4b47-a678-05efda680f6e"), "Junior Manager- Technical", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 323, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Junior Manager- Technical" },
                    { new Guid("9756a565-2641-4e74-82e3-8215770a3c98"), "Admin Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Admin Executive" },
                    { new Guid("975bc8f7-addf-498b-b95c-8827c4d87e18"), "Security Guard Cum Sweeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 478, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard Cum Sweeper" },
                    { new Guid("976b9aee-eab7-40c9-9b41-7f0d2ad6f5fb"), "Swimming Coach (Daily 710)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 602, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Swimming Coach (Daily 710)" },
                    { new Guid("97971ccf-7a59-4422-967c-7e767d3a2b6c"), "Plantation Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 448, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Plantation Manager" },
                    { new Guid("97df672d-c1b9-456c-8415-c3a3243d15f1"), "Facilities Management Associate (Mesnry)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 196, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Mesnry)" },
                    { new Guid("980111ee-b2e2-4550-8b98-ea08c958d554"), "Telephone Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 617, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Telephone Technician" },
                    { new Guid("9819dcb9-a751-46f1-9ad2-1dbdfb3924e2"), "Lift Operator - O", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 343, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lift Operator - O" },
                    { new Guid("982eb526-aa67-4771-9dfb-7e8a4c5c2099"), "Electrician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 167, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Electrician" },
                    { new Guid("987fac4e-94c5-47bd-9f2e-267cd4320cca"), "Day Brc Female", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 136, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Day Brc Female" },
                    { new Guid("9a559d9e-8a48-4fd1-ac5c-de4ac5df1155"), "Feedback", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 208, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Feedback" },
                    { new Guid("9a90871d-9a77-4393-a7e7-b5794fff0405"), "Mis", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 383, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mis" },
                    { new Guid("9acfc795-4120-493d-b579-451da2059233"), "Vendor Garbage", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 639, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Vendor Garbage" },
                    { new Guid("9be0b78e-6202-4cc5-8e86-440aa7a95220"), "Senior Office Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 517, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Office Assistant" },
                    { new Guid("9c51cae0-2c75-4961-86bd-b1617c11928f"), "Security Guard Iii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 481, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard Iii" },
                    { new Guid("9c9d937c-f2ba-4242-8ef6-771fa3f59ef4"), "Peon", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 435, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Peon" },
                    { new Guid("9d53cefd-8b66-4795-a2d5-f470c46abfba"), "Pat-Roller Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 433, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pat-Roller Supervisor" },
                    { new Guid("9dc30180-0b5b-40dd-800c-e4e1f569b832"), "Operator - Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 424, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Operator - Ssw" },
                    { new Guid("9dedbf62-ddef-4484-aa4d-0d91e777fcf6"), "Guard Arms", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 251, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guard Arms" },
                    { new Guid("9e52c603-47e7-4622-87fb-aebdfcc0b83e"), "Marketing - Sr. Executive", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 366, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Marketing - Sr. Executive" },
                    { new Guid("9e563b81-5a0e-4c62-a356-93d1258c56dd"), "Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 574, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor" },
                    { new Guid("9e7b73f7-2e50-4edf-ade7-e69eff212424"), "Cable Maint", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 73, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cable Maint" },
                    { new Guid("9ea91fff-214c-4108-a1d6-7e6fee00aaaa"), "Executive(Tender Cell)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 186, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive(Tender Cell)" },
                    { new Guid("9ecfc331-f49e-42e3-baba-9f3cddad25ae"), "Manager - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 351, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager - Sw" },
                    { new Guid("9f872afd-ffc9-481e-893e-0177691f92a6"), "Syce", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 605, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Syce" },
                    { new Guid("9f9c2d39-225e-4f66-b633-72a61028c704"), "Md-Managing Director", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 377, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Md-Managing Director" },
                    { new Guid("9ff01f59-bc27-4324-9c01-2c50dc3207ee"), "Fata Kreastal Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 206, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fata Kreastal Helipad" },
                    { new Guid("9ff1c227-4eb4-4332-910c-fee8ebdedf40"), "Training Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 627, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant" },
                    { new Guid("a0388842-fbaf-43a1-b86c-af0376b3ba00"), "Senior Peon", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 518, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Peon" },
                    { new Guid("a0464e8f-2994-4421-8d87-fe46de41174f"), "Data Entry Operator 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 133, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data Entry Operator 2" },
                    { new Guid("a04b9313-8a98-4a5f-9fc9-2d7b7978d09d"), "Computer Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 106, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator" },
                    { new Guid("a13f5ffb-7df9-4128-810a-c0c57ec416eb"), "Site Engineer - Electrical", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 535, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Engineer - Electrical" },
                    { new Guid("a1619177-3602-460d-aeba-18f6b0dd206b"), "Deputy Manager- Technical", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 149, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Manager- Technical" },
                    { new Guid("a16470e7-f717-470a-8d3f-87413d60b82f"), "Placement Coordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 445, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Placement Coordinator" },
                    { new Guid("a1ae6e41-5940-443d-8bde-9fe06e035aeb"), "Executive Accountant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 184, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive Accountant" },
                    { new Guid("a1ec4b70-1785-48bb-928f-f2800d4255d9"), "Manager-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 362, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Operation" },
                    { new Guid("a225ca8c-b291-4daa-b09d-507a36ca2036"), "Brush Cutter Operator - Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 65, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Brush Cutter Operator - Ssw" },
                    { new Guid("a26a67e6-9385-4550-93c8-e5b076e472c7"), "Hvac Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 310, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hvac Operator" },
                    { new Guid("a2d980ac-3fb9-4eed-a5e1-918b64285f05"), "Hr Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 309, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hr Head" },
                    { new Guid("a2dc3507-ff4c-4ecc-af09-61307f325721"), "Ss-W", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 557, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ss-W" },
                    { new Guid("a38a83d2-0e45-42c0-94cc-8ca0702a97ae"), "Warden", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 644, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Warden" },
                    { new Guid("a3c7d102-fa54-4466-9a84-b47f453c9322"), "Electrician - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 169, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Electrician - Sw" },
                    { new Guid("a416dc64-6fac-47a9-bf67-50398f85d83f"), "Genral Manager-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 239, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Genral Manager-Hr" },
                    { new Guid("a4aa09c1-5dc0-4770-aa1e-0006a36f8d09"), "Circle Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 92, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Circle Head" },
                    { new Guid("a52e5111-2c03-4bca-a7f7-e7ba5a6235e4"), "Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 173, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Engineer" },
                    { new Guid("a5969b12-8f90-4c4a-9dcb-0ddaf3d14a1c"), "Worker - Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 652, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker - Usw" },
                    { new Guid("a5a0f2d2-ccb7-4a73-ae19-8a9046defe2c"), "Security Guard Ii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 480, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard Ii" },
                    { new Guid("a7372b43-33ba-4a17-910c-cc407f617243"), "Dummy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 165, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dummy" },
                    { new Guid("a76ee198-3679-4490-a032-6ea6b6f9d580"), "Housekeeping-Mcc-Spl", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 304, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping-Mcc-Spl" },
                    { new Guid("a84aa346-e41b-49e5-8e98-da917aa47e4c"), "Training Assistant-Accounts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 628, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Accounts" },
                    { new Guid("a88857ee-edb0-47e1-b31f-b376be41caa1"), "Welder - Hsw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 647, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Welder - Hsw" },
                    { new Guid("a8b61376-f408-4a70-9ce3-a68716f27951"), "Supervisior-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 571, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior-Hr Admin" },
                    { new Guid("a8d9bd36-08a4-4424-9053-5b5df7cd54da"), "Care Taker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 77, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Care Taker" },
                    { new Guid("a8f0be6b-d4ff-4c37-998d-50b2d9984690"), "Labour-Watering", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 330, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Labour-Watering" },
                    { new Guid("a916ce60-f0d0-4f8a-b468-6eb8bce89758"), "Supervisor - Watering", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 587, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Watering" },
                    { new Guid("a95925a7-477b-48fa-b176-d2113f5c1c87"), "Riger", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 471, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Riger" },
                    { new Guid("a9bec1a2-3c79-4e69-8478-4a064a7a6b5f"), "Dcpo", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 138, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dcpo" },
                    { new Guid("aa44e43b-1550-4ee8-9fe8-1e9d717ee79d"), "C.R.Att", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 72, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "C.R.Att" },
                    { new Guid("aa83c82d-d2f9-4f92-8c55-1360cb99cc08"), "Commi-Iii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 104, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Commi-Iii" },
                    { new Guid("aac803f1-83b6-4372-97ef-fe42fb7f39ce"), "Manager-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 359, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Hr Admin" },
                    { new Guid("ab644645-ff12-4994-8853-97a42eb7ef90"), "Quaility And Placement Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 465, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Quaility And Placement Head" },
                    { new Guid("ab77473d-56eb-42eb-a8f4-b4fd18568747"), "Service Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 528, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Service Engineer" },
                    { new Guid("ab8f4181-6e25-4557-aa0d-9448cc1d295c"), "Assistant Accountant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Accountant" },
                    { new Guid("ac255eb7-64fe-4970-aeb3-58dcb2f4a63d"), "Gen Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 235, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gen Usw" },
                    { new Guid("ac9f2a6e-f954-41f4-be41-40fafecf76f8"), "Instructor (Racquet Games)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 312, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Instructor (Racquet Games)" },
                    { new Guid("acea3ca8-46ca-4922-915f-43f35655882f"), "Consultant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 119, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Consultant" },
                    { new Guid("adb4481b-decc-4905-b4fc-7bee84432561"), "Healthcare Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 275, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Healthcare Supervisor" },
                    { new Guid("adb463f7-7e17-4de7-821a-cccb9d22657e"), "Security-Cum-Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 488, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security-Cum-Driver" },
                    { new Guid("adcc7805-495b-4d1e-92d7-87fcba9feec3"), "Instrument", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 314, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Instrument" },
                    { new Guid("ae8c68c1-dcf8-4164-8d42-e0fce52be8e0"), "Junior Assistant 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 321, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Junior Assistant 1" },
                    { new Guid("af00e359-84e9-4b79-9a18-906715667c2a"), "Senior Electrician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 501, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Electrician" },
                    { new Guid("af7c507f-c5e5-4223-9a04-7f3dc443de0f"), "Senior Helper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 515, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Helper" },
                    { new Guid("af7d49e2-3a0e-4c79-8abd-3eda7a305573"), "Block Project Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 60, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Block Project Manager" },
                    { new Guid("b1bb91a2-c605-4f8f-92fa-c4d8d9391924"), "Branch Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 64, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Branch Manager" },
                    { new Guid("b1e529a7-3f0e-4873-ac18-b0f525f7d184"), "Advisor (Security)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Advisor (Security)" },
                    { new Guid("b2f6509b-c74d-4f5e-8a65-de3e73aca6c4"), "Mta-Spl", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 393, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mta-Spl" },
                    { new Guid("b3084ca4-e154-4f6d-aa8f-3f1f1d70d28a"), "Worker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 648, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker" },
                    { new Guid("b33115a8-7e2b-40cf-9dce-431c61affb20"), "Hostel Sec", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 287, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hostel Sec" },
                    { new Guid("b34d1cfd-fd2c-495d-b84c-50d98aca3fb1"), "Co-Ordinator Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Co-Ordinator Hr" },
                    { new Guid("b399df26-95d3-41f4-b4a0-4a877af2ab73"), "Senior Gardener", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 514, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Gardener" },
                    { new Guid("b430d0d2-3343-4f5e-bf52-507f070fac74"), "Laundry Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 336, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Laundry Supervisor" },
                    { new Guid("b52c390a-9873-4eb7-baf4-a2e9a2254ca6"), "Genral Manager-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 241, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Genral Manager-Marketing" },
                    { new Guid("b5b19f88-b187-4f93-9145-4e1378512598"), "Instructor (Swimming)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 313, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Instructor (Swimming)" },
                    { new Guid("b61abd17-44ea-4c30-8ec1-b91bb5d778c9"), "Machine Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 346, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Machine Operator" },
                    { new Guid("b6587291-292f-4185-9e69-4220bb214a15"), "Head Of Department-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 272, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department-Scm" },
                    { new Guid("b6b8708a-f063-4dda-848f-89cd0f05bed4"), "Hostel Boy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 284, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hostel Boy" },
                    { new Guid("b6de4974-6fd0-4598-ba3d-e58476bc4b48"), "Media Consultant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 378, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Media Consultant" },
                    { new Guid("b80c46ac-2127-489d-b598-5036a9b1d220"), "Gunman Ii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 257, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gunman Ii" },
                    { new Guid("b813abab-0ab3-437b-a021-7d91c677c04a"), "Hostel", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 283, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hostel" },
                    { new Guid("b8337885-544a-456a-8b96-e53cf6dd4d58"), "Instructor (Gym)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 311, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Instructor (Gym)" },
                    { new Guid("b8410ca0-2387-4b7c-881f-4f5f768d99c1"), "Front Office Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 222, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Front Office Supervisor" },
                    { new Guid("b865ca58-9d50-4301-8d20-e25bcf995507"), "Admin Receptionist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Admin Receptionist" },
                    { new Guid("b8c22ae5-6a78-4e2f-a07e-42aaa28a5082"), "Assistant-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 47, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant-Hr Admin" },
                    { new Guid("b9384923-54b9-4596-955b-acd297f747ab"), "Assistant Manager-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 40, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Operation" },
                    { new Guid("b9b68170-9ce3-4750-9847-58b9dfe0391d"), "Housekeeping-Mcc-Day", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 303, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping-Mcc-Day" },
                    { new Guid("b9e0206a-29c3-44d5-a84f-878c0d38e851"), "Facilities Management Associate -Welding", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 201, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate -Welding" },
                    { new Guid("ba314f74-59bf-48c4-b482-74d14d12ea2a"), "Swimming Coach", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 601, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Swimming Coach" },
                    { new Guid("bae8a415-9d0d-47a3-b352-d24103fca6e5"), "Gardner Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 231, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gardner Skilled" },
                    { new Guid("bb3a6a87-ad36-4d40-b24b-1a699480eeec"), "Supervisior Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 568, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior Operation" },
                    { new Guid("bb4c4580-b5a3-4026-84b1-29cad044494b"), "Conservancy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 118, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Conservancy" },
                    { new Guid("bb971f18-848f-428a-836c-5c95a1840e49"), "Ex- Gun Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 180, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ex- Gun Man" },
                    { new Guid("bc10fd03-87b9-418c-9202-a41dbf445b99"), "Manager-Ccmr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 356, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Ccmr" },
                    { new Guid("bc1fa0aa-689b-4e6e-aeba-33e361aec31c"), "Content Writer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 120, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Content Writer" },
                    { new Guid("bc2c8da8-5d32-4516-b202-e66a6dde5a07"), "Establishment", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 177, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Establishment" },
                    { new Guid("bd74208d-ef63-4e2c-a4b2-c1ca15d6d638"), "Data Entry Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 131, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data Entry Operator" },
                    { new Guid("be5a7e42-9a3f-4e4f-817b-39476d50b788"), "Legal Co-Ordinator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 338, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Legal Co-Ordinator" },
                    { new Guid("bebedf8c-ea54-470f-9c51-45b60c0d9f42"), "Mta", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 392, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mta" },
                    { new Guid("bf196969-5109-4486-88fd-82938d7d9472"), "Caterpiller Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 82, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Caterpiller Driver" },
                    { new Guid("bf4cc6ed-c850-475e-a4e1-1b870a344758"), "Mis Sr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 386, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mis Sr" },
                    { new Guid("c031a420-9e65-481f-8570-7e5aae8e60af"), "Serveyar Ameen", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 527, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Serveyar Ameen" },
                    { new Guid("c0427215-dcbb-4387-b400-b534db306783"), "Assistant-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 50, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant-Scm" },
                    { new Guid("c05ab4de-404d-45f5-9633-1ccbc4fa2339"), "Manager- Hr (Recruitment)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 354, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager- Hr (Recruitment)" },
                    { new Guid("c07ebd8e-439c-4eb3-850a-5f3267287c25"), "Assistant Engineer (Civil)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Engineer (Civil)" },
                    { new Guid("c099f567-25a0-454d-a4ca-7aa98eb18173"), "Semi Skilled Worker", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 491, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Semi Skilled Worker" },
                    { new Guid("c11804f1-d568-428c-81f0-7f26c8fa8ea8"), "Yoga Instructor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 663, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Yoga Instructor" },
                    { new Guid("c197c28f-5cad-4036-8e15-ba6a07b99e18"), "Shift Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 531, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Shift Supervisor" },
                    { new Guid("c1d24f3f-1a0c-44f0-8ae5-fd24941af6cd"), "Medical Centre", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 380, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Medical Centre" },
                    { new Guid("c28955ab-333e-4657-9731-48956b9af96d"), "Painter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 430, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Painter" },
                    { new Guid("c2b36beb-f2d3-43fb-89ba-ee6094183c6b"), "Assistant-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 45, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant-Finance" },
                    { new Guid("c2fb5c16-3589-43af-88b1-36d22d03db4c"), "Legal Associate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 337, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Legal Associate" },
                    { new Guid("c3364709-0841-458e-a41b-1cd64e03c6ce"), "House Keeping - Night", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 291, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping - Night" },
                    { new Guid("c337d59f-2f9c-4064-bc31-fe78e241c0d5"), "Site - Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 532, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site - Admin" },
                    { new Guid("c33e2261-0ed4-4c65-88c4-3687463abf84"), "Obhs- Ground Staff", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 408, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Obhs- Ground Staff" },
                    { new Guid("c340e170-025c-4051-a1d2-416ef4c730f5"), "Assistant Site Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 44, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Site Manager" },
                    { new Guid("c3cbb178-a159-459f-a12f-cde0e5824b35"), "Helper 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 278, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Helper 2" },
                    { new Guid("c48a82e4-486a-47be-a5f0-88bb59fc2a8e"), "District Programme Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 155, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "District Programme Manager" },
                    { new Guid("c52bf6f5-e4cb-4685-9dbf-f8e86a7ea83a"), "Assistant Engineer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Engineer" },
                    { new Guid("c560fa07-bca8-484e-907e-3ca4597d4f30"), "Site Engineer - Civil", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 534, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Engineer - Civil" },
                    { new Guid("c58a5994-3f2c-4849-8450-e77318501837"), "Genral Manager-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 243, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Genral Manager-Scm" },
                    { new Guid("c5964a1c-79cb-415a-a508-23077f9976e3"), "Stp Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 564, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Stp Operator" },
                    { new Guid("c652c592-0194-4f2c-a035-01f295b179ec"), "Trainee It", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 621, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee It" },
                    { new Guid("c67ffa29-b69b-4dbe-bfb0-6d9331377b1b"), "Cts+Hk", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 125, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cts+Hk" },
                    { new Guid("c7b1af3c-7708-489b-ac7b-4972bdaffa55"), "Garden Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 226, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Garden Supervisor" },
                    { new Guid("c80e14d8-9183-4076-948e-ccbb1a464985"), "Director", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 152, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Director" },
                    { new Guid("c82ff353-c561-41f1-94ec-d9c2cbf59d42"), "Supervisor Night", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 588, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor Night" },
                    { new Guid("c86c1c3c-069e-4b0e-b812-6a4d6101822e"), "H.R Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 262, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "H.R Officer" },
                    { new Guid("c8ebc05b-0b27-4a77-893a-d23a1569d370"), "Program Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 453, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Program Assistant" },
                    { new Guid("c9b819b3-9448-4f6c-9572-fb547ed9971b"), "Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Admin" },
                    { new Guid("ca5987be-d7a5-4684-afa5-a4d1d3aa7a37"), "Social Media Expert", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 546, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Social Media Expert" },
                    { new Guid("cafe8ad9-b7a5-470a-b4ec-f7543245c481"), "Laundry Boy", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 335, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Laundry Boy" },
                    { new Guid("cb2e91e8-14ea-4a18-a492-938074e1c8de"), "Security Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 485, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Supervisor" },
                    { new Guid("cb369edf-91df-45b8-975f-9d9ae02269c9"), "Training Assistant-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 631, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Training Assistant-Hr Admin" },
                    { new Guid("cb42e9ee-84d3-442b-b5e7-b711d7478918"), "Cts-Housekeeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 126, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Cts-Housekeeper" },
                    { new Guid("cb564e8d-4aa8-4678-a87f-4cb32a90acf8"), "Factory", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 203, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Factory" },
                    { new Guid("cc1e57c6-9b94-4dad-8331-91fcfc4513b8"), "Sr Office Associate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 552, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sr Office Associate" },
                    { new Guid("cc24e251-1676-4289-8a5f-eabdb252d309"), "Ceo/Coo", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 86, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ceo/Coo" },
                    { new Guid("cc34262c-f1a2-4e19-81dc-b8251ece69c1"), "Site Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 540, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Manager" },
                    { new Guid("cc405392-c2ab-483a-b1bb-26d87f527fad"), "Facilities Management Associate (Swimng)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 198, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Swimng)" },
                    { new Guid("ccd2dc27-ab02-49ad-90b2-ba9a208c52b0"), "Senior Accountant 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 494, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Accountant 2" },
                    { new Guid("cd1b3257-b7b3-47ff-ad5e-37cdff2be132"), "Computer Operator 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 108, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator 1" },
                    { new Guid("cd9721f3-8a97-449f-a111-d6ab2b545c05"), "Computer Operator 1 - A", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 109, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator 1 - A" },
                    { new Guid("cde919a3-fb0d-41d5-8f51-9948fa09f8b6"), "Field Technician", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 214, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Field Technician" },
                    { new Guid("ce3069db-400f-4a05-ad9a-648dcd9056f8"), "Dependent", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 141, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dependent" },
                    { new Guid("ce37dd70-0cd7-45bb-8a5d-c8aa7373ed9d"), "Housekeeping - Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 297, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping - Usw" },
                    { new Guid("cf0a761d-bb81-4873-aa76-09fe34704cae"), "General Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 236, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "General Manager" },
                    { new Guid("d0a1056d-db2e-4a4e-9ffb-e55a3e02d30b"), "Area Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Area Officer" },
                    { new Guid("d0a4b6cf-e51a-4c0a-960b-316824ecb794"), "Trainee Office Associate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 623, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Trainee Office Associate" },
                    { new Guid("d10b8ded-bc75-4549-8805-6122643ea760"), "Assistant-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 48, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant-Marketing" },
                    { new Guid("d13b9987-0cd4-447f-afd2-dbe73418a251"), "Diesel Generator Operator", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 151, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Diesel Generator Operator" },
                    { new Guid("d176291d-d748-44c4-8b25-85f2bfe8cd69"), "Unskilled - Chappra", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 636, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Unskilled - Chappra" },
                    { new Guid("d1d8f1bc-a06a-4f36-ae9f-627be50ea8cd"), "Field Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 213, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Field Supervisor" },
                    { new Guid("d1f0d433-944c-4732-bec5-e1a511658b8d"), "Ceo", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 85, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ceo" },
                    { new Guid("d227b8b4-cb77-47ab-934a-ce64afa1fa9e"), "Worker - Cts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 649, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker - Cts" },
                    { new Guid("d28ef972-4825-4361-8dcc-bdf4970945f9"), "Marketing Head", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 368, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Marketing Head" },
                    { new Guid("d3569318-f4fd-4b33-bfc5-2ccdd1534c65"), "Territory Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 618, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Territory Assistant" },
                    { new Guid("d3cc7f7c-cf18-4e71-b11a-101862631b91"), "Managing Director", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 364, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Managing Director" },
                    { new Guid("d423636a-c799-47be-9b75-d67803140b23"), "Armed Guard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Armed Guard" },
                    { new Guid("d4380eb8-3fe3-417b-98de-558ccc71ba7e"), "Senior Project Manager - F", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 521, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Project Manager - F" },
                    { new Guid("d441adc5-1754-43a1-9ba4-119854eb3812"), "Machine Operator - Ssw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 347, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Machine Operator - Ssw" },
                    { new Guid("d4c9dc45-de72-41e7-8780-f4d89c16a062"), "Head Of Department", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 266, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department" },
                    { new Guid("d5e11a3a-e851-4a6d-b60c-340da41ed283"), "Office Associate - Junior", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 413, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Associate - Junior" },
                    { new Guid("d62cf384-6a9c-41b6-9a44-9ebd14a49d56"), "Assistant Engineer (Electronics  Comm)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 27, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Engineer (Electronics  Comm)" },
                    { new Guid("d698ee53-ca8a-4013-8b14-2fbaa7d5bb6c"), "Housekeeping - Usw (Spcl)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 298, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping - Usw (Spcl)" },
                    { new Guid("d6e5a81f-04f4-476b-b2c5-1105b81d5f03"), "Lineman", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 344, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lineman" },
                    { new Guid("d735d7e2-3412-46d3-a61b-d1dca5405826"), "Assistant-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 49, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant-Operation" },
                    { new Guid("d73d417e-e932-48c0-915e-71f3d830b553"), "Assistant Reception", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 42, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Reception" },
                    { new Guid("d7a85f45-db71-4249-8402-4b1582daa9b6"), "Flt Operator - Sw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 220, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Flt Operator - Sw" },
                    { new Guid("d7c00041-0855-4526-8632-a3743f277b02"), "Executive-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 187, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive-Finance" },
                    { new Guid("d7ff6290-16da-4b77-b918-cc0f97bdd1d7"), "Supervisor - Cts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 575, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Cts" },
                    { new Guid("d969a9b4-1829-4733-ac15-2438954cc822"), "Point Incharge", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 451, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Point Incharge" },
                    { new Guid("d9836b35-2700-47c8-bc0b-c27560b283dd"), "Office Assistant - F", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 410, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Assistant - F" },
                    { new Guid("da447fd9-7e7e-4b5a-ab60-7d26e72abf50"), "Sershi Triyuginarayan Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 526, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sershi Triyuginarayan Helipad" },
                    { new Guid("da871b8f-4ff9-4c53-bcbe-84aff80cc0fe"), "Mts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 394, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mts" },
                    { new Guid("daaab05e-7b0a-406c-8e71-1c621d7a9bf4"), "Sershi Krestal Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 525, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sershi Krestal Helipad" },
                    { new Guid("dabdbfd0-334b-4134-92d8-229a77503bdd"), "Supervisor - Station", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 594, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Station" },
                    { new Guid("dad9a955-5834-4941-8b19-9ec2e5683e30"), "Bouncer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 62, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Bouncer" },
                    { new Guid("db0419ce-d11c-489e-8b30-b7faee29d81e"), "Software Developer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 547, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Software Developer" },
                    { new Guid("dbc50ce8-29f8-40fd-8954-07b7a98b5d0d"), "Manager-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 363, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Manager-Scm" },
                    { new Guid("dbf71a15-7d57-4678-9dcd-3377f6e65131"), "Security Guard", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 476, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Guard" },
                    { new Guid("dc3ce5a8-70ef-457a-b078-428bec3e7fb8"), "Spl Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 550, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Spl Usw" },
                    { new Guid("dc5fd767-92ba-4b06-8e85-02bee57fdbdb"), "Sweeper Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 600, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sweeper Usw" },
                    { new Guid("dcf8e3df-9376-4f80-a7ed-1891ec2bfea6"), "House Keeping Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 295, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping Supervisor" },
                    { new Guid("dd0847ff-a4a2-4c5b-8b54-80185cca3721"), "None", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 405, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "None" },
                    { new Guid("dd493596-13e5-4c70-9d81-830c47702377"), "House Keeping Sever", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 294, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping Sever" },
                    { new Guid("dd9813d0-dc31-4e95-9859-8d2c9b99ea7b"), "Site Incharge", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 539, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Site Incharge" },
                    { new Guid("ddcb24cf-7e78-423e-8374-8fc506e3c31d"), "Block Resource Person", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 61, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Block Resource Person" },
                    { new Guid("de34231f-68f7-4616-a9c4-c064a4c5e97c"), "Zonal Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 666, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Zonal Manager" },
                    { new Guid("de3c21fe-c5a1-4e80-99fc-a2d1549f0af0"), "Senior Accountant 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 493, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Accountant 1" },
                    { new Guid("de4d11ae-0b12-4c8f-8c99-dec4f7911595"), "Attendant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 53, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Attendant" },
                    { new Guid("de5c6d68-65a1-4e30-8894-f6b85c7e9b37"), "Senior Executive- Billing  Collection", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 507, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Executive- Billing  Collection" },
                    { new Guid("de62ef92-83d5-4ad9-b698-e0f402479819"), "Facilities Management Associate- Welding", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 202, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate- Welding" },
                    { new Guid("de8ca2c7-13aa-42ea-87f9-a34cf03f5f68"), "Personnel Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 439, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Personnel Officer" },
                    { new Guid("de9aee34-28f6-4e12-85ce-2f6e0b3098f5"), "Worker Special", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 654, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Worker Special" },
                    { new Guid("deb57206-8dc4-4382-961e-649d5355502f"), "Library Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 340, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Library Assistant" },
                    { new Guid("df0769d2-bede-4d2b-a263-92926ac5cea5"), "Ground Staff - Iii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 250, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ground Staff - Iii" },
                    { new Guid("df362589-2ce8-4a5b-8c58-95a95e449861"), "Fata Global Helipad", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 205, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fata Global Helipad" },
                    { new Guid("df9421ff-6d81-497b-ad53-dabe69eb254c"), "Head Peon", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 273, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Peon" },
                    { new Guid("e01e7fd4-7539-41c6-9dda-56e06a95a59a"), "Gardner Labour", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 229, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gardner Labour" },
                    { new Guid("e02e4fb7-b85a-42c0-b841-ddf3382a266e"), "Genral Manager-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 240, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Genral Manager-Hr Admin" },
                    { new Guid("e0a2e4fa-8d85-48cf-8848-1293118cfb37"), "Driver (Doctor)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 160, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Driver (Doctor)" },
                    { new Guid("e0bb4e41-9173-4611-bb0f-0e0861d4e16b"), "Forklift Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 221, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Forklift Driver" },
                    { new Guid("e1213c54-0e57-46d9-b6f4-fb5b275c525e"), "Tandoor Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 608, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Tandoor Man" },
                    { new Guid("e12d1229-4ee1-4a1c-84e0-318751895d0d"), "House Keeping - Pfr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 292, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "House Keeping - Pfr" },
                    { new Guid("e16a877f-7b76-4fe7-bb0f-bd608cd5c621"), "Housekeeper", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 296, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeper" },
                    { new Guid("e1b268a4-89bf-4bf7-98bb-d5e94148aed4"), "Glass Cleaner", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 244, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Glass Cleaner" },
                    { new Guid("e1b8f57b-1209-4ce4-affe-346931e1b9b8"), "Housekeeping Ii", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 299, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Housekeeping Ii" },
                    { new Guid("e1d2e89a-5681-408d-896e-7652b164a872"), "Facilities Management Associate (Carpnt)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 194, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Carpnt)" },
                    { new Guid("e1ec519d-60c1-4948-8890-9dbb6fb9cd3a"), "Lab Assistant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 327, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Lab Assistant" },
                    { new Guid("e3558556-e776-400b-b900-6608cbfb0b60"), "L.D.C", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 326, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "L.D.C" },
                    { new Guid("e5c9c5ed-dfbf-4865-885d-293e7564f2c6"), "Tehsildar", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 615, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Tehsildar" },
                    { new Guid("e5e32dbc-76ba-4ec9-ae9a-af9c32eb90a4"), "Computer Operator 2", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 110, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator 2" },
                    { new Guid("e6500020-8e9c-48d0-b868-2b1d07fb7036"), "Fire Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 215, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Fire Man" },
                    { new Guid("e669e5d1-a6fb-4e1e-916a-1ad392974114"), "Graphic Designer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 246, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Graphic Designer" },
                    { new Guid("e6c5ad2c-8c3a-4cde-93ad-638d247c1906"), "Sr. Executive- Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 553, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sr. Executive- Operation" },
                    { new Guid("e72fe663-2b37-4881-aa55-060005a71367"), "Guest House Manager-Cum-Senior Chef", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 254, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Guest House Manager-Cum-Senior Chef" },
                    { new Guid("e7bb1c9e-ac6a-44c2-a08e-4c8e71e8c70a"), "Security Officer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 483, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Officer" },
                    { new Guid("e812e98d-e032-42ce-8b95-63f2842fe249"), "Supervisior-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 569, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior-Finance" },
                    { new Guid("e88683de-7201-469d-bfaa-e8394b73afed"), "Driver (Hmv)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 161, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Driver (Hmv)" },
                    { new Guid("e969aca1-ef1d-4997-9c5e-1b4b28e54e2e"), "Gm - Usw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 245, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gm - Usw" },
                    { new Guid("e9708641-9eed-4304-9c3d-1bcc6341e4b1"), "Supervisor - Pfr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 582, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - Pfr" },
                    { new Guid("ea1a0112-da77-4606-9b7d-a78d14a4cc33"), "Hr Executive Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 307, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hr Executive Admin" },
                    { new Guid("ea2f0309-9e12-4435-b2f0-454b07b7c538"), "Supervisior - Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 567, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior - Operation" },
                    { new Guid("ea4714e8-3205-4637-8460-028bcad1c23e"), "Org.Chem.Div", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 427, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Org.Chem.Div" },
                    { new Guid("ea6b60db-b445-4fcb-807d-28ddf5d8a46f"), "Accountant", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Accountant" },
                    { new Guid("eaa38568-7ac7-4ddb-9e7a-351eeb8385a7"), "Hostel Boy Un-Skilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 286, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hostel Boy Un-Skilled" },
                    { new Guid("eaec2eb0-5eef-4c69-9090-6cac9fe07a26"), "Horticulturist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 282, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Horticulturist" },
                    { new Guid("eaf766e0-e01c-4f5d-ac76-3abbba348790"), "Monkey Handler", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 391, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Monkey Handler" },
                    { new Guid("eb23ecb9-d205-4f8a-b907-b54cb2fca343"), "Genral Manager-Finance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 238, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Genral Manager-Finance" },
                    { new Guid("eb6e8e95-0bd9-4f51-8087-c1066d3dcc68"), "Assistant - Repair  Maintenance", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant - Repair  Maintenance" },
                    { new Guid("ebb2ad42-1abf-47d1-8a65-e92b1c2f0a0f"), "Security Trainer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 486, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Security Trainer" },
                    { new Guid("ebc848ec-f31e-4f4a-9b95-6b396d50e668"), "Electronic Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 172, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Electronic Supervisor" },
                    { new Guid("ec134ce8-ca53-401d-a3b8-e7559a7872ca"), "Unskilled", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 635, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Unskilled" },
                    { new Guid("ec96f292-6466-40ed-abb2-d0334d70485e"), "Facilities Management Associate (Electr)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 195, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Electr)" },
                    { new Guid("ecb5ff4b-3e4d-4887-a0c1-29ef4d708b6b"), "Senior Plumber", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 519, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Plumber" },
                    { new Guid("ece096d9-21d6-45db-b095-111f07fe0c55"), "Computer Operator 3", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 112, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator 3" },
                    { new Guid("ed9f5c1c-6150-4676-b9b4-6da6382965ae"), "Executive Vice President", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 185, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive Vice President" },
                    { new Guid("eef00ae3-860e-4796-845a-93628a0dd5fd"), "Nursing Associate", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 407, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Nursing Associate" },
                    { new Guid("ef1569ca-ee43-4f37-845c-677880da8f96"), "Office Associate (Marketing)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 412, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Office Associate (Marketing)" },
                    { new Guid("efc91006-68ef-420f-8a25-1cb2c483b7db"), "Front Office Supervisor - F", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 223, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Front Office Supervisor - F" },
                    { new Guid("f030a908-3ee4-4b9a-9547-064b209d006e"), "Computer Operator 2 - A", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 111, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator 2 - A" },
                    { new Guid("f0a87667-1bc3-4688-85fb-bc656da4bf9f"), "Accounting Expert", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Accounting Expert" },
                    { new Guid("f149a956-5884-4140-8da9-32145e7a3c31"), "Ambulance Driver", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ambulance Driver" },
                    { new Guid("f16c7a0d-7ef7-4f18-b6b9-aaac79ba9923"), "Supervisor -APDJ", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 590, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisor - APDJ" },
                    { new Guid("f1d3dc0b-815c-402f-a057-30a213ab0d9b"), "Janitor-Fix", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 318, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Janitor-Fix" },
                    { new Guid("f2303717-2027-452c-8537-6636469da1a5"), "Bed Bearer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 55, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Bed Bearer" },
                    { new Guid("f24bd63f-ab6a-4aae-951b-4f2e0d409fe0"), "Assistant Manager (Accounts)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 31, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager (Accounts)" },
                    { new Guid("f2c796c9-7a3a-4cd9-9c87-4d2d6014b4a4"), "Computer Operator Grade 1", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 113, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Computer Operator Grade 1" },
                    { new Guid("f372f20b-e980-4203-bc5c-c02ff8f233ef"), "Deputy Genral Manager-Hr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 144, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Deputy Genral Manager-Hr" },
                    { new Guid("f3b607bb-d5b3-482d-983c-0e20689b11e8"), "X.Ray Attendante", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 662, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "X.Ray Attendante" },
                    { new Guid("f49850b7-9cf9-4eeb-885c-0a92290de5b3"), "Ward Aya", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 642, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ward Aya" },
                    { new Guid("f5214ccf-bb48-4455-aabe-f148fbe520ec"), "Facilities Management Associate (Telep)", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 200, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Facilities Management Associate (Telep)" },
                    { new Guid("f609489a-6679-4955-a160-4a827d3da3fe"), "It Person", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 315, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "It Person" },
                    { new Guid("f6b76480-cf63-486e-ac61-72a4112ecfc8"), "Superintendent", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 566, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Superintendent" },
                    { new Guid("f7386421-67fb-4df6-ba51-f5bbc3da59f3"), "Garden", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 225, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Garden" },
                    { new Guid("f791ec65-ae1f-4549-98f7-9f1f658afa80"), "Senior Supervisor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 522, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Supervisor" },
                    { new Guid("f8895442-c903-48e6-9d4b-688e505100a6"), "Project Head Hsw", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 458, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Project Head Hsw" },
                    { new Guid("f92e22b9-0de5-466a-b63b-3eb93ee6e3cc"), "Old House Keeping", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 420, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Old House Keeping" },
                    { new Guid("f96d107b-7b2f-4eef-baaf-52b60d65a925"), "Helper-Electrical", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 279, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Helper-Electrical" },
                    { new Guid("fa0ce04e-761f-4213-a083-4d7752aca5e2"), "Gas Cutter", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 233, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gas Cutter" },
                    { new Guid("fa2e0907-cfab-428d-9cb8-950f51791bf3"), "Executive-Hr Admin", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 189, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Executive-Hr Admin" },
                    { new Guid("fa98e723-34b1-4ac4-a591-7d3fa4b76ebf"), "Assistant Manager-Scm", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 41, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant Manager-Scm" },
                    { new Guid("fad34ed5-f4eb-42e9-9a30-6417f291dc81"), "Pa", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 429, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Pa" },
                    { new Guid("fb06022e-a605-4900-9781-df20dbdff7a5"), "Welder", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 646, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Welder" },
                    { new Guid("fb2133a9-7d2e-49a2-a713-affc525fc7a9"), "Data  Analysts", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 129, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Data  Analysts" },
                    { new Guid("fb7b07fc-1c4d-4ea5-9652-f9bdec6c8478"), "Stenographer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 560, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Stenographer" },
                    { new Guid("fb9c2025-bb1c-4b86-b170-56d62ed91f18"), "English And Soft Skill Trainer", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 174, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "English And Soft Skill Trainer" },
                    { new Guid("fbe8d424-8267-4cc0-b55a-f4573c0e030f"), "Gang Man", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 224, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gang Man" },
                    { new Guid("fc09169c-69d7-4094-830b-4637821b1ebf"), "Unskilled - Varanasi", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Unskilled - Varanasi" },
                    { new Guid("fcae015b-101b-4cdb-9aff-b692c6808327"), "Private Secretary", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 452, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Private Secretary" },
                    { new Guid("fcbc2547-9809-4b23-9130-9776ae830fd4"), "Dg Operatort", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 150, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dg Operatort" },
                    { new Guid("fce42a6a-e133-425c-bd68-dc1af7bc2bbe"), "Supervisior-Marketing", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 572, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Supervisior-Marketing" },
                    { new Guid("fd68e6dc-63a6-4a98-bd48-0da278da1105"), "Head Of Department-Operation", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 271, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Head Of Department-Operation" },
                    { new Guid("fe7cec72-269e-4497-88bb-c47ca368467e"), "Senior Project Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 520, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Senior Project Manager" },
                    { new Guid("fe939af6-513d-4ddd-ac9a-f7ed8d6e9914"), "Accounting Specialist", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Accounting Specialist" },
                    { new Guid("ff109bc0-ebb1-4d10-b78b-72af62928910"), "Gym Instructor", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 260, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Gym Instructor" },
                    { new Guid("ff55663d-e9cb-4b21-b668-81d139cefcb1"), "Assistant - Procurement  Site Manager", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Assistant - Procurement  Site Manager" },
                    { new Guid("ffae59ad-537c-4698-9a86-c374cf12a920"), "P. A.  Director", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 428, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "P. A.  Director" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "Description", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name", "Purpose" },
                values: new object[,]
                {
                    { new Guid("295324bc-6ef8-4d98-aa9d-c94bdbbd2259"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Issued by Govt. Of India", false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Aadhaar Card", 7 },
                    { new Guid("45326a21-127b-4095-bf23-d96d8f11d43c"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Issued by Govt. Of India", false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "10th Marksheet", 12 },
                    { new Guid("6e7487b3-2d2c-40ee-ad2e-416798d790dd"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Issued by Govt. Of India", false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "PAN Card", 1 }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Subject", "TemplateName" },
                values: new object[,]
                {
                    { new Guid("3d37d753-1fff-4cf0-840d-9298f99c72c2"), "<!DOCTYPE html>\r\n                        <html>\r\n                        <head>\r\n                            <title>Password Reset</title>\r\n                        </head>\r\n                        <body style=\"font-family: Arial, sans-serif; line-height: 1.6;\">\r\n                            <p>Dear User,</p>\r\n                            <p>We received a request to reset your password. Please click the link below to proceed:</p>\r\n                            <p><a href=\"{ResetLink}\" style=\"color: #007bff; text-decoration: none;\">Reset Your Password</a></p>\r\n                            <p>If you did not request a password reset, please ignore this email or contact our support team immediately.</p>\r\n                            <p>If you have any questions or need assistance, feel free to reach out to us at <a href=\"mailto:support@yourcompany.com\">support@yourcompany.com</a>.</p>\r\n                            <p>Best regards,</p>\r\n                            <p><strong>Administrator</strong><br><your company name></p>\r\n                        </body>\r\n                        </html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Reset Your Password - <your company name>", "ForgotPassword" },
                    { new Guid("4d47e853-2eff-5cf1-940e-a398f01d83e1"), "<!DOCTYPE html>\r\n                        <html>\r\n                        <head>\r\n                            <title>Password Changed</title>\r\n                        </head>\r\n                        <body style=\"font-family: Arial, sans-serif; line-height: 1.6;\">\r\n                            <p>Dear User,</p>\r\n                            <p>We wanted to let you know that your password was successfully changed. If you made this change, no further action is needed.</p>\r\n                            <p>If you did not make this change, please contact our support team immediately to secure your account:</p>\r\n                            <p><a href=\"mailto:support@yourcompany.com\">support@yourcompany.com</a></p>\r\n                            <p>For your security, we recommend choosing a strong password that you don't use for any other accounts.</p>\r\n                            <p>Best regards,</p>\r\n                            <p><strong>Administrator</strong><br><your company name></p>\r\n                        </body>\r\n                        </html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Your Password Has Been Changed - <your company name>", "PasswordChanged" },
                    { new Guid("80aad593-6a40-44d5-abb3-aa25bea241b9"), "<!DOCTYPE html><html><head><title>Welcome to <your compnay name></title></head><body><h1>Welcome, {FirstName} {LastName}!</h1><p>Dear {FirstName},</p><p>We&#39;re thrilled to have you join the <your compnay name>. Thank you for registering with us!</p><p>To get started, please confirm your email address by clicking the link below:</p><p><a href=\"{EmailVerificationLink}\">Verify Your Email</a></p><p>This will help us ensure we have the correct email address for your account. It only takes a few moments.</p><p>Once your email is verified, you&#39;ll be able to fully access your account.</p><p>If you have any questions or need assistance, feel free to reach out to our support team at <your compnay email>.</p><p>Welcome aboard, and we look forward to having you with us!</p><p>Best regards,</p><p>Administrator <your compnay name></p></body></html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "<your compnay name> Registration Successful for {FirstName} {LastName}", "RegistrationDone" },
                    { new Guid("eae9d433-cbfb-40fe-960a-cde265b2faea"), "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Welcome to the Organization</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;\r\n            color: #333;\r\n            background-color: #f9f9f9;\r\n            padding: 20px;\r\n        }\r\n        .container {\r\n            background-color: #ffffff;\r\n            padding: 30px;\r\n            border-radius: 8px;\r\n            box-shadow: 0px 0px 10px #ccc;\r\n        }\r\n        .footer {\r\n            margin-top: 30px;\r\n            font-size: 12px;\r\n            color: #888;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <h2>Hello {UserName},</h2>\r\n\r\n        <p>Welcome aboard! We are thrilled to have you join our team.</p>\r\n\r\n        <p>Your registration has been successfully completed, and we are excited about the contributions you’ll bring to the organization.</p>\r\n\r\n        <p><strong>Your official joining date is:</strong> {DateOfJoining}</p>\r\n\r\n        <p>If you have any questions before your start date, feel free to reach out to your hiring manager or HR representative.</p>\r\n\r\n        <p>We look forward to working with you and seeing you thrive in your new role!</p>\r\n		\r\n		<p>No action required from your end, will notify once your profile is approved </p>\r\n		\r\n        <p>Warm regards,</p>\r\n        <p><strong>HR Team</strong><br/>SBS Enterprises</p>\r\n\r\n        <div class=\"footer\">\r\n            This is an automated email. Please do not reply to this message.\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Welcome to the Organization, {UserName}!", "StaffCreated" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("36347864-631a-4f09-a62e-f090a3a5cc5b"), "M", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Male" },
                    { new Guid("d98d9544-7ae7-43de-ab11-3dc7a46b4a0e"), "F", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Female" }
                });

            migrationBuilder.InsertData(
                table: "HighestEducations",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("1fd20a85-e0ae-4efd-91a8-e097c043e30d"), "PG", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Post Graduate" },
                    { new Guid("5606ce88-efbf-4406-8cfd-ee2aab75a76d"), "M", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Matric" },
                    { new Guid("5e039e37-dc5f-48cc-8dca-17a82174d779"), "G", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Graduate" },
                    { new Guid("912cf56b-e42e-4297-86a8-8b7c6c1fdd6a"), "UG", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Under Graduate" },
                    { new Guid("a6aa659e-23d5-4a4f-9030-4ff36a3a8d05"), "AM", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Above Matric" },
                    { new Guid("b0724662-f36f-4be6-9fc1-0122ae89b634"), "BM", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Below Matric" }
                });

            migrationBuilder.InsertData(
                table: "NavigationNodes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IconUrl", "IsActive", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "ParentId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("359b62b8-f29c-423d-bba2-78c164c7762c"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Dashboard", "/admin/dashboard" },
                    { new Guid("3f484034-afc6-4853-a76c-c064b34c2c84"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Organizations", "#" },
                    { new Guid("5c8f1888-76e1-4de2-b848-e2dd181cc2f4"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Approval", "#" },
                    { new Guid("bf88a20b-f140-4b74-8e87-c4a1b39f3a7f"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Reports", "#" },
                    { new Guid("c414e1d3-c63c-4eaf-af0d-eab721ccc5a5"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Registeration", "/admin/register" },
                    { new Guid("e591f87a-535e-430e-a38f-20c2228bab3f"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Master Data", "#" },
                    { new Guid("f80ab6d3-dadf-45e9-81ad-462679804c33"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", null, "Staff Profiles", "/admin/staff-profiles" }
                });

            migrationBuilder.InsertData(
                table: "RecruitmentTypes",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("105b314f-db6d-420f-b54e-1bb827e7754a"), "RD", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Recruitment Drive" },
                    { new Guid("568ab9c5-a0d3-441d-80e8-5a5651798324"), "WI", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Walk -in" },
                    { new Guid("57b75925-449a-407e-8cc3-ebff71ea3496"), "R", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Referral" },
                    { new Guid("7f9a2901-e56c-4395-950d-a8a103f07de5"), "O", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("2bb813c8-afcc-4174-a857-a52d92eab2f2"), "J", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Jainism" },
                    { new Guid("382eaeda-ada5-4c4b-9891-693a156a2a05"), "H", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Hinduism" },
                    { new Guid("41aab106-56ac-4340-9c30-14b1e416dcfe"), "Other", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Other" },
                    { new Guid("b337b608-dbb7-4bc7-8e6d-9e6e3fdeb2ea"), "B", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Buddhism" },
                    { new Guid("dc15429b-959e-4b9e-be27-34976cce6e05"), "M", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Islam" },
                    { new Guid("debc3435-4b3f-4665-9bcd-9ec7225645a4"), "C", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Christianity" },
                    { new Guid("f63930fa-f10c-471c-baec-07aace8ab55c"), "S", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Sikhism" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IsDeleted", "IsFemale", "IsMale", "ModifiedByUserId", "ModifiedByUserName", "Name" },
                values: new object[,]
                {
                    { new Guid("2673ea56-221c-433e-9a54-a2740615f9ab"), "Dr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, false, true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Dr" },
                    { new Guid("38a86421-edb4-4226-8e95-423f65785280"), "Miss", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, false, true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Miss" },
                    { new Guid("93ee9668-462f-437e-bf20-84bef4c38428"), "Ms", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, false, true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Ms" },
                    { new Guid("ad77f3f7-cf8a-4f72-a38d-f9aaade1d79f"), "Mr", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, false, true, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mr" },
                    { new Guid("e38e5fb5-5339-46b9-b108-df23f286a5f4"), "Mrs", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Mrs" }
                });

            migrationBuilder.InsertData(
                table: "ClientMasters",
                columns: new[] { "Id", "ClientName", "CompanyId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "IsActive", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "ProjectCost", "ProjectEndDate", "ProjectLocation", "ProjectStartDate" },
                values: new object[,]
                {
                    { new Guid("836bd5c1-c940-4900-9e49-fd6fee2c80fa"), "My Second Company - Client master 1", new Guid("74c8b851-922f-45b9-9c28-0c53c06120aa"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, 178956.0, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lucknow", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("8a4a5a20-7236-46e4-9739-8ab7a47f554e"), "My First Company - Client master 1", new Guid("489d4544-5461-4132-aa29-688758627c98"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, 178956.0, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lucknow", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f6d29be9-277a-423e-8213-de2f866d5301"), "My First Company - Client master 2", new Guid("489d4544-5461-4132-aa29-688758627c98"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, 178956.0, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lucknow", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "NavigationNodeRoles",
                columns: new[] { "NavigationNodeId", "RoleId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "Id", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName" },
                values: new object[,]
                {
                    { new Guid("359b62b8-f29c-423d-bba2-78c164c7762c"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("3f484034-afc6-4853-a76c-c064b34c2c84"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("5c8f1888-76e1-4de2-b848-e2dd181cc2f4"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("bf88a20b-f140-4b74-8e87-c4a1b39f3a7f"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("c414e1d3-c63c-4eaf-af0d-eab721ccc5a5"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("e591f87a-535e-430e-a38f-20c2228bab3f"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("f80ab6d3-dadf-45e9-81ad-462679804c33"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" }
                });

            migrationBuilder.InsertData(
                table: "NavigationNodes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IconUrl", "IsActive", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "ParentId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("358aa86a-fc2e-4bb5-80b5-2a29892e8432"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("3f484034-afc6-4853-a76c-c064b34c2c84"), "Companies", "/admin/companies" },
                    { new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("e591f87a-535e-430e-a38f-20c2228bab3f"), "Company", "#" },
                    { new Guid("50396e86-cb2e-4884-bea0-e9083e205e4b"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("bf88a20b-f140-4b74-8e87-c4a1b39f3a7f"), "Staff Reports", "/admin/staff-reports" },
                    { new Guid("8d9a9ddf-b3c3-4e95-b76e-a6ba646d0c01"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("5c8f1888-76e1-4de2-b848-e2dd181cc2f4"), "Approval Stages", "/admin/approval-stages" },
                    { new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("e591f87a-535e-430e-a38f-20c2228bab3f"), "General", "#" },
                    { new Guid("ca0bb9e6-ee53-4143-9edb-7ce118804b5b"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("5c8f1888-76e1-4de2-b848-e2dd181cc2f4"), "Approval Stage Approvers", "/admin/approval-stage-approvers" },
                    { new Guid("e19c5a99-dc2c-4e23-8f73-71c79c2966f7"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("5c8f1888-76e1-4de2-b848-e2dd181cc2f4"), "Approval Workflows", "/admin/approval-workflows" },
                    { new Guid("e32c3111-85b2-46c7-b2c8-3f65c1f0adeb"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("3f484034-afc6-4853-a76c-c064b34c2c84"), "Client Masters", "/admin/client-masters" },
                    { new Guid("f0002561-462e-4767-8f5e-08bfd53f42f0"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("3f484034-afc6-4853-a76c-c064b34c2c84"), "Client Units", "/admin/client-units" }
                });

            migrationBuilder.InsertData(
                table: "RegistrationSequences",
                columns: new[] { "CompanyId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "Id", "IsDeleted", "LastRegistrationId", "ModifiedByUserId", "ModifiedByUserName", "Prefix" },
                values: new object[,]
                {
                    { new Guid("489d4544-5461-4132-aa29-688758627c98"), null, null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), false, 100, null, null, "MFC" },
                    { new Guid("74c8b851-922f-45b9-9c28-0c53c06120aa"), null, null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), false, 1000, null, null, "MSO" }
                });

            migrationBuilder.InsertData(
                table: "ClientUnits",
                columns: new[] { "Id", "ClientMasterId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "IsActive", "IsDeleted", "MaxHeadCount", "ModifiedByUserId", "ModifiedByUserName", "UnitLocation", "UnitName" },
                values: new object[,]
                {
                    { new Guid("2654ab1a-dc1d-4b93-9249-9cd4f9228968"), new Guid("8a4a5a20-7236-46e4-9739-8ab7a47f554e"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 15, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, "Kanpur", "My first unit" },
                    { new Guid("61054527-d93f-4c43-ac91-d869a6428327"), new Guid("836bd5c1-c940-4900-9e49-fd6fee2c80fa"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 10, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, "Agra", "My 4th unit" },
                    { new Guid("b7ed692b-63fc-441f-8748-0f10672d9e8d"), new Guid("f6d29be9-277a-423e-8213-de2f866d5301"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 30, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, "Unnao", "My 3rd unit" },
                    { new Guid("f1a7c96c-d787-488d-8c04-22e3aaac0cee"), new Guid("8a4a5a20-7236-46e4-9739-8ab7a47f554e"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 0, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, "Lakhimpur", "My 2nd unit" }
                });

            migrationBuilder.InsertData(
                table: "NavigationNodeRoles",
                columns: new[] { "NavigationNodeId", "RoleId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "Id", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName" },
                values: new object[,]
                {
                    { new Guid("358aa86a-fc2e-4bb5-80b5-2a29892e8432"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("50396e86-cb2e-4884-bea0-e9083e205e4b"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("8d9a9ddf-b3c3-4e95-b76e-a6ba646d0c01"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("ca0bb9e6-ee53-4143-9edb-7ce118804b5b"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("e19c5a99-dc2c-4e23-8f73-71c79c2966f7"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("e32c3111-85b2-46c7-b2c8-3f65c1f0adeb"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("f0002561-462e-4767-8f5e-08bfd53f42f0"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" }
                });

            migrationBuilder.InsertData(
                table: "NavigationNodes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DisplayOrder", "IconUrl", "IsActive", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "ParentId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("028f48a9-a50d-495a-a27e-39c84da74b9a"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Document Types", "/admin/document-types" },
                    { new Guid("12a135f3-d536-4250-acbf-a38aad2d802a"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Banks", "/admin/banks" },
                    { new Guid("4d156919-c672-43df-aa19-d93e975d5bda"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Menu", "/admin/navigation-nodes" },
                    { new Guid("57ec63e1-52d5-44cc-a9d1-cded389f2014"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Zipcodes", "/admin/zipcodes" },
                    { new Guid("5a770876-0d03-4841-bfe0-7c56d4b561d2"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Branchs", "/admin/branch" },
                    { new Guid("734db850-8030-4f9e-8a14-20ae10ae8cb3"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Recruitment Types", "/admin/recruitment-types" },
                    { new Guid("75d38d82-7f26-488e-8bd9-0eaea1b08633"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Religions", "/admin/religions" },
                    { new Guid("83277279-1ae9-49e5-96f6-579e53918cca"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Caste Categories", "/admin/caste-categories" },
                    { new Guid("984fb724-f924-40c8-b667-753abd515a49"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Countries", "/admin/countries" },
                    { new Guid("a51aa7b3-cc4a-4191-a061-8cece9c11a75"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Genders", "/admin/genders" },
                    { new Guid("b73a59f0-cdd5-4895-a0e7-feea45ff5511"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Titles", "/admin/titles" },
                    { new Guid("c5571635-29dc-4196-9091-a866c1da3bc4"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Categories", "/admin/categories" },
                    { new Guid("d7c6b998-c97e-4235-8e9e-e3661aa6753d"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Assets", "/admin/assets" },
                    { new Guid("e49f315d-4ed0-4002-80ad-d81001fe0d1a"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("a394a640-1c19-4949-9795-5321e7e55c90"), "Highest Educations", "/admin/highest-educations" },
                    { new Guid("fc58cb5d-d393-4d89-b0fe-7bcb1b013061"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "", true, false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new Guid("4956b6a2-dd9d-4d7d-85bb-6961076c4f13"), "Designations", "/admin/designations" }
                });

            migrationBuilder.InsertData(
                table: "NavigationNodeRoles",
                columns: new[] { "NavigationNodeId", "RoleId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "Id", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName" },
                values: new object[,]
                {
                    { new Guid("028f48a9-a50d-495a-a27e-39c84da74b9a"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("12a135f3-d536-4250-acbf-a38aad2d802a"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("4d156919-c672-43df-aa19-d93e975d5bda"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("57ec63e1-52d5-44cc-a9d1-cded389f2014"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("5a770876-0d03-4841-bfe0-7c56d4b561d2"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("734db850-8030-4f9e-8a14-20ae10ae8cb3"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("75d38d82-7f26-488e-8bd9-0eaea1b08633"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("83277279-1ae9-49e5-96f6-579e53918cca"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("984fb724-f924-40c8-b667-753abd515a49"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("a51aa7b3-cc4a-4191-a061-8cece9c11a75"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("b73a59f0-cdd5-4895-a0e7-feea45ff5511"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("c5571635-29dc-4196-9091-a866c1da3bc4"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("d7c6b998-c97e-4235-8e9e-e3661aa6753d"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("e49f315d-4ed0-4002-80ad-d81001fe0d1a"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" },
                    { new Guid("fc58cb5d-d393-4d89-b0fe-7bcb1b013061"), new Guid("ba2e09d3-8a52-48a5-a4a9-178e53d60fde"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "AadhaarNumber", "AlternatePhoneNumber", "BranchId", "CategoryId", "ClientMasterId", "ClientUnitId", "CompanyId", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "DateOfBirth", "DateOfJoining", "DateOfRegistration", "DesignationId", "Email", "EsicNumber", "FirstName", "GenderId", "IdentityMarks", "IsActive", "IsDeleted", "LastName", "MiddleName", "MobileNumber", "ModifiedByUserId", "ModifiedByUserName", "PanNumber", "PlaceOfBirth", "ProfilePictureUrl", "RecruitmentTypeId", "RegistrationId", "TitleId", "UanNumber", "UserId", "UserProfileStatus" },
                values: new object[,]
                {
                    { new Guid("83b6730a-c27c-4898-a7ca-29ad3b59213a"), "987654321002", null, new Guid("c1a1d1e1-f1a1-4711-8899-000000000001"), new Guid("25082ec5-82bf-4d5c-86f6-42f50aff16a6"), new Guid("8a4a5a20-7236-46e4-9739-8ab7a47f554e"), new Guid("2654ab1a-dc1d-4b93-9249-9cd4f9228968"), new Guid("489d4544-5461-4132-aa29-688758627c98"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, new Guid("0e9b6202-47f4-404f-b2f8-712e95a7b148"), null, null, "System", null, null, true, false, "HR", "", null, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, null, null, null, null, "MSO -1000", new Guid("ad77f3f7-cf8a-4f72-a38d-f9aaade1d79f"), null, new Guid("2e9cfc1e-c228-41b5-bada-2f859ec9de32"), "Approved" },
                    { new Guid("ed8e68c4-4df4-4989-9155-fed3052d8d25"), "987654321001", null, new Guid("c1a1d1e1-f1a1-4711-8899-000000000001"), new Guid("25082ec5-82bf-4d5c-86f6-42f50aff16a6"), new Guid("8a4a5a20-7236-46e4-9739-8ab7a47f554e"), new Guid("2654ab1a-dc1d-4b93-9249-9cd4f9228968"), new Guid("489d4544-5461-4132-aa29-688758627c98"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, new Guid("f0a87667-1bc3-4688-85fb-bc656da4bf9f"), null, null, "System", null, null, true, false, "Admin", "", null, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, null, null, null, null, "MFC -0100", new Guid("ad77f3f7-cf8a-4f72-a38d-f9aaade1d79f"), null, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "Approved" },
                    { new Guid("f7b2cb32-e7f5-4ebb-845a-4947dabfb92f"), "987654321003", null, new Guid("c1a1d1e1-f1a1-4711-8899-000000000001"), new Guid("25082ec5-82bf-4d5c-86f6-42f50aff16a6"), new Guid("8a4a5a20-7236-46e4-9739-8ab7a47f554e"), new Guid("2654ab1a-dc1d-4b93-9249-9cd4f9228968"), new Guid("489d4544-5461-4132-aa29-688758627c98"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, new Guid("a2d980ac-3fb9-4eed-a5e1-918b64285f05"), null, null, "System", null, null, true, false, "HR Head", "", null, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), null, null, null, null, null, "MSO -1001", new Guid("ad77f3f7-cf8a-4f72-a38d-f9aaade1d79f"), null, new Guid("38ccee5b-9eab-49a0-a30f-d6cb52e7d11d"), "Approved" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreatedByUserId",
                table: "Addresses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ModifiedByUserId",
                table: "Addresses",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserProfileId_IsActive",
                table: "Addresses",
                columns: new[] { "UserProfileId", "IsActive" });

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
                name: "IX_ApprovalRequests_ApprovalWorkflowId",
                table: "ApprovalRequests",
                column: "ApprovalWorkflowId");

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
                name: "IX_ApprovalRequestStages_ApprovalRequestId",
                table: "ApprovalRequestStages",
                column: "ApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_ApprovalStageId",
                table: "ApprovalRequestStages",
                column: "ApprovalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_CreatedByUserId",
                table: "ApprovalRequestStages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStages_ModifiedByUserId",
                table: "ApprovalRequestStages",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_ApprovalStageId",
                table: "ApprovalStageApprovers",
                column: "ApprovalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_CompanyId",
                table: "ApprovalStageApprovers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_CreatedByUserId",
                table: "ApprovalStageApprovers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_ModifiedByUserId",
                table: "ApprovalStageApprovers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_RoleId",
                table: "ApprovalStageApprovers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStageApprovers_UserId",
                table: "ApprovalStageApprovers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_ApprovalWorkflowId",
                table: "ApprovalStages",
                column: "ApprovalWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_CreatedByUserId",
                table: "ApprovalStages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStages_ModifiedByUserId",
                table: "ApprovalStages",
                column: "ModifiedByUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CreatedByUserId",
                table: "Assets",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ModifiedByUserId",
                table: "Assets",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                table: "BankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CreatedByUserId",
                table: "BankAccounts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_ModifiedByUserId",
                table: "BankAccounts",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserProfileId",
                table: "BankAccounts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CreatedByUserId",
                table: "Banks",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_ModifiedByUserId",
                table: "Banks",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_CreatedByUserId",
                table: "BodyMeasurements",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_ModifiedByUserId",
                table: "BodyMeasurements",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_UserProfileId",
                table: "BodyMeasurements",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CreatedByUserId",
                table: "Branches",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ModifiedByUserId",
                table: "Branches",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CasteCategories_CreatedByUserId",
                table: "CasteCategories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CasteCategories_ModifiedByUserId",
                table: "CasteCategories",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ModifiedByUserId",
                table: "Categories",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMasters_CompanyId",
                table: "ClientMasters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMasters_CreatedByUserId",
                table: "ClientMasters",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMasters_ModifiedByUserId",
                table: "ClientMasters",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUnits_ClientMasterId",
                table: "ClientUnits",
                column: "ClientMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUnits_CreatedByUserId",
                table: "ClientUnits",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUnits_ModifiedByUserId",
                table: "ClientUnits",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_CreatedByUserId",
                table: "Communications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_ModifiedByUserId",
                table: "Communications",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_UserProfileId",
                table: "Communications",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedByUserId",
                table: "Companies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ModifiedByUserId",
                table: "Companies",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedByUserId",
                table: "Countries",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ModifiedByUserId",
                table: "Countries",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_CreatedByUserId",
                table: "Designations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_ModifiedByUserId",
                table: "Designations",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_CreatedByUserId",
                table: "DocumentTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_ModifiedByUserId",
                table: "DocumentTypes",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_CreatedByUserId",
                table: "EmailTemplates",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_ModifiedByUserId",
                table: "EmailTemplates",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_CreatedByUserId",
                table: "EmployeeReferences",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_ModifiedByUserId",
                table: "EmployeeReferences",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_UserProfileId",
                table: "EmployeeReferences",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVerifications_CreatedByUserId",
                table: "EmployeeVerifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVerifications_ModifiedByUserId",
                table: "EmployeeVerifications",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVerifications_UserProfileId",
                table: "EmployeeVerifications",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExArmies_CreatedByUserId",
                table: "ExArmies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExArmies_ModifiedByUserId",
                table: "ExArmies",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExArmies_UserProfileId",
                table: "ExArmies",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Famlies_CreatedByUserId",
                table: "Famlies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Famlies_ModifiedByUserId",
                table: "Famlies",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Famlies_UserProfileId",
                table: "Famlies",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_CreatedByUserId",
                table: "Genders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_ModifiedByUserId",
                table: "Genders",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GunMen_CreatedByUserId",
                table: "GunMen",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GunMen_ModifiedByUserId",
                table: "GunMen",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GunMen_UserProfileId",
                table: "GunMen",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_HighestEducations_CreatedByUserId",
                table: "HighestEducations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HighestEducations_ModifiedByUserId",
                table: "HighestEducations",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceNominees_CreatedByUserId",
                table: "InsuranceNominees",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceNominees_ModifiedByUserId",
                table: "InsuranceNominees",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceNominees_UserProfileId",
                table: "InsuranceNominees",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_CreatedByUserId",
                table: "Insurances",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_ModifiedByUserId",
                table: "Insurances",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_UserProfileId",
                table: "Insurances",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedByUserId",
                table: "MenuItems",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ModifiedByUserId",
                table: "MenuItems",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RoleId",
                table: "MenuItems",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CreatedByUserId",
                table: "Menus",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ModifiedByUserId",
                table: "Menus",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationNodeRoles_CreatedByUserId",
                table: "NavigationNodeRoles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationNodeRoles_ModifiedByUserId",
                table: "NavigationNodeRoles",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationNodeRoles_RoleId",
                table: "NavigationNodeRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationNodes_CreatedByUserId",
                table: "NavigationNodes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationNodes_ModifiedByUserId",
                table: "NavigationNodes",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationNodes_ParentId",
                table: "NavigationNodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceVerifications_CreatedByUserId",
                table: "PoliceVerifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceVerifications_ModifiedByUserId",
                table: "PoliceVerifications",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceVerifications_UserProfileId",
                table: "PoliceVerifications",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousExperiences_CreatedByUserId",
                table: "PreviousExperiences",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousExperiences_ModifiedByUserId",
                table: "PreviousExperiences",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousExperiences_UserProfileId",
                table: "PreviousExperiences",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentTypes_CreatedByUserId",
                table: "RecruitmentTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentTypes_ModifiedByUserId",
                table: "RecruitmentTypes",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSequences_CreatedByUserId",
                table: "RegistrationSequences",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSequences_ModifiedByUserId",
                table: "RegistrationSequences",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_CreatedByUserId",
                table: "Religions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_ModifiedByUserId",
                table: "Religions",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignations_CreatedByUserId",
                table: "Resignations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignations_ModifiedByUserId",
                table: "Resignations",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignations_UserProfileId",
                table: "Resignations",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityDeposits_CreatedByUserId",
                table: "SecurityDeposits",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityDeposits_ModifiedByUserId",
                table: "SecurityDeposits",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityDeposits_UserProfileId",
                table: "SecurityDeposits",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_CreatedByUserId",
                table: "Titles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_ModifiedByUserId",
                table: "Titles",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CreatedByUserId",
                table: "Trainings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ModifiedByUserId",
                table: "Trainings",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_UserProfileId",
                table: "Trainings",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_AssetId",
                table: "UserAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_CreatedByUserId",
                table: "UserAssets",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_ModifiedByUserId",
                table: "UserAssets",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_UserProfileId",
                table: "UserAssets",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_CreatedByUserId",
                table: "UserDocuments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_DocumentTypeId",
                table: "UserDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_ModifiedByUserId",
                table: "UserDocuments",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_UserProfileId",
                table: "UserDocuments",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_CasteCategoryId",
                table: "UserGeneralDetails",
                column: "CasteCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_CountryId",
                table: "UserGeneralDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_CreatedByUserId",
                table: "UserGeneralDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_HighestEducationId",
                table: "UserGeneralDetails",
                column: "HighestEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_ModifiedByUserId",
                table: "UserGeneralDetails",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_ReligionId",
                table: "UserGeneralDetails",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneralDetails_UserProfileId",
                table: "UserGeneralDetails",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_BranchId",
                table: "UserProfiles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CategoryId",
                table: "UserProfiles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ClientMasterId",
                table: "UserProfiles",
                column: "ClientMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ClientUnitId",
                table: "UserProfiles",
                column: "ClientUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CompanyId",
                table: "UserProfiles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CreatedByUserId",
                table: "UserProfiles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_DesignationId",
                table: "UserProfiles",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_GenderId",
                table: "UserProfiles",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ModifiedByUserId",
                table: "UserProfiles",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_RecruitmentTypeId",
                table: "UserProfiles",
                column: "RecruitmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_RegistrationId",
                table: "UserProfiles",
                column: "RegistrationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_TitleId",
                table: "UserProfiles",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_CreatedByUserId",
                table: "ZipCodes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_ModifiedByUserId",
                table: "ZipCodes",
                column: "ModifiedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ApprovalActions");

            migrationBuilder.DropTable(
                name: "ApprovalStageApprovers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "BodyMeasurements");

            migrationBuilder.DropTable(
                name: "Communications");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "EmployeeReferences");

            migrationBuilder.DropTable(
                name: "EmployeeVerifications");

            migrationBuilder.DropTable(
                name: "ExArmies");

            migrationBuilder.DropTable(
                name: "Famlies");

            migrationBuilder.DropTable(
                name: "GunMen");

            migrationBuilder.DropTable(
                name: "InsuranceNominees");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "NavigationNodeRoles");

            migrationBuilder.DropTable(
                name: "PoliceVerifications");

            migrationBuilder.DropTable(
                name: "PreviousExperiences");

            migrationBuilder.DropTable(
                name: "RegistrationSequences");

            migrationBuilder.DropTable(
                name: "Resignations");

            migrationBuilder.DropTable(
                name: "SecurityDeposits");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "UserAssets");

            migrationBuilder.DropTable(
                name: "UserDocuments");

            migrationBuilder.DropTable(
                name: "UserGeneralDetails");

            migrationBuilder.DropTable(
                name: "ZipCodes");

            migrationBuilder.DropTable(
                name: "ApprovalRequestStages");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "NavigationNodes");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "CasteCategories");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "HighestEducations");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropTable(
                name: "ApprovalStages");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ClientUnits");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "RecruitmentTypes");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "ApprovalWorkflows");

            migrationBuilder.DropTable(
                name: "ClientMasters");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
