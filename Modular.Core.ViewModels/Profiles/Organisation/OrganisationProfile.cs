using AutoMapper;
using Modular.Core.Models.Entity;
using Modular.Core.ViewModels.Organisation;

namespace Modular.Core.Profiles.Entity
{
    public class OrganisationProfile : Profile
    {

        public OrganisationProfile() 
        {

            CreateMap<Organisation, OrganisationEditModel>();
            CreateMap<Organisation, OrganisationViewModel>();
            CreateMap<OrganisationEditModel, Organisation>();
            CreateMap<OrganisationViewModel, Organisation>();

        }

    }
}
