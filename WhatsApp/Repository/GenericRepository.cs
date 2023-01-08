using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WhatsApp.Context;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> db;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            db = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await db.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>>? expression = null, List<string>? includes = null)
        {
            IQueryable<T> query = db;
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null, List<string>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> query = db;

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            db.Update(entity);
        }
    }
}
