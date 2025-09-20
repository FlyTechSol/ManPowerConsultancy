namespace MC.Application.ModelDto.Registration
{
    public class FileResponseDto
    {
        public byte[] FileBytes { get; set; } = Array.Empty<byte>();
        public string ContentType { get; set; } = "application/octet-stream";
        public string FileName { get; set; } = string.Empty;
    }
}
