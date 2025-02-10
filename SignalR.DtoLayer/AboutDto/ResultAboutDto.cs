using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
	//erişim belirliyeciler public private procted ınternal 
	public class ResultAboutDto
	{
		// DTO'lar, ekleme, güncelleme ve silme işlemlerinde
		// doğrudan entity yerine yalnızca ihtiyacımız olan
		// özellikleri içeren veri transfer nesneleridir.
		// Böylece gereksiz veriler taşınmaz ve güvenlik ile performans açısından avantaj sağlanır.
		public int AboutId { get; set; }
		public string ImageUrl { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

	}
}
