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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ClassScreen>().Any())
            {
                Application.OpenForms.OfType<ClassScreen>().First().BringToFront();
            }
            else
            {
                ClassScreen classScreen = new ClassScreen();
                classScreen.Show();
            }
        }

        private void btnTecher_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<TeacherScreen>().Any())
            {
                Application.OpenForms.OfType<TeacherScreen>().First().BringToFront();
            }
            else
            {
                TeacherScreen teacherScreen = new TeacherScreen();
                teacherScreen.Show();
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<StudentScreen>().Any())
            {
                Application.OpenForms.OfType<StudentScreen>().First().BringToFront();
            }
            else
            {
                StudentScreen studentScreen = new StudentScreen();
                studentScreen.Show();
            }
        }
    }
}
