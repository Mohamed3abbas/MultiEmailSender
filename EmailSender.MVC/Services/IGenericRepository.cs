using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace EmailSender.MVC.Services
{
    public interface IGenericRepository<T> where T : class
    {
        public Task Add(T entity);
        public IQueryable<SelectListItem> GetAllAsync();
        Task<IReadOnlyList<T>> GetAll();
        Task<T> FindOne(Expression<Func<T, bool>> predicate);



    }
}
