using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
	public class AboutMapping : Profile
	{
		/// AutoMapper, nesneler arası veri dönüşümünü kolaylaştıran bir kütüphanedir.
		/// Özellikle DTO (Data Transfer Object) ile entity modelleri arasında veri aktarımını
		/// otomatikleştirerek kod tekrarını azaltır ve manuel eşleştirme işlemlerini ortadan kaldırır.
		 
		public AboutMapping()
		{   //reversemap: ikisi birbiriyle eşleşebilir
			CreateMap<About,ResultAboutDto>().ReverseMap();
			CreateMap<About,CreateAboutDto>().ReverseMap();
			CreateMap<About,UpdateAboutDto>().ReverseMap();
			CreateMap<About,GetAboutDto>().ReverseMap();
			
		}
	}
}
