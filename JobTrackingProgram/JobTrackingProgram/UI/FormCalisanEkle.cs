using JobTrackingProgram.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTrackingProgram.UI
{
    public partial class FormCalisanEkle : Form
    {
        public FormCalisanEkle()
        {
            InitializeComponent();
        }

        private void FormCalisanEkle_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                User newUser = new User();
                Employee newEmployee = new Employee();
                newUser.Email = textBox3.Text;
                newUser.Username = textBox4.Text;
                newUser.Password = textBox5.Text;

                newEmployee.Name = textBox1.Text;
                newEmployee.Surname = textBox2.Text;
                newEmployee.Role = comboBox1.SelectedItem.ToString();
                newEmployee.User = newUser;

                var sorguDonusu = HelperEmployee.AddEmployee(newEmployee);
                if (sorguDonusu == true)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik bilgi girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }

        }
    }
}
