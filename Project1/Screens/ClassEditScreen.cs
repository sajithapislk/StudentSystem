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
    public partial class ClassEditScreen : Form
    {
        string id, grade, name;
        ClassDAO classDAO = new ClassDAO();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            grade = txtGrade.Text;

            bool res = classDAO.update(id, name, grade);

            if (res == true)
            {

                txtName.Clear();
                txtGrade.Clear();

                ClassScreen classScreen = (ClassScreen)Application.OpenForms["ClassScreen"];
                classScreen.loadData();
                this.Close();

            }
        }

        public ClassEditScreen(string id, string name, string grade)
        {
            InitializeComponent();

            this.id = id;
            this.name = name;
            this.grade = grade;
        }

        private void ClassEditScreen_Load(object sender, EventArgs e)
        {
            txtName.Text = name;
            txtGrade.Text = grade;
        }
    }
}
