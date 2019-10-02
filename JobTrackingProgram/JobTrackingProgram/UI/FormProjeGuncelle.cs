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
    public partial class FormProjeGuncelle : Form
    {
        public FormProjeGuncelle()
        {
            InitializeComponent();
        }

        Project guncProject = new Project();

        private void FormProjeGuncelle_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = HelperProject.GetProjects();
            comboBox2.DisplayMember = "ProjectName";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                guncProject.ProjectName = textBox1.Text;
                guncProject.Priority = comboBox1.SelectedItem.ToString();
                guncProject.Budget = Convert.ToInt32(textBox3.Text);
                guncProject.StartDate = dateTimePicker1.Value;
                guncProject.EndDate = dateTimePicker2.Value;
                guncProject.ProjectDescription = richTextBox1.Text;

                var islemDurumu = HelperProject.UpdateProject(guncProject);

                if (islemDurumu == true)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik bilgi girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            guncProject = (Project)comboBox2.SelectedItem;
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }
    }
}
