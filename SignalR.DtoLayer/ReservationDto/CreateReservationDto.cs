using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.ReservationDto
{
	public class CreateReservationDto
	{
			public string Name { get; set; }
			public string Description { get; set; }
			public string Phone { get; set; }
			public string Email { get; set; }
			public int PersonCount { get; set; }
			public DateTime Date { get; set; }
		}
}
