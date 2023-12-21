using DevExpress.XtraReports.UI;
using Modular.Core.Entities.Concrete;

namespace Modular.Core.Reporting
{
    public static partial class DocumentGenerator
    {

        public static class Billing
        {

            public static XtraReport GenerateReceipt(Invoice invoice)
            {
                XtraReport rpt = new ReceiptPrintout()
                {
                    DataSource = new Invoice[] { invoice }
                };
                rpt.CreateDocument();
                return rpt;
            }

            public async static Task<XtraReport> GenerateReceiptAsync(Invoice invoice)
            {
                XtraReport rpt = new ReceiptPrintout()
                {
                    DataSource = new Invoice[] { invoice }
                };
                await rpt.CreateDocumentAsync();
                return rpt;
            }

            public static byte[] DownloadReceipt(Invoice invoice)
            {
                XtraReport rpt = GenerateReceipt(invoice);
                return rpt.ConvertToBytes();
            }


        }

    }
}
