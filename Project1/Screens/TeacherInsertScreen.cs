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
        public TeacherInsertScreen()
        {
            InitializeComponent();
        }

        private void StudentInsertScreen_Load(object sender, EventArgs e)
        {

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

            if (res == true){

                txtFirstName.Clear();
                txtLastName.Clear();
                txtDOB.Clear();
                txtGender.Clear();
                txtAddress.Clear();
                txtTP.Clear();

            }
        }
    }
}
