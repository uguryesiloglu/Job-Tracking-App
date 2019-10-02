using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperProject
    {
        public static List<Project> GetProjects()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Project.ToList();
            }
        }
        public static Project GetProject(int projectID)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Project.Where(x => x.ProjectID == projectID).FirstOrDefault();
            }
        }
        public static bool DeleteProject(Project project)
        {
            using (PersonelWorkLoadEntities pw= new PersonelWorkLoadEntities())
            {
                pw.Entry(project).State = System.Data.Entity.EntityState.Deleted;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool AddProject(Project project)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(project).State = System.Data.Entity.EntityState.Added;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static bool UpdateProject(Project project)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(project).State = System.Data.Entity.EntityState.Modified;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public static int GetProjectCount()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Project.Count();
            }
        }
    }
}
