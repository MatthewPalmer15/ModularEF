using Hangfire;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Entities.Abstract;
using Modular.Core.Entities.Concrete;
using Modular.Core.ScheduledTasks.Abstract;

namespace Modular.Core.ScheduledTasks.Concrete
{
    public class ScheduledTaskService : IScheduledTaskService
    {

        private readonly IInvoiceRepository _invoiceRepository;

        public ScheduledTaskService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;

            RecurringJob.AddOrUpdate("convertQuote", () => ConvertQuote(), Cron.Daily());
        }

        public async Task ConvertQuote()
        {
            List<Invoice> invoices = _invoiceRepository.Search(x => x.Type == IInvoice.InvoiceType.Quote && x.Payments.Count > 0);
            foreach (Invoice invoice in invoices)
            {
                invoice.Type = IInvoice.InvoiceType.Invoice;
            }
            await _invoiceRepository.SaveChangesAsync();
        }

    }
}
