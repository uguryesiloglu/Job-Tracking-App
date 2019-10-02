using JobTrackingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperEmployeeTask
    {
        public static bool AddEmployeeTask(EmployeeTask employeeTask)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(employeeTask).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteEmployeeTask(EmployeeTask employeeTask)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(employeeTask).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteEmployeeTask(int employeeTaskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var employeeTask = pw.EmployeeTask.Where(x => x.EmployeeTaskID == employeeTaskID).FirstOrDefault();

                employeeTask.Task.IsActive = 0;

                pw.Entry(employeeTask).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteEmpTaskByTaskID(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var employeeTask = pw.EmployeeTask.Where(x => x.TaskID == taskID).FirstOrDefault();

                employeeTask.Task.IsActive = 0;

                pw.Entry(employeeTask).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteEmpTasksByEmpID(int employeeID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.EmployeeTask.Where(x => x.EmployeeID == employeeID).ToList();

                foreach (var item in list)
                {
                    item.Task.IsActive = 0;
                    pw.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }

                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteEmpTaskByPrjID(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.EmployeeTask.Where(x => x.Task.ProjectID == projectID).ToList();

                foreach (var item in list)
                {
                    pw.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool UpdateEmployeeTask(EmployeeTask employeeTask)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(employeeTask).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public static List<EmployeeTask> GetEmployeeTasks()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.EmployeeTask.ToList();
            }
        }
        public static int GetEmployeeTaskCount()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.EmployeeTask.ToList().Count();
            }
        }
        public static int GetEmployeeTaskCount(int kisiID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.EmployeeTask.Where(x => x.EmployeeID == kisiID).ToList().Count();
            }
        }
        public static List<EmployeeTaskModel> GetEmployeeTaskModels()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.EmployeeTask.ToList();
                return ConvertEmpTaskModels(list);
            }
        }
        public static List<EmployeeTaskModel> GetEmpTaskModelsByPrjID(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.EmployeeTask.Where(x => x.Task.ProjectID == projectID).ToList();
                return ConvertEmpTaskModels(list);
            }
        }
        
        public static List<EmployeeTaskModel> GetEmployeesTasks(int kisiID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.EmployeeTask.Where(x => x.EmployeeID == kisiID).ToList();
                return ConvertEmpTaskModels(list);
            }
        }
        public static List<EmployeeTaskModel> ConvertEmpTaskModels(List<EmployeeTask> employeeTasks)
        {
            List<EmployeeTaskModel> employeeTaskModelList = new List<EmployeeTaskModel>();

            foreach (var et in employeeTasks)
            {
                EmployeeTaskModel empTaskModel = new EmployeeTaskModel();

                empTaskModel.Employee = et.Employee;
                empTaskModel.Task = et.Task;
                empTaskModel.TaskID = et.TaskID;
                empTaskModel.Task.TaskID = et.Task.TaskID;
                empTaskModel.Task.TaskName = et.Task.TaskName;
                empTaskModel.Task.Project = et.Task.Project;
                empTaskModel.Task.Project.ProjectName = et.Task.Project.ProjectName;
                empTaskModel.EmployeeTaskID = et.EmployeeTaskID;
                empTaskModel.CreatorID = et.CreatorID;
                empTaskModel.Creator = et.Creator;
                empTaskModel.IssueType = et.IssueType;

                employeeTaskModelList.Add(empTaskModel);
            }
            return employeeTaskModelList;
        }
        public static bool UpdateTask(int taskID, string issueType)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var empTask = pw.EmployeeTask.Where(x => x.EmployeeTaskID == taskID).FirstOrDefault();
                empTask.IssueType = issueType;

                pw.Entry(empTask).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}
