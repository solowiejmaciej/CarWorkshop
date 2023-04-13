using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(c => c.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    EmailAddress = src.EmailAddress,
                    PostalCode = src.PostalCode
                }));

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(c => c.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(c => c.EmailAddress, opt => opt.MapFrom(src => src.ContactDetails.EmailAddress))
                .ForMember(c => c.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(c => c.isEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id || user.IsInRole("Moderator")));

            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
        }
    }
}