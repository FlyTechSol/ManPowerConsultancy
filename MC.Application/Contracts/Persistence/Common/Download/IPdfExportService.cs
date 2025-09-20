namespace MC.Application.Contracts.Persistence.Common.Download
{
    public interface IPdfExportService
    {
        byte[] GeneratePdf<T>(IEnumerable<T> data, string title);
    }
}