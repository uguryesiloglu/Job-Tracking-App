using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    static class BllProject
    {
        static public int GetProjectNumber()
        {
            return DAL.HelperProject.GetProjectCount();
        }
    }
}
