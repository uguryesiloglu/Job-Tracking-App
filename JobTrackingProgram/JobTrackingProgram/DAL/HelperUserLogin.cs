using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperUserLogin
    {
        static public List<User> GetUsers()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
              return pw.User.ToList();
            }
        }

        static public User GetUser(string username)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.User.Where(x => x.Username == username).FirstOrDefault();
            }
        }

        static public bool AddUser(User newUser)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(newUser).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        static public bool RemoveUser(User user)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}
