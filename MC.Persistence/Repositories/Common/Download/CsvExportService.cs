using MC.Application.Contracts.Persistence.Common.Download;
using MC.Application.Helper;
using System.Reflection;
using System.Text;


namespace MC.Persistence.Repositories.Common.Download
{
    public class CsvExportService : ICsvExportService
    {
        public byte[] ExportToCsv<T>(IEnumerable<T> data)
        {
            if (data == null || !data.Any())
                return Array.Empty<byte>();

            var sb = new StringBuilder();

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !Attribute.IsDefined(p, typeof(CsvIgnoreAttribute)))
                .Select(p => new
                {
                    Property = p,
                    Column = p.GetCustomAttribute<CsvColumnAttribute>(),
                    IsExcelText = Attribute.IsDefined(p, typeof(CsvExcelTextAttribute))
                })
                .OrderBy(p => p.Column?.Order ?? int.MaxValue)
                .ToList();

            // Header row
            sb.AppendLine(string.Join(",", props.Select(p => Escape(p.Column?.Name ?? p.Property.Name))));

            foreach (var item in data)
            {
                var row = props.Select(p =>
                {
                    var value = p.Property.GetValue(item, null)?.ToString() ?? "";

                    // Force Excel to treat as text (e.g., to prevent scientific notation)
                    if (p.IsExcelText && !string.IsNullOrWhiteSpace(value))
                    {
                        value = $"=\"{value}\"";
                    }

                    return Escape(value);
                });

                sb.AppendLine(string.Join(",", row));
            }
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream, new UTF8Encoding(true)); // with BOM
            writer.Write(sb.ToString());
            writer.Flush();

            return memoryStream.ToArray();
        }

        private string Escape(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }

            return value;
        }
    }
}
