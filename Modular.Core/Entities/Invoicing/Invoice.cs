#nullable disable

namespace Modular.Core.Entities
{
    public class Invoice : BaseEntity<Guid>
    {

        public int InvoiceNumber { get; set; }

        public List<InvoiceItem> Items { get; set; }

        public List<InvoicePayment> Payments { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public DateOnly DueDate { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Items.Sum(x => x.TotalNet);
            }
        }

        public decimal DiscountTotal
        {
            get
            {
                return Items.Sum(x => x.Discount);
            }
        }

        public decimal VATTotal
        {
            get
            {
                return Items.Sum(x => x.TotalVAT);
            }
        }

        public decimal Total
        {
            get
            {
                return SubTotal + VATTotal - DiscountTotal;
            }
        }

    }
}
