using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    static class BLLuserLogin
    {
        public static Mesaj LoginProcess(string username,string password)
        {
            var user = DAL.HelperUserLogin.GetUser(username);

            Mesaj mesaj = new Mesaj();

            if (user!=null)
            {
                if (user.Password==password)
                {
                    mesaj.DonusMesaji = "Giriş başarılı";
                    mesaj.IslemDurumu = true;
                }
                else
                {
                    mesaj.IslemDurumu = false;
                    mesaj.DonusMesaji = "Yanlış şifre girdiniz.";
                }
            }
            else
            {
                mesaj.DonusMesaji = "Kullanıcı adı yanlış";
                mesaj.IslemDurumu = false;
            }

            return mesaj;
        }
    }
}
