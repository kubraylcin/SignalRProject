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
	public class ReservationManager: IReservationService
	{
		private readonly IReservationDal _reservationDal;

		public ReservationManager(IReservationDal reservationDal)
		{
			_reservationDal = reservationDal;
		}

		public void TAdd(Reservation entity)
		{
			_reservationDal.Add(entity);
		}

		public void TDelete(Reservation entity)
		{
			_reservationDal.Delete(entity);
		}

		public Reservation TGetById(int id)
		{
			return _reservationDal.GetById(id);
		}

		public List<Reservation> TGetListAll()
		{
			return _reservationDal.GetListAll();
		}

		public void TUpdate(Reservation entity)
		{
			_reservationDal.Update(entity);
		}
	}
}
