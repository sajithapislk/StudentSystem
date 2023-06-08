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
    public partial class LoginScreen : Form
    {
        AdminDAO adminDAO = new AdminDAO();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string res = adminDAO.login(username, password);
            
            StudentScreen homeScreen = new StudentScreen();

            if (res == "successful") {
                this.Hide();
                homeScreen.Show();
            }
            else
            {
                MessageBox.Show(res);
            }
        }
    }
}
