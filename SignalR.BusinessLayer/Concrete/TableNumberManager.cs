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
			_tableNumberDal.Add(entity);
		}

        public void TChangeTableNumberStatusToFalse(int id)
        {
            _tableNumberDal.ChangeTableNumberStatusToFalse(id);
        }

        public void TChangeTableNumberStatusToTrue(int id)
        {
            _tableNumberDal.ChangeTableNumberStatusToTrue(id);
        }

        public void TDelete(TableNumber entity)
		{
			_tableNumberDal.Delete(entity);
		}

		public TableNumber TGetById(int id)
		{
			return _tableNumberDal.GetById(id);
		}

		public List<TableNumber> TGetListAll()
		{
			return _tableNumberDal.GetListAll();
		}

		public int TTableNumberCount()
		{
			return _tableNumberDal.TableNumberCount();
		}

		public void TUpdate(TableNumber entity)
		{
			_tableNumberDal.Update(entity);
		}
	}
}
	
