using Billing_Application_Forms_APT_2023.BLL;
using Billing_Application_Forms_APT_2023.DAL;
using System;
using System.Windows.Forms;

namespace Billing_Application_Forms_APT_2023.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedIn;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if any of the input fields are empty
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cmbUserType.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if validation fails
            }

            // Proceed with login
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            // Checking the login credentials
            bool success = dal.loginCheck(l);
            if (success)
            {
                // Login Successful
                MessageBox.Show("Login Successful.");
                loggedIn = l.username;

                // Open Respective Forms based on User Type
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            // Display Admin Dashboard
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            // Display User Dashboard
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            // Display an error message
                            MessageBox.Show("Invalid User Type.");
                        }
                        break;
                }
            }
            else
            {
                // Login Failed
                MessageBox.Show("Login Failed. Try Again");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
