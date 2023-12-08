using AutoMapper;
using Modular.Core.Entities;
using Modular.Core.ViewModels.Contact;

namespace Modular.Core.Profiles
{
    public class ContactProfile : Profile
    {

        public ContactProfile()
        {

            CreateMap<Contact, ContactEditModel>()
                .ForMember(src => src.DateOfBirth, dest => dest.MapFrom(x => DateOnly.FromDateTime(x.DateOfBirth)));

            CreateMap<Contact, ContactViewModel>()
                .ForMember(src => src.DateOfBirth, dest => dest.MapFrom(x => DateOnly.FromDateTime(x.DateOfBirth)));

            CreateMap<ContactEditModel, Contact>()
                .ForMember(src => src.DateOfBirth, dest => dest.MapFrom(x => x.DateOfBirth.ToDateTime(new TimeOnly(0))));

            CreateMap<ContactViewModel, Contact>()
                .ForMember(src => src.DateOfBirth, dest => dest.MapFrom(x => x.DateOfBirth.ToDateTime(new TimeOnly(0))));

        }

    }
}
