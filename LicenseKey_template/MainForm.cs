using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pattern;

namespace LicenseKey_template
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text!="" && txtLicenseKey.Text!="") //check if inputs aren't null
            {
                if (txtLicenseKey.Text==Pattern.Pattern.SerialPattern(txtUserName.Text)) //to check is serial corroct
                {
                    MessageBox.Show("Software Activated");
                }
                else
                {
                    MessageBox.Show("wrong license key");
                }
            }
        }
    }
}