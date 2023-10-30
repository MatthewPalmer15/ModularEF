using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Misc;

namespace Modular.Core.Services.Factories.Misc
{
    public static class DepartmentFactory
    {

        public static Department Construct()
        {
            return new Department();
        }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
