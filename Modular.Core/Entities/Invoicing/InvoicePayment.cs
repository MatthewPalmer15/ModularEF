#nullable disable

namespace Modular.Core.Entities
{
    public class InvoicePayment : BaseEntity<Guid>
    {

        public Guid InvoiceId { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }

    }
}
