using AutoMapper;
using Modular.Core.ViewModels.Configuration;

namespace Modular.Core.Profiles.Configuration
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile() 
        {
            CreateMap<Models.Config.Configuration, ConfigurationEditModel>();
            CreateMap<Models.Config.Configuration, ConfigurationViewModel>();
            CreateMap<ConfigurationEditModel, Models.Config.Configuration>();
            CreateMap<ConfigurationViewModel, Models.Config.Configuration>();
        }


    }
}
