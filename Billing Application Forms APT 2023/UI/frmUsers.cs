using Billing_Application_Forms_APT_2023.BLL;
using Billing_Application_Forms_APT_2023.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_Application_Forms_APT_2023.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        UserBLL u = new UserBLL();
        UserDAL dal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if the user has selected a valid user ID
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please select the user you want to delete");
                return; // exit the method since no user is selected
            }

            // Getting User ID from Form
            if (!int.TryParse(txtUserID.Text, out int userId))
            {
                MessageBox.Show("Invalid user ID");
                return; // exit the method since the user ID is not a valid integer
            }

            // Set the user ID in your 'u' object
            u.id = userId;

            bool success = dal.Delete(u);

            // if data is deleted, the value of success will be true, else it will be false
            if (success)
            {
                // User Deleted Successfully 
                MessageBox.Show("User deleted successfully");
                clear();
            }
            else
            {
                // Failed to Delete User
                MessageBox.Show("Failed to delete user");
            }

            // refreshing Datagrid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Getting Username of the logged in user
            string loggedUser = frmLogin.loggedIn;
            UserBLL usr = dal.GetIDFromUsername(loggedUser);

            //Get the values from User UI
            u.id = Convert.ToInt32(txtUserID.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;
            u.added_by = usr.id;

            //Updating Data into database
            bool success = dal.Update(u);
            //if data is updated successfully then the value of success will be true else it will be false
            if (success == true)
            {
                //Data Updated Successfully
                MessageBox.Show("User successfully updated");
                clear();
            }
            else
            {
                //failed to update user
                MessageBox.Show("Failed to update user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Gettting Data FRom UI
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;

            //Getting Username of the logged in user
              string loggedUser = frmLogin.loggedIn;
              UserBLL usr = dal.GetIDFromUsername(loggedUser);

             u.added_by = usr.id;

            //Inserting Data into DAtabase
            bool success = dal.Insert(u);
            //If the data is successfully inserted then the value of success will be true else it will be false
            if (success == true)
            {
                //Data Successfully Inserted
                MessageBox.Show("User successfully created.");
               clear();
            }
            else
            {
                //Failed to insert data
                MessageBox.Show("Failed to add new user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void clear()
        {
            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            string keywords = txtSearch.Text;

            //Chec if the keywords has value or not
            if (keywords != null)
            {
                //Show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblUserType_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void lblTop_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

                //Get the index of particular row
                int rowIndex = e.RowIndex;
                txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
                txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
                txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
                txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
                txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
                txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
                txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
                cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
                cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();
            
        }
    }
}
