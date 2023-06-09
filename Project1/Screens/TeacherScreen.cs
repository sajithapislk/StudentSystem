using Project1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Screens
{
    public partial class TeacherScreen : Form
    {
        TeacherDAO teacherDAO = new TeacherDAO();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public TeacherScreen()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            dgvStudents.DataSource = teacherDAO.allTeacher();
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
                TeacherEditScreen teacherEditScreen = new TeacherEditScreen(id,firstName, lsatName, dob, gender, address, tp);
                teacherEditScreen.ShowDialog();

            }
            if (dgvStudents.Columns[e.ColumnIndex].HeaderText == "DELETE")
            {
                string id = dgvStudents.Rows[e.RowIndex].Cells["id"].Value.ToString();
                string firstName = dgvStudents.Rows[e.RowIndex].Cells["first_name"].Value.ToString();
                string lsatName = dgvStudents.Rows[e.RowIndex].Cells["last_name"].Value.ToString();
                string dob = dgvStudents.Rows[e.RowIndex].Cells["date_of_birth"].Value.ToString();
                string gender = dgvStudents.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                string address = dgvStudents.Rows[e.RowIndex].Cells["address"].Value.ToString();
                string tp = dgvStudents.Rows[e.RowIndex].Cells["home_tp"].Value.ToString();
                
                StudentEditScreen studentEditScreen = new StudentEditScreen(id, firstName, lsatName, dob, gender, address, tp);
                studentEditScreen.ShowDialog();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            TeacherInsertScreen teacherInsertScreen = new TeacherInsertScreen();
            teacherInsertScreen.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }

}
