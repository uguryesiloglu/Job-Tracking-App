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
    public partial class FormProjeSil : Form
    {
        public FormProjeSil()
        {
            InitializeComponent();
        }

        Project silinecekProje = new Project();
        private void FormProjeSil_Load(object sender, EventArgs e)
        {
            comboBox2.ValueMember = "ProjectID";
            comboBox2.DisplayMember = "ProjectName";
            comboBox2.DataSource = HelperProject.GetProjects();
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            silinecekProje = (Project)comboBox2.SelectedItem;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Bu projeyi silerseniz ait olan tüm görev, açıklama ve görev atamaları da silinecektir.",
                                            "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var sorgu1 = HelperTaskDescription.DeleteTaskDescByPrjID(silinecekProje.ProjectID);
                    var sorgu2 = HelperEmployeeTask.DeleteEmpTaskByPrjID(silinecekProje.ProjectID);
                    var sorgu = HelperTask.DeleteTasks(silinecekProje.ProjectID);
                    var sorgu3 = HelperProject.DeleteProject(silinecekProje);

                    if (sorgu3 == true)
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
