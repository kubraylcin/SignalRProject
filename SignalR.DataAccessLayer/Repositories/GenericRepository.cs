using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
	// Repository Design Pattern kullanacağız.  
	// Bu sayede CRUD işlemlerini tekrar etmekten kaçınacak  
	// ve işlemleri generic bir yapı üzerinde tutabileceğiz.
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly SignalRContext _context;
		// Yapıcı metot (Constructor) ile Dependency Injection uyguluyoruz.  
		// Dependency Injection, bağımlılıkları azaltarak kodun daha esnek olmasını sağlar.  
		// Bu proje Entity Framework ile geliştirildi, ancak ileride Dapper gibi farklı ORM araçlarına  
		// geçiş yapmak gerekirse, SOLID prensiplerine uygun olduğu için bu geçiş daha kolay olacaktır.
		public GenericRepository(SignalRContext context)
		{
			_context = context;
		}
		public void Add(T entity)
		{
			_context.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			_context.Remove(entity);
			_context.SaveChanges();
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetListAll()
		{
			return _context.Set<T>().ToList();
		}

		public void Update(T entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
	}
}
