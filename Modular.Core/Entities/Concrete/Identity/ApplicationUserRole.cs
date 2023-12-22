using Microsoft.AspNetCore.Identity;
using Modular.Core.Interfaces;

namespace Modular.Core.Identity
{
    public class ApplicationUserRole : IdentityUserRole<Guid>, IAuditable
    {
    }
}
