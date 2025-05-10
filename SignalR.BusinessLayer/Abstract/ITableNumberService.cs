using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
	public interface ITableNumberService: IGenericService<TableNumber>
	{
		public int TTableNumberCount();
        void TChangeTableNumberStatusToFalse(int id);
        void TChangeTableNumberStatusToTrue(int id);
    }
}
