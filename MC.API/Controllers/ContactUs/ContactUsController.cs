using MC.Application.Contracts.Email;
using MC.Application.Model.Email;
using MC.Application.ModelDto.ContactUs;
using MC.Application.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MC.API.Controllers.ContactUs
{
    [Route("api/contact-us")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly EmailSettings _emailSettings;
        public ContactUsController(IOptions<EmailSettings> emailSettings, IEmailSenderRepository emailSenderRepository)
        {
            _emailSettings = emailSettings.Value;
            _emailSenderRepository = emailSenderRepository;
        }

        [AllowAnonymous] // no login required
        [HttpPost]
        public async Task<IActionResult> ContactUs([FromBody] ContactUsRequest request, CancellationToken cancellationToken)
        {
            // Build email body from request
            var body = $@"
                    <h3>New Contact Us Message</h3>
                    <p><strong>Name:</strong> {request.FirstName} {request.LastName}</p>
                    <p><strong>Email:</strong> {request.Email}</p>
                    <p><strong>Mobile:</strong> {request.Mobile}</p>
                    <p><strong>Message:</strong><br/>{request.Message}</p>";

            var emailMessage = new EmailMessage
            {
                To = _emailSettings.ToAddress,
                Subject = "Contact Us Form Submission - Home page",
                Body = body,
            };

            var result = await _emailSenderRepository.SendEmail(emailMessage, cancellationToken);

            if (!result)
            {
                return StatusCode(500, "Unable to send email at this time.");
            }

            return Ok(new { success = true, message = "Thank you for contacting us." });
        }

    }
}
