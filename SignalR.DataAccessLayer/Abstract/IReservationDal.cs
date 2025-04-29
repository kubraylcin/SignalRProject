using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IReservationDal : IGenericDal<Reservation>
	{
		void ReservationStatusApproved(int id);
		void ReservationStatusCancelled(int id);
	}
}
