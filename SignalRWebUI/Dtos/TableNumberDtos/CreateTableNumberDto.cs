using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.TableNumberDtos

{
	public class CreateTableNumberDto
	{
		public int TableNumberId { get; set; }
		public string TableName { get; set; }
		public bool Status { get; set; }
		
	}
}
