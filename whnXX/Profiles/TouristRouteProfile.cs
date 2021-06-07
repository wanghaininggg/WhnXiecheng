using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using whnXX.Dtos;
using whnXX.Moldes;

namespace whnXX.Profiles
{
    public class TouristRouteProfile: Profile
    {
        public TouristRouteProfile()
        {
            CreateMap<TouristRoute, TouristRouteDto>().ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1))
                )
                .ForMember(
                dest => dest.TravelDays,
                opt => opt.MapFrom(src => src.TravelDays.ToString())
                ).
                 ForMember(
                dest => dest.TripType,
                opt => opt.MapFrom(src => src.TravelDays.ToString())
                ).
                 ForMember(
                dest => dest.DepartureCity,
                opt => opt.MapFrom(src => src.TravelDays.ToString())
                );

            CreateMap<TouristRouteForCreationDto, TouristRoute>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
                );
            
                
        }
    }
}
