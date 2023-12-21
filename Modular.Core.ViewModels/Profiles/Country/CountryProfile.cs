using AutoMapper;
using Modular.Core.Entities.Concrete;
using Modular.Core.ViewModels.Country;

namespace Modular.Core.Profiles
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
