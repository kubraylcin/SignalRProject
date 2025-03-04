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
	public class EfMoneyCaseManager : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseManager(SignalRContext context) : base(context)
		{
		}

		public decimal TotalMoneyCaseAmount()
		{
			using var context = new SignalRContext();
			return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
		}
	}
}
