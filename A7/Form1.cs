using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A7
{
    public partial class Form1 : Form
    {
        #region Fields
        private A7CL.Account _account = new A7CL.Account();
        #endregion

        public Form1()
        {
            InitializeComponent();
            lblbalance.Text = "Balance: " + _account.Balance.ToString();
            listBox1.Items.Clear();
            listBox1.Items.Insert(0, lblbalance.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            double dummy = 0;
            btnDeposit.Enabled = double.TryParse(txtAmount.Text, out dummy);
            btnWithdraw.Enabled = double.TryParse(txtAmount.Text, out dummy);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            double dummy = 0;
            // Could do something like this
            //Contract.Requires(double.TryParse(txtAmount.Text, out dummy));
            try
            {
                if (double.TryParse(txtAmount.Text, out dummy))
                {
                    _account.Deposit(dummy);
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Insert(0, ex.Message);
            }
            lblbalance.Text = "Balance: " + _account.Balance.ToString();
            listBox1.Items.Insert(0, lblbalance.Text);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            double dummy = 0;
            // Could do something like this
            //Contract.Requires(double.TryParse(txtAmount.Text, out dummy));
            try
            {
                if (double.TryParse(txtAmount.Text, out dummy))
                {
                    _account.Withdraw(dummy);
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Insert(0, ex.Message);
            }
            lblbalance.Text = "Balance: " + _account.Balance.ToString();
            listBox1.Items.Insert(0, lblbalance.Text);
        }

        private void lblbalance_Click(object sender, EventArgs e)
        {

        }
    }
}
