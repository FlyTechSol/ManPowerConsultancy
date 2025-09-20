namespace MC.Application.Contracts.Persistence.Common.Download
{
    public interface ICsvExportService
    {
        byte[] ExportToCsv<T>(IEnumerable<T> data);
    }
}
