using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TableNumberDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableNumberController : ControllerBase
    {
        private readonly ITableNumberService _tableNumberService;
        private readonly IMapper _mapper;

        public TableNumberController(ITableNumberService tableNumberService, IMapper mapper)
        {
            _tableNumberService = tableNumberService;
            _mapper = mapper;
        }

        [HttpGet("TableNumberCount")]
        public IActionResult TableNumberCount()
        {
            return Ok(_tableNumberService.TTableNumberCount());
        }

        [HttpGet]
        public IActionResult TableNumberList()
        {
            var values = _tableNumberService.TGetListAll();
            var dto = _mapper.Map<List<ResultTableNumberDto>>(values);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateTableNumber(CreateTableNumberDto createTableNumberDto)
        {
            var tableNumber = _mapper.Map<TableNumber>(createTableNumberDto);
            tableNumber.Status = false;
            _tableNumberService.TAdd(tableNumber);
            return Ok("Masa Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTableNumber(int id)
        {
            var value = _tableNumberService.TGetById(id);
            _tableNumberService.TDelete(value);
            return Ok("Masa silindi");
        }

        [HttpPut]
        public IActionResult UpdateTableNumber(UpdateTableNumberDto updateTableNumberDto)
        {
            var tableNumber = _mapper.Map<TableNumber>(updateTableNumberDto);
            tableNumber.Status = false;
            _tableNumberService.TUpdate(tableNumber);
            return Ok("Masa bilgisi güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTableNumber(int id)
        {
            var value = _tableNumberService.TGetById(id);
            var dto = _mapper.Map<ResultTableNumberDto>(value);
            return Ok(dto);
        }

        [HttpGet("ChangeTableNumberStatusToFalse")]
        public IActionResult ChangeTableNumberStatusToFalse(int id)
        {
            var table = _tableNumberService.TGetById(id);
            if (table == null)
            {
                return NotFound("Masa bulunamadı");
            }

            table.Status = false;
            _tableNumberService.TUpdate(table);
            return Ok("Masa durumu pasif yapıldı");
        }

        [HttpGet("ChangeTableNumberStatusToTrue")]
        public IActionResult ChangeTableNumberStatusToTrue(int id)
        {
            var table = _tableNumberService.TGetById(id);
            if (table == null)
            {
                return NotFound("Masa bulunamadı");
            }

            table.Status = true;
            _tableNumberService.TUpdate(table);
            return Ok("Masa durumu aktif yapıldı");
        }

    }
}
