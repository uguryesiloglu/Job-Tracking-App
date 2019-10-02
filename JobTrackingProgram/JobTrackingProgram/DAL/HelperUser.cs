using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperUser
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

        static public bool AddUser(User user)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(user).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        static public bool DeleteUser(User user)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        static public bool DeleteUser(int userID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var silinecek = pw.User.Where(x => x.UserID == userID).FirstOrDefault();
                pw.User.Remove(silinecek);
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        static public bool UpdateUser(User user)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(user).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        static public bool UpdateUser(int userID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var user = pw.User.Where(x => x.UserID == userID).FirstOrDefault();
                pw.Entry(user).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }


    }
}
