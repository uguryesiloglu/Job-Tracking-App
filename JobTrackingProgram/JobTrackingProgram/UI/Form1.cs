using JobTrackingProgram.BLL;
using JobTrackingProgram.Model;
using JobTrackingProgram.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTrackingProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static User LoggedInUser { get; set; }
        public static EmployeeModel LoggedInEmployee { get; set; }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                var sorguDonusu = BllUser.UserLoginProcess(txtBxKullaniciAdi.Text, txtBxSifre.Text);

                lblGirisDurumu.Text = sorguDonusu.DonusMesaji;
                lblGirisDurumu.Visible = true;

                

                if (sorguDonusu.IslemDurumu == true)
                {
                    LoggedInUser = sorguDonusu.user;
                    LoggedInEmployee = BllEmployee.EmployeeLogin(sorguDonusu);

                    this.Hide();

                    if (LoggedInEmployee.Role =="Yönetici")
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    else
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik bilgi girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      

    }
}
