using JobTrackingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperTask
    {
        public static List<TaskModel> GetTaskModels()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var taskList = pw.Task.ToList();
                return ConvertTaskModels(taskList);
            }
        }
        public static List<TaskModel> GetTaskModels(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var taskList = pw.Task.Where(x => x.TaskID == taskID).ToList();
                return ConvertTaskModels(taskList);
            }
        }
        public static List<TaskModel> GetTaskModels(params int[] taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var taskList = new List<TaskModel>();
                foreach (var id in taskID)
                {
                    var task = pw.Task.Where(x => x.TaskID == id).ToList();
                    taskList.AddRange(ConvertTaskModels(task));
                }
                
                return taskList;
            }
        }
        static List<TaskModel> ConvertTaskModels(List<Task> taskList)
        {
            var taskModelList = new List<TaskModel>();

            foreach (var task in taskList)
            {
                TaskModel taskModel = new TaskModel();

                taskModel.TaskID = task.TaskID;
                taskModel.TaskName = task.TaskName;
                taskModel.Priority = task.Priority;
                taskModel.StartDate = task.StartDate;
                taskModel.EndDate = task.EndDate;
                taskModel.IsActive = task.IsActive;
                taskModel.taskDescList = task.TaskDescription.ToList();

                foreach (var item in task.TaskDescription.ToList().Where(x => x.TaskID == taskModel.TaskID))
                {
                    taskModel.taskDescList.Add(item);
                }

                taskModel.Project.ProjectName = task.Project.ProjectName;
                taskModel.Project.ProjectID = task.Project.ProjectID;
                taskModel.Project.Priority = task.Project.Priority;
                taskModel.Project.ProjectDescription = task.Project.ProjectDescription;
                taskModel.Project.StartDate = task.Project.StartDate;
                taskModel.Project.EndDate = task.Project.EndDate;
                taskModel.Project.Budget = task.Project.Budget;

                taskModelList.Add(taskModel);
            }
            return taskModelList;
        }
        public static Task GetTask(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Task.Where(x => x.TaskID == taskID).FirstOrDefault();
            }
        }
        public static TaskModel GetTaskModel(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var task = pw.Task.Where(x => x.TaskID == taskID).FirstOrDefault();
                return ConvertTaskModel(task);
            }
        }
        public static List<Task> GetTasks()
        {
            using (PersonelWorkLoadEntities pw= new PersonelWorkLoadEntities())
            {
                return pw.Task.ToList();
            }
        }
        public static List<Task> GetTasks(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Task.Where(x => x.ProjectID == projectID).ToList();
            }
        }
        public static List<Task> GetUnassignedTasks(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Task.Where(x => x.IsActive == 0 && x.ProjectID==projectID).ToList();
            }
        }
        static TaskModel ConvertTaskModel(Task task)
        {
            TaskModel taskModel = new TaskModel();

            taskModel.TaskID = task.TaskID;
            taskModel.TaskName = task.TaskName;
            taskModel.Priority = task.Priority;
            taskModel.StartDate = task.StartDate;
            taskModel.EndDate = task.EndDate;
            taskModel.IsActive = task.IsActive;

            foreach (var item in task.TaskDescription.ToList().Where(x=>x.TaskID==taskModel.TaskID))
            {
                taskModel.taskDescList.Add(item);
            }

            taskModel.Project.ProjectName = task.Project.ProjectName;
            taskModel.Project.ProjectID = task.Project.ProjectID;
            taskModel.Project.Priority = task.Project.Priority;
            taskModel.Project.ProjectDescription = task.Project.ProjectDescription;
            taskModel.Project.StartDate = task.Project.StartDate;
            taskModel.Project.EndDate = task.Project.EndDate;
            taskModel.Project.Budget = task.Project.Budget;

            return taskModel;
        }
        public static List<TaskModel> GetActiveTaskModels()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var taskList = pw.Task.Where(x => x.IsActive == 1).ToList();
                return ConvertTaskModels(taskList);
            }
        }
        public static int GetActTaskCount() 
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Task.Where(x => x.IsActive == 1).Count();
            }
        }
        public static int GetTaskCount()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Task.Count();
            }
        }
        public static bool AddTask(Task task)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(task).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;

            }
        }
        public static bool DeleteTask(Task task)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(task).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;

            }
        }
        public static bool DeleteTask(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var task = pw.Task.Where(x => x.TaskID == taskID).FirstOrDefault();

                pw.Entry(task).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;

            }
        }
        public static bool DeleteTasks(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.Task.Where(x => x.ProjectID == projectID).ToList();

                foreach (var item in list)
                {
                    pw.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }

                if (pw.SaveChanges() > 0)
                    return true;
                return false;

            }
        }
        public static bool UpdateTask(Task task)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(task).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;

            }
        }
        
        public enum IssueType
        {
            NotStarted,InProgress,Done,Cancelled
        }

    }
}
