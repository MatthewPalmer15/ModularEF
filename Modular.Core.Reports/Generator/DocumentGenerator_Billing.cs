﻿using DevExpress.XtraReports.UI;
using Modular.Core.Reports.Reports;
using Modular.Core.Entities;

namespace Modular.Core.Reports
{
    public static partial class DocumentGenerator
    {

        public static class Billing
        {

            public static XtraReport GenerateReceipt(Invoice invoice)
            {
                XtraReport rpt = new ReceiptPrintout();
                rpt.DataSource = invoice;
                rpt.CreateDocument();
                return rpt;
            }

            public async static Task<XtraReport> GenerateReceiptAsync(Invoice invoice)
            {
                XtraReport rpt = new ReceiptPrintout
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
