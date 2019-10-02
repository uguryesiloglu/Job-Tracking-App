using JobTrackingProgram.DAL;
using JobTrackingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    static class BllEmployee
    {
        public static EmployeeModel EmployeeLogin(Mesaj mesaj)
        {
            return HelperEmployee.GetEmployeeModel(mesaj.user.UserID);
        }

        public static int GetEmployeeCount()
        {
            return DAL.HelperEmployee.GetEmployeeCount();
        }
    }
}
