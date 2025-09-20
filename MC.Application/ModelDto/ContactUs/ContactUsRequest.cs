namespace MC.Application.ModelDto.ContactUs
{
    public class ContactUsRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
