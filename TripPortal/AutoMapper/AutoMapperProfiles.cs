using TripPortal.Models;
using TripPortal.Models.Entities;
using AutoMapper;
using TripPortal.Models.ViewModel;

namespace TripPortal.AutoMapper

{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddTripViewModel, Trip>()
                .ForMember(dest => dest.TripID, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToUniversalTime()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToUniversalTime()))
               .ReverseMap();

            CreateMap<Student, AddStudentViewModel>()
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                  .ForMember(dest => dest.PESEL, opt => opt.MapFrom(src => src.PESEL))
                  .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ReverseMap();

            CreateMap<Reservation, AddReservationViewModel>()
              .ForMember(dest => dest.TripID, opt => opt.MapFrom(src => src.TripID))
              .ForMember(dest => dest.SelectedStudentID, opt => opt.MapFrom(src => src.StudentID))
              .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.ReservationDate))
              .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
              .ForMember(dest => dest.PriceForAll, opt => opt.MapFrom(src => src.PriceForAll))
            .ReverseMap();

            CreateMap<AddReservationViewModel, AddReservationViewModel>()
              .ForMember(dest => dest.Trip, opt => opt.Ignore())
              .ForMember(dest => dest.Trips, opt => opt.Ignore())
              .ForMember(dest => dest.Students, opt => opt.Ignore());
        }
    }
}
