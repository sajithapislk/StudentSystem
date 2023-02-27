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
    public partial class StudentScreen : Form
    {
        StudentDAO studentDAO = new StudentDAO();

        public StudentScreen()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            dgvStudents.DataSource = studentDAO.allStudent();
            dgvStudents.Refresh();
        }

        private void StudentScreen_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudents.Columns[e.ColumnIndex].HeaderText == "EDIT")
            {
                string id = dgvStudents.Rows[e.RowIndex].Cells["id"].Value.ToString();
                string firstName = dgvStudents.Rows[e.RowIndex].Cells["first_name"].Value.ToString();
                string lsatName = dgvStudents.Rows[e.RowIndex].Cells["last_name"].Value.ToString();
                string dob = dgvStudents.Rows[e.RowIndex].Cells["date_of_birth"].Value.ToString();
                string gender = dgvStudents.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                string address = dgvStudents.Rows[e.RowIndex].Cells["address"].Value.ToString();
                string tp = dgvStudents.Rows[e.RowIndex].Cells["home_tp"].Value.ToString();

                MessageBox.Show(id);
                StudentEditScreen studentEditScreen = new StudentEditScreen(id,firstName, lsatName, dob, gender, address, tp);
                studentEditScreen.ShowDialog();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
