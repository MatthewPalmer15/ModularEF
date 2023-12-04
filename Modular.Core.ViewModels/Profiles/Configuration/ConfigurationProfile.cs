using AutoMapper;
using Modular.Core.Entities;
using Modular.Core.ViewModels.Configuration;

namespace Modular.Core.Profiles
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile() 
        {
            CreateMap<Configuration, ConfigurationEditModel>();
            CreateMap<Configuration, ConfigurationViewModel>();
            CreateMap<ConfigurationEditModel, Configuration>();
            CreateMap<ConfigurationViewModel, Configuration>();
        }


    }
}
