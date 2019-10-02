using JobTrackingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperEmployee
    {
        public static Employee GetEmployee(int userID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Employee.Where(x => x.UserID == userID).FirstOrDefault();
            }
        }
        public static List<Employee> GetEmployees()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Employee.ToList();
            }
        }
        public static EmployeeModel GetEmployeeModel(int userID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var employee = pw.Employee.Where(x => x.UserID == userID).FirstOrDefault();
                return ConvertEmployeeModel(employee);
            }
        }
        static EmployeeModel ConvertEmployeeModel(Employee employee)
        {
            EmployeeModel em = new EmployeeModel();

            em.Name = employee.Name;
            em.Surname = employee.Surname;
            em.EmployeeID = employee.EmployeeID;
            em.Role = employee.Role;
            em.User.UserID = employee.User.UserID;
            em.User.Username = employee.User.Username;
            em.User.Email = employee.User.Email;

            return em;

        }
        public static List<EmployeeModel> GetEmployeeModels()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var empModelList = pw.Employee.ToList();
                return ConvertEmpModels(empModelList);
            }
        }

        static List<EmployeeModel> ConvertEmpModels(List<Employee> employees)
        {
            List<EmployeeModel> emList = new List<EmployeeModel>();
            foreach (var emp in employees)
            {
                EmployeeModel em = new EmployeeModel();
                em.Name = emp.Name;
                em.Surname = emp.Surname;
                em.EmployeeID = emp.EmployeeID;
                em.Role = emp.Role;
                em.User.UserID = emp.User.UserID;
                em.User.Username = emp.User.Username;
                em.User.Email = emp.User.Email;
                em.User.Password = emp.User.Password;

                emList.Add(em);
            }
            return emList;
        }
        public static bool AddEmployee(Employee employee)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(employee).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteEmployee(Employee employee)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool UpdateEmployee(Employee employee)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public static int GetEmployeeCount()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Employee.Count();
            }
        }


    }

}
