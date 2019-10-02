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
    public partial class FormTumCalisanlar : Form
    {
        public FormTumCalisanlar()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTumCalisanlar_Load(object sender, EventArgs e)
        {
            foreach (var calisan in HelperEmployee.GetEmployeeModels())
            {
                ListViewItem listItem = new ListViewItem();
                listItem.SubItems.Add(calisan.EmployeeID.ToString());
                listItem.SubItems.Add(calisan.Name);
                listItem.SubItems.Add(calisan.Surname);
                listItem.SubItems.Add(calisan.User.Email);
                listItem.SubItems.Add(calisan.Role);
                listItem.SubItems.Add(calisan.User.Username);
                listItem.SubItems.Add(calisan.User.Password);
                listView2.Items.Add(listItem);

            }
        }
    }
}
