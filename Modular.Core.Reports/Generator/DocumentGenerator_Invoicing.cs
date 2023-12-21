using DevExpress.XtraReports.UI;
using Modular.Core.Entities;

namespace Modular.Core.Reporting
{
    public static partial class DocumentGenerator
    {

        public static class Invoicing
        {

            public static XtraReport GenerateInvoice(Invoice invoice)
            {
                XtraReport rpt = new InvoicePrintout();
                rpt.DataSource = invoice;
                rpt.CreateDocument();
                return rpt;
            }

            public async static Task<XtraReport> GenerateInvoiceAsync(Invoice invoice)
            {
                XtraReport rpt = new InvoicePrintout();
                rpt.DataSource = new Invoice[] { invoice };
                await rpt.CreateDocumentAsync();
                return rpt;
            }

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


        }

    }
}
