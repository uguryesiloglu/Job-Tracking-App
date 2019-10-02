using JobTrackingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    class HelperTaskDescription
    {
        public static bool AddTaskDescription(TaskDescription td)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(td).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteTaskDescription(TaskDescription td)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(td).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteTaskDescriptions(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.TaskDescription.Where(x => x.TaskID == taskID).ToList();

                foreach (var item in list)
                {
                    pw.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool DeleteTaskDescByPrjID(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.TaskDescription.Where(x => x.Task.ProjectID == projectID).ToList();

                foreach (var item in list)
                {
                    pw.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }

                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool UpdateTaskDescription(TaskDescription td)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(td).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static int GetTaskDescCount()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.TaskDescription.Count();
            }
        }
        public static List<TaskDescription> GetTaskDescriptions(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.TaskDescription.Where(x => x.Task.TaskID == taskID).ToList();
            }
        }
        public static List<TaskDescriptionModel> GetTaskDescriptions()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.TaskDescription.ToList();
                return ConvertTaskDescModel(list);
            }
        }
        public static List<TaskDescriptionModel> GetTaskDescriptionModels(int taskID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                var list = pw.TaskDescription.Where(x => x.Task.TaskID == taskID).ToList();
                return ConvertTaskDescModel(list);
            }
        }
        public static List<TaskDescriptionModel> ConvertTaskDescModel(List<TaskDescription> taskDescList)
        {
            List<TaskDescriptionModel> list = new List<TaskDescriptionModel>();

            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                foreach (var item in taskDescList)
                {
                    TaskDescriptionModel tdm = new TaskDescriptionModel();

                    tdm.TaskDescriptionID = item.TaskDescriptionID;
                    tdm.TaskDescription1 = item.TaskDescription1;
                    tdm.TaskID = item.TaskID;
                    tdm.Task.TaskName = item.Task.TaskName;
                    tdm.Task = item.Task;

                    list.Add(tdm);
                }
                return list;
            }
        }

    }
}
