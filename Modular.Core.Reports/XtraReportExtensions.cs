using DevExpress.XtraReports.UI;

namespace Modular.Core.Reports
{
    internal static class XtraReportExtensions
    {

        public static byte[] ConvertToBytes(this XtraReport rpt)
        {
            byte[] fileContent;

            using (var stream = new MemoryStream())
            {
                rpt.ExportToPdf(stream);
                fileContent = stream.ToArray();
            }

            return fileContent;
        }

        public async static Task<byte[]> ConvertToBytesAsync(this XtraReport rpt)
        {
            byte[] fileContent;

            using (var stream = new MemoryStream())
            {
                await rpt.ExportToPdfAsync(stream);
                fileContent = stream.ToArray();
            }

            return fileContent;
        }


    }
}
