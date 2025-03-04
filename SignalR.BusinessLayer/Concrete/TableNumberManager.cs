using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class TableNumberManager : ITableNumberService
	{
		private readonly ITableNumberDal _tableNumberDal;

		public TableNumberManager(ITableNumberDal tableNumberDal)
		{
			_tableNumberDal = tableNumberDal;
		}

		public void TAdd(TableNumber entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(TableNumber entity)
		{
			throw new NotImplementedException();
		}

		public TableNumber TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<TableNumber> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public int TTableNumberCount()
		{
			return _tableNumberDal.TableNumberCount();
		}

		public void TUpdate(TableNumber entity)
		{
			throw new NotImplementedException();
		}
	}
}
	
