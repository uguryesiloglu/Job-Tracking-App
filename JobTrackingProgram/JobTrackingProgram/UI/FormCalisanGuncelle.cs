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
    public partial class FormCalisanGuncelle : Form
    {
        public FormCalisanGuncelle()
        {
            InitializeComponent();
        }

        Employee guncCalisan = new Employee();
        User guncUser = new User();
        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((Employee)e.ListItem).Name;
            string surName = ((Employee)e.ListItem).Surname;
            e.Value = firstName + " " + surName;
        }

        private void FormCalisanGuncelle_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = HelperEmployee.GetEmployees();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            guncCalisan = (Employee)comboBox2.SelectedItem;
            guncUser.UserID = guncCalisan.UserID;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                guncUser.Email = textBox3.Text;
                guncUser.Username = textBox4.Text;
                guncUser.Password = textBox5.Text;

                guncCalisan.Name = textBox1.Text;
                guncCalisan.Surname = textBox2.Text;
                guncCalisan.Role = comboBox1.SelectedItem.ToString();
                guncCalisan.User = guncUser;

                var sor = HelperUser.UpdateUser(guncUser);
                var sorguDonusu = HelperEmployee.UpdateEmployee(guncCalisan);
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
