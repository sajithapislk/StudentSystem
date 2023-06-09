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
    public partial class ClassInsertScreen: Form
    {
        ClassDAO classDAO = new ClassDAO();
        public ClassInsertScreen()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string grade = txtGrade.Text;

            bool res = classDAO.insert(name, grade);

            if (res == true){

                txtName.Clear();
                txtGrade.Clear();

            }
        }
    }
}
