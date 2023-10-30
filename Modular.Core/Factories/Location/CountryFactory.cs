using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Location;

namespace Modular.Core.Services.Factories.Location
{
    public static class CountryFactory
    {

        public static Country Construct()
        {
            return new Country();
        }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
