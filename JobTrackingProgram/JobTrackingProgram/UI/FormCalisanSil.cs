using JobTrackingProgram.DAL;
using JobTrackingProgram.Model;
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
    public partial class FormCalisanSil : Form
    {
        public FormCalisanSil()
        {
            InitializeComponent();
        }

        Employee silinecekEmp = new Employee();
        User silinecekUser = new User();
        private void FormCalisanSil_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = HelperEmployee.GetEmployees();
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            silinecekEmp = (Employee)comboBox2.SelectedItem;
            silinecekUser.UserID = silinecekEmp.UserID;
        }


        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((Employee)e.ListItem).Name;
            string surName = ((Employee)e.ListItem).Surname;
            e.Value = firstName + " " + surName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bu çalışanı silerseniz çalışana ait görev atamaları da silinecektir.",
                                            "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {

                    var sorguAtama = HelperEmployeeTask.DeleteEmpTasksByEmpID(silinecekEmp.EmployeeID);
                    var sorguEmp = HelperEmployee.DeleteEmployee(silinecekEmp);
                    var sorguUser = HelperUser.DeleteUser(silinecekUser.UserID);
                    if (sorguEmp == true && sorguUser == true)
                    {
                        this.Close();
                    }

                }
            }
            catch (Exception)
            {
            }


        }
    }
}
