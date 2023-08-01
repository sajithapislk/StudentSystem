using Project1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Screens
{
    public partial class StudentInsertScreen : Form
    {
        StudentDAO studentDAO = new StudentDAO();
        ClassStudentDAO classStudentDAO = new ClassStudentDAO();
        ClassDAO classDAO = new ClassDAO();
        public StudentInsertScreen()
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

            bool res = studentDAO.insert(firstName, lsatName, dob, gender, address, tp);
            String stID = studentDAO.getId(firstName, lsatName, dob, gender, address, tp);
            if (stID != "")
            {
                for (int i = 0; i < dgvStudents.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dgvStudents.Rows[i].Cells["ceb"].Value) == true)
                    {
                        string class_id = dgvStudents.Rows[i].Cells["id"].Value.ToString();
                        classStudentDAO.insert(stID, class_id);
                    }
                }
            }

            if (res == true)
            {
                txtFirstName.Clear();
                txtLastName.Clear();
                txtDOB.Clear();
                txtGender.Clear();
                txtAddress.Clear();
                txtTP.Clear();

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
