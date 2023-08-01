using Project1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Screens
{
    public partial class TeacherInsertScreen : Form
    {
        TeacherDAO teacherDAO = new TeacherDAO();
        ClassDAO classDAO = new ClassDAO();
        ClassTeacherDAO classTeacherDAO = new ClassTeacherDAO();
        public TeacherInsertScreen()
        {
            InitializeComponent();
        }

        private void StudentInsertScreen_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lsatName = txtLastName.Text;
            string dob = txtDOB.Text;
            string gender = txtGender.Text;
            string address = txtAddress.Text;
            string tp = txtTP.Text;

            bool res = teacherDAO.insert(firstName, lsatName, dob, gender, address, tp);
            
            String tID = teacherDAO.getId(firstName, lsatName, dob, gender, address, tp);
            if (tID != "")
            {
                for (int i = 0; i < dgvStudents.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dgvStudents.Rows[i].Cells["ceb"].Value) == true)
                    {
                        string class_id = dgvStudents.Rows[i].Cells["id"].Value.ToString();
                        classTeacherDAO.insert(tID, class_id);
                    }
                }
            }

            //for (int i = 0; i < dgvStudents.RowCount - 1; i++)
            //{
            //    if (Convert.ToBoolean(dgvStudents.Rows[i].Cells["ceb"].Value) == true)
            //    {
            //        MessageBox.Show(dgvStudents.Rows[i].Cells["name"].Value.ToString());
            //    }

            if (res == true)
            {

                txtFirstName.Clear();
                txtLastName.Clear();
                txtDOB.Clear();
                txtGender.Clear();
                txtAddress.Clear();
                txtTP.Clear();

            }

            this.Close();

        }

        public void loadData()
        {
            dgvStudents.DataSource = classDAO.allClasses();
            dgvStudents.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
