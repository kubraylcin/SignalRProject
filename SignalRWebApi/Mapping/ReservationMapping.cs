using AutoMapper;
using SignalR.DtoLayer.ReservationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
	public class ReservationMapping:Profile
	{
        public ReservationMapping()
        {
			CreateMap<Reservation, ResultReservationDto>().ReverseMap();
			CreateMap<Reservation, CreateReservationDto>().ReverseMap();
			CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
			CreateMap<Reservation, GetReservationDto>().ReverseMap();
		}
    }
}
