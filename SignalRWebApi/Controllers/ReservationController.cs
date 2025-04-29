using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ReservationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{

		private readonly IReservationService _reservationService;

		public ReservationController(IReservationService reservationService)
		{
			_reservationService = reservationService;
		}

		[HttpGet]
		public IActionResult ReservationList()
		{
			var values = _reservationService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateReservation(CreateReservationDto createReservationDto)
		{
			Reservation reservation = new Reservation()
			{
				Email = createReservationDto.Email,
				Date = createReservationDto.Date,
				Name = createReservationDto.Name,
				PersonCount = createReservationDto.PersonCount,
				Phone = createReservationDto.Phone,
				Description = createReservationDto.Description,
			};
			_reservationService.TAdd(reservation);
			return Ok("Rezervasyon Yapıldı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteReservation(int id)
		{
			var value = _reservationService.TGetById(id);
			_reservationService.TDelete(value);
			return Ok("Rezervasyon silindi");
		}

		[HttpPut]
		public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
		{
			Reservation reservation = new Reservation()
			{
				Description= updateReservationDto.Description,	
				Email = updateReservationDto.Email,
				ReservationId = updateReservationDto.ReservationId,
				Name = updateReservationDto.Name,
				Phone = updateReservationDto.Phone,
				PersonCount = updateReservationDto.PersonCount,
				Date = updateReservationDto.Date,
			};

			_reservationService.TUpdate(reservation);
			return Ok("Rezervasyon Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetReservation(int id)
		{
			var value = _reservationService.TGetById(id);
			return Ok(value);
		}
		[HttpGet("ReservationStatusApproved/{id}")]
		public IActionResult ReservationStatusApproved(int id)
		{
			_reservationService.TReservationStatusApproved(id);
			return Ok("Rezervasyon Durumu Değiştirildi");
		}
		[HttpGet("ReservationStatusCancelled/{id}")]
		public IActionResult ReservationStatusCancelled(int id)
		{
			_reservationService.TReservationStatusCancelled(id);
			return Ok("Rezervasyon Durumu Değiştirildi");
		}
	}
}

