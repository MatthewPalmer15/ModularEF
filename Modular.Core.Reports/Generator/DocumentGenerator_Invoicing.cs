using DevExpress.XtraReports.UI;
using Modular.Core.Entities.Concrete;

namespace Modular.Core.Reporting
{
    public static partial class DocumentGenerator
    {

        public static class Invoicing
        {

            /// <summary>
            /// Generates a Invoice XtraReport Document synchronously.
            /// </summary>
            /// <param name="invoice"></param>
            /// <returns></returns>
            public static XtraReport GenerateInvoice(Invoice invoice)
            {
                XtraReport rpt = new InvoicePrintout
                {
                    DataSource = new Invoice[] { invoice }
                };
                rpt.CreateDocument();
                return rpt;
            }

            /// <summary>
            /// Generates a Invoice XtraReport Document asynchronously.
            /// </summary>
            /// <param name="invoice"></param>
            /// <returns></returns>
            public async static Task<XtraReport> GenerateInvoiceAsync(Invoice invoice)
            {
                XtraReport rpt = new InvoicePrintout
                {
                    DataSource = new Invoice[] { invoice }
                };
                await rpt.CreateDocumentAsync();
                return rpt;
            }

            /// <summary>
            /// Downloads a Invoice XtraReport Document synchronously.
            /// </summary>
            /// <param name="invoice"></param>
            /// <returns></returns>
            public static byte[] DownloadInvoice(Invoice invoice)
            {
                byte[] fileContent;

                XtraReport rpt = GenerateInvoice(invoice);
                using (var stream = new MemoryStream())
                {
                    rpt.ExportToPdf(stream);
                    fileContent = stream.ToArray();
                }

                return fileContent;
            }

            /// <summary>
            /// Downloads a Invoice XtraReport Document asynchronously.
            /// </summary>
            /// <param name="invoice"></param>
            /// <returns></returns>
            public async static Task<byte[]> DownloadInvoiceAsync(Invoice invoice)
            {
                byte[] fileContent;

                XtraReport rpt = await GenerateInvoiceAsync(invoice);
                using (var stream = new MemoryStream())
                {
                    await rpt.ExportToPdfAsync(stream);
                    fileContent = stream.ToArray();
                }

                return fileContent;
            }

            /// <summary>
            /// Prints a Invoice XtraReport Document synchronously.
            /// </summary>
            /// <param name="invoice"></param>
            /// <param name="printerName"></param>
            public static void PrintInvoice(Invoice invoice, string? printerName = "")
            {
                XtraReport rpt = GenerateInvoice(invoice);
                rpt.Print(printerName);
            }

            /// <summary>
            /// Prints a Invoice XtraReport Document asynchronously.
            /// </summary>
            /// <param name="invoice"></param>
            /// <param name="printerName"></param>
            public async static Task PrintInvoiceAsync(Invoice invoice, string? printerName = "")
            {
                XtraReport rpt = await GenerateInvoiceAsync(invoice);
                await rpt.PrintAsync(printerName);
            }

        }
    }
}
