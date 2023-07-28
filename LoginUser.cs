using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using CMB_Delivery_Management.Model;
using CMB_Delivery_Management.Helpers;
using System.IO;

namespace CMB_Delivery_Management
{
    public partial class LoginUser : Form
    {
        public LoginUser()
        {
            InitializeComponent();
        }

        private void b_login_Click(object sender, EventArgs e)
        {
            var username = tb_username.Text;
            var passwordHash = MD5Helper.CreateMD5(tb_password.Text);

            var isValidUser = DAO.VerifyUser(username, passwordHash, AccountType.Admin);


            if (isValidUser)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }

        }

        private void LoginUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Instances.SplashInstance.Show();
        }
    }
}
