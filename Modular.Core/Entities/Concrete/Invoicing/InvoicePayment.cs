#nullable disable

using Modular.Core.Entities.Abstract;
using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Concrete
{
    public class InvoicePayment : BaseEntity<Guid>, IInvoicePayment, IAuditable
    {

        public Guid InvoiceId { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }

    }
}
