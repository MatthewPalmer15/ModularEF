using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Misc;

namespace Modular.Core.Services.Factories.Misc
{
    public static class OccupationFactory
    {

        public static Occupation Construct()
        {
            return new Occupation();
        }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
