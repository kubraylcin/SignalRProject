using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.TableNumberDto
{
	public class UpdateTableNumberDto
	{
		public int TableNumberId { get; set; }
		public string TableName { get; set; }
		public bool Status { get; set; }
	}
}
