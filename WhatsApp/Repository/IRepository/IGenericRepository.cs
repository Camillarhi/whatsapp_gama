using System.Linq.Expressions;

namespace WhatsApp.Services.IServices
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null, List<string>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
        Task<T> Get(Expression<Func<T, bool>>? expression = null, List<string>? includes = null);
        Task Add(T entity);
        Task Delete(int id);
        void Update(T entity);
    }
}
