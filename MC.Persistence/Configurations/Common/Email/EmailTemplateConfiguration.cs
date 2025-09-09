using MC.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Common.Email
{
    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(b => b.TemplateName)
                  .HasConversion<string>()
                  .HasMaxLength(30);

            builder.Property(z => z.Subject).IsRequired().HasMaxLength(200);
            builder.Property(z => z.Body).IsRequired().HasColumnType("longtext");

            builder.HasData(
                new EmailTemplate
                {
                    Id = Guid.Parse("{EAE9D433-CBFB-40FE-960A-CDE265B2FAEA}"),
                    TemplateName = Domain.Entity.Enum.EmailTemplateType.StaffCreated,
                    Subject = "Welcome to the Organization, {UserName}!",
                    Body = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Welcome to the Organization</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;\r\n            color: #333;\r\n            background-color: #f9f9f9;\r\n            padding: 20px;\r\n        }\r\n        .container {\r\n            background-color: #ffffff;\r\n            padding: 30px;\r\n            border-radius: 8px;\r\n            box-shadow: 0px 0px 10px #ccc;\r\n        }\r\n        .footer {\r\n            margin-top: 30px;\r\n            font-size: 12px;\r\n            color: #888;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <h2>Hello {UserName},</h2>\r\n\r\n        <p>Welcome aboard! We are thrilled to have you join our team.</p>\r\n\r\n        <p>Your registration has been successfully completed, and we are excited about the contributions you’ll bring to the organization.</p>\r\n\r\n        <p><strong>Your official joining date is:</strong> {DateOfJoining}</p>\r\n\r\n        <p>If you have any questions before your start date, feel free to reach out to your hiring manager or HR representative.</p>\r\n\r\n        <p>We look forward to working with you and seeing you thrive in your new role!</p>\r\n\t\t\r\n\t\t<p>No action required from your end, will notify once your profile is approved </p>\r\n\t\t\r\n        <p>Warm regards,</p>\r\n        <p><strong>HR Team</strong><br/>SBS Enterprises</p>\r\n\r\n        <div class=\"footer\">\r\n            This is an automated email. Please do not reply to this message.\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new EmailTemplate
                {
                    Id = new Guid("{80AAD593-6A40-44D5-ABB3-AA25BEA241B9}"),
                    TemplateName = Domain.Entity.Enum.EmailTemplateType.RegistrationDone,
                    Subject = "<your compnay name> Registration Successful for {FirstName} {LastName}",
                    Body = "<!DOCTYPE html><html><head><title>Welcome to <your compnay name></title></head><body><h1>Welcome, {FirstName} {LastName}!</h1><p>Dear {FirstName},</p><p>We&#39;re thrilled to have you join the <your compnay name>. Thank you for registering with us!</p><p>To get started, please confirm your email address by clicking the link below:</p><p><a href=\"{EmailVerificationLink}\">Verify Your Email</a></p><p>This will help us ensure we have the correct email address for your account. It only takes a few moments.</p><p>Once your email is verified, you&#39;ll be able to fully access your account.</p><p>If you have any questions or need assistance, feel free to reach out to our support team at <your compnay email>.</p><p>Welcome aboard, and we look forward to having you with us!</p><p>Best regards,</p><p>Administrator <your compnay name></p></body></html>",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new EmailTemplate
                {
                    Id = new Guid("{3D37D753-1FFF-4CF0-840D-9298F99C72C2}"),
                    TemplateName = Domain.Entity.Enum.EmailTemplateType.ForgotPassword,
                    Subject = "Reset Your Password - <your company name>",
                    Body = @"<!DOCTYPE html>
                        <html>
                        <head>
                            <title>Password Reset</title>
                        </head>
                        <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                            <p>Dear User,</p>
                            <p>We received a request to reset your password. Please click the link below to proceed:</p>
                            <p><a href=""{ResetLink}"" style=""color: #007bff; text-decoration: none;"">Reset Your Password</a></p>
                            <p>If you did not request a password reset, please ignore this email or contact our support team immediately.</p>
                            <p>If you have any questions or need assistance, feel free to reach out to us at <a href=""mailto:support@yourcompany.com"">support@yourcompany.com</a>.</p>
                            <p>Best regards,</p>
                            <p><strong>Administrator</strong><br><your company name></p>
                        </body>
                        </html>",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new EmailTemplate
                {
                    Id = new Guid("{4D47E853-2EFF-5CF1-940E-A398F01D83E1}"),
                    TemplateName = Domain.Entity.Enum.EmailTemplateType.PasswordChanged,
                    Subject = "Your Password Has Been Changed - <your company name>",
                    Body = @"<!DOCTYPE html>
                        <html>
                        <head>
                            <title>Password Changed</title>
                        </head>
                        <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                            <p>Dear User,</p>
                            <p>We wanted to let you know that your password was successfully changed. If you made this change, no further action is needed.</p>
                            <p>If you did not make this change, please contact our support team immediately to secure your account:</p>
                            <p><a href=""mailto:support@yourcompany.com"">support@yourcompany.com</a></p>
                            <p>For your security, we recommend choosing a strong password that you don't use for any other accounts.</p>
                            <p>Best regards,</p>
                            <p><strong>Administrator</strong><br><your company name></p>
                        </body>
                        </html>",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                }
                );
        }
    }
}
