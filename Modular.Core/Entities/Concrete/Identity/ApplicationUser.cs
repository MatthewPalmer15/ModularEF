using Microsoft.AspNetCore.Identity;
using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

#nullable disable

namespace Modular.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IAuditable
    {

        public Guid ContactId { get; set; }

        public Contact Contact { get; set; }

        public string ApiToken { get; set; }

    }
}
