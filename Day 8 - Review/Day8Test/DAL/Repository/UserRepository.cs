using DAL.Entities;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public UserRepository(DatabaseContext Context)
        {
            _dbContext = Context;
        }
        public void Delete(User userID)
        {
            throw new NotImplementedException();
        }

        public User Get(long userID)
        {
            return _dbContext.Users.Find(userID);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Insert(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
