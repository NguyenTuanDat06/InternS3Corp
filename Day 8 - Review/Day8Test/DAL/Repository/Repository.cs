using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private DbSet<T> entities;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }
        
        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }
        public T Get(long id)
        {
            return entities.Find(id);
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }
}
