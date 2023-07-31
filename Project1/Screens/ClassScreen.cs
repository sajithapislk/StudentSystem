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
    public partial class ClassScreen : Form
    {
        ClassDAO classDAO = new ClassDAO();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public ClassScreen()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            dgvStudents.DataSource = classDAO.allClasses();
            dgvStudents.Refresh();
        }
        

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudents.Columns[e.ColumnIndex].HeaderText == "EDIT")
            {
                string id = dgvStudents.Rows[e.RowIndex].Cells["id"].Value.ToString();
                string name = dgvStudents.Rows[e.RowIndex].Cells["name"].Value.ToString();
                string grade = dgvStudents.Rows[e.RowIndex].Cells["grade"].Value.ToString();
                
                ClassEditScreen studentEditScreen = new ClassEditScreen(id, name, grade);
                studentEditScreen.ShowDialog();

            }
            if (dgvStudents.Columns[e.ColumnIndex].HeaderText == "DELETE")
            {
                string id = dgvStudents.Rows[e.RowIndex].Cells["id"].Value.ToString();

                bool res =  classDAO.deleteClasses(id);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ClassInsertScreen classInsertScreen = new ClassInsertScreen();
            classInsertScreen.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ClassScreen_Activated(object sender, EventArgs e)
        {

            loadData();
        }
    }
}
