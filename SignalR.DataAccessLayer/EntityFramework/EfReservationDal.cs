using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
	{
		public EfReservationDal(SignalRContext context) : base(context)
		{
		}

		public void ReservationStatusApproved(int id)
		{
			using var context= new SignalRContext();
			var values = context.Rezervations.Find(id);
			values.Description = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void ReservationStatusCancelled(int id)
		{
			using var context = new SignalRContext();
			var values = context.Rezervations.Find(id);
			values.Description = "Rezervasyon İptal Edildi";
			context.SaveChanges();
		}
	}
}
