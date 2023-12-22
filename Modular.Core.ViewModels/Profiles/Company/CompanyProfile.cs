using AutoMapper;
using Modular.Core.Entities.Concrete;
using Modular.Core.ViewModels.Company;

namespace Modular.Core.Profiles
{
    public class CompanyProfile : Profile
    {

        public CompanyProfile()
        {

            CreateMap<Company, CompanyEditModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyEditModel, Company>();
            CreateMap<CompanyViewModel, Company>();

        }

    }
}
