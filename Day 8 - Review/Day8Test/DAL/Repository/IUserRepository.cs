using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long userID);
        void Insert(User user);
        void Update(User user);
        void Delete(User userID);
        void SaveChanges();
    }
}
