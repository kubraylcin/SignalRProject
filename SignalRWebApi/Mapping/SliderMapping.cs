using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;
namespace SignalRWebApi.Mapping
{
	public class SliderMapping:Profile
	{
		public SliderMapping()
		{   //reversemap: ikisi birbiriyle eşleşebilir
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
		}
	}
}
