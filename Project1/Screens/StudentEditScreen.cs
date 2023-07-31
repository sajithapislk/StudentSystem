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
    public partial class StudentEditScreen : Form
    {
        string id,firstName, lsatName, dob, gender, address, tp;
        StudentDAO studentDAO = new StudentDAO();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            firstName = txtFirstName.Text;
            lsatName = txtLastName.Text;
            dob = txtDOB.Text;
            gender = txtGender.Text;
            address = txtAddress.Text;
            tp = txtTP.Text;

            bool res = studentDAO.update(id, firstName, lsatName, dob, gender, address, tp);

            if (res == true)
            {

                txtFirstName.Clear();
                txtLastName.Clear();
                txtDOB.Clear();
                txtGender.Clear();
                txtAddress.Clear();
                txtTP.Clear();

                StudentScreen studentScreen = (StudentScreen)Application.OpenForms["StudentScreen"];
                studentScreen.loadData();
                this.Close();

            }
            this.Close();
        }

        public StudentEditScreen(string id, string firstName, string lsatName, string dob, string gender, string address, string tp)
        {
            InitializeComponent();

            this.id = id;
            this.firstName = firstName;
            this.lsatName = lsatName;
            this.dob = dob;
            this.gender = gender;
            this.address = address;
            this.tp = tp;
        }

        private void StudentEditScreen_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = firstName;
            txtLastName.Text = lsatName;
            txtDOB.Text = dob;
            txtGender.Text = gender;
            txtAddress.Text = address;
            txtTP.Text = tp;
        }
    }
}
