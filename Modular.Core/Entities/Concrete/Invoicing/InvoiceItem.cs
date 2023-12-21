#nullable disable

namespace Modular.Core.Entities
{
    public class InvoiceItem : BaseEntity<Guid>
    {

        public Guid InvoiceId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Quantity { get; set; }

        public decimal Net { get; set; }

        public decimal VAT { get; set; }

        public decimal Discount { get; set; }

        public decimal Total
        {
            get
            {
                return Net + VAT;
            }
        }

        public decimal TotalNet
        {
            get
            {
                return Net * Quantity;
            }
        }

        public decimal TotalVAT
        {
            get
            {
                return VAT * Quantity;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Net + VAT - Discount;
            }
        }

    }
}
