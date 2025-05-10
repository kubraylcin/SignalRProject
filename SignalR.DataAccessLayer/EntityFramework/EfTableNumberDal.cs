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
	public class EfTableNumberDal : GenericRepository<TableNumber>, ITableNumberDal
	{
		public EfTableNumberDal(SignalRContext context) : base(context)
		{
		}

        public void ChangeTableNumberStatusToFalse(int id)
        {
            using var context = new SignalRContext();
			var value = context.TableNumbers.Where(x => x.TableNumberId == id).FirstOrDefault();
			value.Status = false;
			context.SaveChanges();
        }

        public void ChangeTableNumberStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.TableNumbers.Where(x => x.TableNumberId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public int TableNumberCount()
		{
			using var context= new SignalRContext();
			return context.TableNumbers.Count();
		}
	}
}
