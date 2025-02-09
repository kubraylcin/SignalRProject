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
	// Bu sınıf, Interface ve GenericRepository ile haberleşerek 
	//Bu yapı sayesinde, About ile ilgili tüm veritabanı işlemlerini tek bir noktadan yönetebiliriz.
	public class EfAboutDal : GenericRepository<About>, IAboutDal //abouta özel enetity eklenince ıabout dal devreye girer
	{
		// Context sınıfında bir GenericRepository için constructor tanımladın.  
		// Burada miras aldığın için, bu sınıfta da bir constructor tanımlayıp  
		// context'i base sınıfa göndermen gerekiyor.
		public EfAboutDal(SignalRContext context) : base(context)
		{
		}
	}
}
