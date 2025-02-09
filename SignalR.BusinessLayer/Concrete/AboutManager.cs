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
	//Veritabanı işlemlerini doğrudan UI veya Controller’dan çağırmak yerine, bu sınıf kullanılır.
	public class AboutManager : IAboutService
	{
		//Dependency Injection (Bağımlılık Enjeksiyonu) Kullanımı
		private readonly IAboutDal _aboutDal;
		//dependicyInstruction kısmı galiba
		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void TAdd(About entity)
		{
			_aboutDal.Add(entity);

		}

		public void TDelete(About entity)
		{
			_aboutDal.Delete(entity);
		}

		public About TGetById(int id)
		{
			return _aboutDal.GetById(id);
		}

		public List<About> TGetListAll()
		{
			return _aboutDal.GetListAll();
		}

		public void TUpdate(About entity)
		{
			_aboutDal.Update(entity);
		}
	}
}
