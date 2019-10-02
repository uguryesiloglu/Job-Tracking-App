using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    class Mesaj
    {
        public string DonusMesaji { get; set; }
        public bool IslemDurumu { get; set; }

        public User user = new User();

    }
}
