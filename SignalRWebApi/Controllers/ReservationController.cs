using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ReservationDto;
using SignalR.EntityLayer.Entities;
using FluentValidation;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReservationDto> _validator;

        public ReservationController(IReservationService reservationService, IMapper mapper, IValidator<CreateReservationDto> validator)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _reservationService.TGetListAll();
            var dtoList = _mapper.Map<List<ResultReservationDto>>(values);
            return Ok(dtoList);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
            
            var validationResult =_validator.Validate(createReservationDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var reservation = _mapper.Map<Reservation>(createReservationDto);
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
            var reservation = _mapper.Map<Reservation>(updateReservationDto);
            _reservationService.TUpdate(reservation);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var value = _reservationService.TGetById(id);
            var dto = _mapper.Map<ResultReservationDto>(value);
            return Ok(dto);
        }

        [HttpGet("ReservationStatusApproved/{id}")]
        public IActionResult ReservationStatusApproved(int id)
        {
            _reservationService.TReservationStatusApproved(id);
            return Ok("Rezervasyon Durumu Onaylandı");
        }

        [HttpGet("ReservationStatusCancelled/{id}")]
        public IActionResult ReservationStatusCancelled(int id)
        {
            _reservationService.TReservationStatusCancelled(id);
            return Ok("Rezervasyon Durumu İptal Edildi");
        }
    }
}
