using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appCRUD.EF;
using appCRUD.EF.Entities;

namespace appCRUD
{
    public class UserOperationsEF
    {
        private readonly EfDbContext _db;
        public UserOperationsEF(EfDbContext db)
        {
            _db = db;
        }

        public void UserCreate(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }
        public IEnumerable<User> GetUsers()
        {
           return _db.Users.ToList();
        }
        public void UserUpdate(int id, string firstName, string LastName)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.ID == id);
                user.FirstName = firstName;
                user.LastName = LastName;
                _db.Update(user);
                _db.SaveChanges();
            }
            catch
            {

            }
        }

        public void UserDelete(int id)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.ID == id);
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            catch
            {          
            }
        }
    }
}
