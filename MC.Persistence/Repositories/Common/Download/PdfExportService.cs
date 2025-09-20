using MC.Application.Contracts.Persistence.Common.Download;
using MC.Application.Helper;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace MC.Persistence.Repositories.Common.Download
{
    public class PdfExportService : IPdfExportService
    {
        public byte[] GeneratePdf<T>(IEnumerable<T> data, string title)
        {
            var properties = typeof(T)
                .GetProperties()
                .Where(p => !Attribute.IsDefined(p, typeof(CsvIgnoreAttribute)))
                .Select(p => new
                {
                    Property = p,
                    Order = p.GetCustomAttribute<CsvColumnAttribute>()?.Order ?? int.MaxValue,
                    Header = p.GetCustomAttribute<CsvColumnAttribute>()?.Name ?? p.Name
                })
                .OrderBy(x => x.Order)
                .ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4.Landscape());
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Text(title).SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);

                    page.Content().Table(table =>
                    {
                        // Column count
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var _ in properties)
                                columns.RelativeColumn();
                        });

                        // Headers
                        table.Header(header =>
                        {
                            foreach (var prop in properties)
                            {
                                header.Cell().Element(CellStyle).Text(prop.Header).SemiBold();
                            }
                        });

                        // Data rows
                        foreach (var item in data)
                        {
                            foreach (var prop in properties)
                            {
                                var value = prop.Property.GetValue(item);
                                string text = value switch
                                {
                                    DateTime dt => dt.ToString("dd-MMM-yyyy hh:mm tt"),
                                    _ => value?.ToString() ?? ""
                                };

                                table.Cell().Element(CellStyle).Text(text);
                            }
                        }

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Generated on ");
                        x.Span(DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt")).SemiBold();
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
