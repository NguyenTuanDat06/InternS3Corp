using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _Context;

        private DbSet<T> _entities;

        public Repository()
        {
            _Context = new DatabaseContext();
            _entities = _Context.Set<T>();
        }
        public Repository(DatabaseContext _context)
        {
            _Context = _context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(object id)
        {
            return _entities.Find(id);
        }

        public void Insert(T obj)
        {
            _entities.Add(obj);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public void Update(T obj)
        {
            _entities.Update(obj);
        }
        public void Delete(object id)
        {
            T entity = _entities.Find(id);
            _entities.Remove(entity);
        }
    }
}
