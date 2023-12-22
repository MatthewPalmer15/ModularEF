#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface IInvoicePayment : IBaseEntity<Guid>
    {

        public Guid InvoiceId { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }

    }
}
