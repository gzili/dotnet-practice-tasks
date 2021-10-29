using api.Data;
using api.Models;
using System.Collections.Generic;
using System.Linq;

namespace api.Repositories
{
    public class UsersRepository
    {
        private readonly ApiDbContext _db;

        public UsersRepository(ApiDbContext db) {
            _db = db;
        }

        public void Create(User user) {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public IList<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.Find(id);
        }

        public User GetByNickname(string nickname)
        {
            return _db.Users.FirstOrDefault(u => u.Nickname == nickname);
        }

        public void Delete(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
