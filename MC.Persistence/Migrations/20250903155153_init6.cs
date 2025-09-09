using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "CreatedByUserId", "CreatedByUserName", "DateCreated", "DateModified", "IsDeleted", "ModifiedByUserId", "ModifiedByUserName", "Subject", "TemplateName" },
                values: new object[,]
                {
                    { new Guid("3d37d753-1fff-4cf0-840d-9298f99c72c2"), "<!DOCTYPE html>\r\n                        <html>\r\n                        <head>\r\n                            <title>Password Reset</title>\r\n                        </head>\r\n                        <body style=\"font-family: Arial, sans-serif; line-height: 1.6;\">\r\n                            <p>Dear User,</p>\r\n                            <p>We received a request to reset your password. Please click the link below to proceed:</p>\r\n                            <p><a href=\"{ResetLink}\" style=\"color: #007bff; text-decoration: none;\">Reset Your Password</a></p>\r\n                            <p>If you did not request a password reset, please ignore this email or contact our support team immediately.</p>\r\n                            <p>If you have any questions or need assistance, feel free to reach out to us at <a href=\"mailto:support@yourcompany.com\">support@yourcompany.com</a>.</p>\r\n                            <p>Best regards,</p>\r\n                            <p><strong>Administrator</strong><br><your company name></p>\r\n                        </body>\r\n                        </html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Reset Your Password - <your company name>", "ForgotPassword" },
                    { new Guid("4d47e853-2eff-5cf1-940e-a398f01d83e1"), "<!DOCTYPE html>\r\n                        <html>\r\n                        <head>\r\n                            <title>Password Changed</title>\r\n                        </head>\r\n                        <body style=\"font-family: Arial, sans-serif; line-height: 1.6;\">\r\n                            <p>Dear User,</p>\r\n                            <p>We wanted to let you know that your password was successfully changed. If you made this change, no further action is needed.</p>\r\n                            <p>If you did not make this change, please contact our support team immediately to secure your account:</p>\r\n                            <p><a href=\"mailto:support@yourcompany.com\">support@yourcompany.com</a></p>\r\n                            <p>For your security, we recommend choosing a strong password that you don't use for any other accounts.</p>\r\n                            <p>Best regards,</p>\r\n                            <p><strong>Administrator</strong><br><your company name></p>\r\n                        </body>\r\n                        </html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "Your Password Has Been Changed - <your company name>", "PasswordChanged" },
                    { new Guid("80aad593-6a40-44d5-abb3-aa25bea241b9"), "<!DOCTYPE html><html><head><title>Welcome to <your compnay name></title></head><body><h1>Welcome, {FirstName} {LastName}!</h1><p>Dear {FirstName},</p><p>We&#39;re thrilled to have you join the <your compnay name>. Thank you for registering with us!</p><p>To get started, please confirm your email address by clicking the link below:</p><p><a href=\"{EmailVerificationLink}\">Verify Your Email</a></p><p>This will help us ensure we have the correct email address for your account. It only takes a few moments.</p><p>Once your email is verified, you&#39;ll be able to fully access your account.</p><p>If you have any questions or need assistance, feel free to reach out to our support team at <your compnay email>.</p><p>Welcome aboard, and we look forward to having you with us!</p><p>Best regards,</p><p>Administrator <your compnay name></p></body></html>", new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "System Admin", "<your compnay name> Registration Successful for {FirstName} {LastName}", "RegistrationDone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("3d37d753-1fff-4cf0-840d-9298f99c72c2"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("4d47e853-2eff-5cf1-940e-a398f01d83e1"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("80aad593-6a40-44d5-abb3-aa25bea241b9"));
        }
    }
}
