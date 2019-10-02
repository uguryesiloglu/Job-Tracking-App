using JobTrackingProgram.DAL;
using JobTrackingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    static class BllEmployeeTask
    {
        public static List<EmployeeTaskModel> GetEmployeeTasks()
        {
            return HelperEmployeeTask.GetEmployeeTaskModels(); 
        }
    }
}
