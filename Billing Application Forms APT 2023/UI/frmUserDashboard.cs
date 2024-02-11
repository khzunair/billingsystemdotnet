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
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        //Set a public static method to specify whether the form is purchase or sales
        public static string transactionType;

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set value on transactionType static method
            transactionType = "Purchase";
            frmPurchaseAndSales purchase = new frmPurchaseAndSales();
            purchase.Show();
        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set the value to transacionType method to sales
            transactionType = "Sales";
            frmPurchaseAndSales sales = new frmPurchaseAndSales();
            sales.Show();

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();     
            inventory.Show();   
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust frmDeaCust = new frmDeaCust();
            frmDeaCust.Show();  
        }

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void deealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust fdc = new frmDeaCust();
            fdc.Show();
        }

        private void menuStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
