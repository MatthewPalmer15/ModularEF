#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface IInvoiceItem : IBaseEntity<Guid>
    {

        public Guid InvoiceId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Quantity { get; set; }

        public decimal Net { get; set; }

        public decimal VAT { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; }

        public decimal TotalNet { get; }

        public decimal TotalVAT { get; }

        public decimal TotalPrice { get; }

    }
}
