using EmailSender.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmailSender.MVC.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IQueryable<SelectListItem> GetAllAsync()
        {
            var brands = _context.EmailMessages.Select(i => new SelectListItem(i.Subject, i.ID.ToString())).AsNoTracking();
            return brands;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<IReadOnlyList<T>> GetAll()
           => await _context.Set<T>().ToListAsync();

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
    }
}
