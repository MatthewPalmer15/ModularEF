using AutoMapper;
using Modular.Core.Models.Location;
using Modular.Core.ViewModels.Country;

namespace Modular.Core.Profiles.Location
{
    public class CountryProfile : Profile
    {

        public CountryProfile() 
        {

            CreateMap<Country, CountryEditModel>();
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryEditModel, Country>();
            CreateMap<CountryViewModel, Country>();

        }

    }
}
