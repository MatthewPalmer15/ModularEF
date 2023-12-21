#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface IInvoice : IBaseEntity<Guid>
    {

        public enum InvoiceType
        {
            Unknown = 0,
            Invoice = 1,
            Receipt = 2,
            Quote = 3
        }

        public InvoiceType Type { get; set; }   
        
        public int InvoiceNumber { get; set; }

        public List<IInvoiceItem> Items { get; set; }

        public List<IInvoicePayment> Payments { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public DateOnly DueDate { get; set; }

        public decimal SubTotal { get; }

        public decimal DiscountTotal => Items.Sum(x => x.Discount);

        public decimal VATTotal => Items.Sum(x => x.TotalVAT);

        public decimal Total => SubTotal + VATTotal - DiscountTotal;

    }
}
