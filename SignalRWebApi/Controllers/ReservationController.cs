using AutoMapper;
using Microsoft.AspNetCore.Http;
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
		private readonly IMapper _mapper;

		public ReservationController(IReservationService reservationService, IMapper mapper)
		{
			_reservationService = reservationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ReservationList()
		{
			var reservationList = _reservationService.TGetListAll();
			var result = _mapper.Map<List<ResultReservationDto>>(reservationList);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateReservation(CreateReservationDto createReservationDto)
		{
			var reservation = _mapper.Map<Reservation>(createReservationDto);
			_reservationService.TAdd(reservation);
			return CreatedAtAction(nameof(GetReservation), new { id = reservation.ReservationId }, "Rezervasyon başarıyla eklendi");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateReservation(int id, UpdateReservationDto updateReservationDto)
		{
			var reservation = _reservationService.TGetById(id);
			if (reservation == null)
			{
				return NotFound("Güncellenecek rezervasyon bulunamadı");
			}

			_mapper.Map(updateReservationDto, reservation);
			_reservationService.TUpdate(reservation);
			return Ok("Rezervasyon başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteReservation(int id)
		{
			var reservation = _reservationService.TGetById(id);
			if (reservation == null)
			{
				return NotFound("Rezervasyon bulunamadı");
			}
			_reservationService.TDelete(reservation);
			return Ok("Rezervasyon başarıyla silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetReservation(int id)
		{
			var reservation = _reservationService.TGetById(id);
			if (reservation == null)
			{
				return NotFound("Rezervasyon bulunamadı");
			}
			var result = _mapper.Map<ResultReservationDto>(reservation);
			return Ok(result);
		}
	}
}
