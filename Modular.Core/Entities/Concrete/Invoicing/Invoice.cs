#nullable disable

using Modular.Core.Entities.Abstract;
using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Concrete
{
    public class Invoice : BaseEntity<Guid>, IInvoice, IAuditable
    {

        public IInvoice.InvoiceType Type { get; set; }

        public int InvoiceNumber { get; set; }

        public List<IInvoiceItem> Items { get; set; }

        public List<IInvoicePayment> Payments { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public DateOnly DueDate { get; set; }

        public decimal SubTotal => Items.Sum(x => x.TotalNet);

        public decimal DiscountTotal => Items.Sum(x => x.Discount);

        public decimal VATTotal => Items.Sum(x => x.TotalVAT);

        public decimal Total => SubTotal + VATTotal - DiscountTotal;

    }
}
