using AutoMapper;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.MapperProfile
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<MenuItem, MenuItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MenuItemId))
                .ForMember(dest => dest.GuidId, opt => opt.MapFrom(src => src.GuidId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(src => src.InverseParentMenuItem.ToList()))
                .ReverseMap();
            
            CreateMap<Form, FormDTO>().ReverseMap();
            
            CreateMap<Input, InputDTO>().ReverseMap();
            
            CreateMap<DocumentType, GenericDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
            
            CreateMap<Gender, GenericDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
            
            CreateMap<Country, GenericDTO>().ReverseMap();
            
            CreateMap<State, GenericDTO>() .ReverseMap();
            
            CreateMap<City, GenericDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();

            CreateMap<Administrator, GenericDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
