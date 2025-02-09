using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class // class olmasının nedeni dışarıdan bir nesne methot gibi durumlar girmiş olamayacak
	{
		//Tüm interfaceler imzalarımızı tutacak
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		T GetById(int id);
		List<T> GetListAll();

	}
}
