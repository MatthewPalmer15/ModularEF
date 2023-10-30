using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Location;

namespace Modular.Core.Services.Factories.Location
{
    public static class ContinentFactory
    {

        public static Continent Construct()
        {
            return new Continent();
        }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
