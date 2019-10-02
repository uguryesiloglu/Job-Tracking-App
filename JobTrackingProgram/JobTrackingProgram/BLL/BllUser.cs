using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    static class BllUser
    {
        public static Mesaj UserLoginProcess(string username,string password)
        {
            var user = DAL.HelperUser.GetUser(username);

            Mesaj mesaj = new Mesaj();

            if (user!=null)
            {
                if (user.Password==password)
                {
                    mesaj.DonusMesaji = "Giriş başarılı";
                    mesaj.IslemDurumu = true;
                    mesaj.user = user;
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
