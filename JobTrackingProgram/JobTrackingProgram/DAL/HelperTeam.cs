using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.DAL
{
    static class HelperTeam
    {
        public static bool CUD(Teams team, EntityState state)
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                pw.Entry(team).State = state;
                if (pw.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public static List<Teams> GetTeams()
        {
            using (PersonelWorkLoadEntities pw = new PersonelWorkLoadEntities())
            {
                return pw.Teams.ToList();
            }
        }
    }
}
