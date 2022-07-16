using Pattern;
using System.Windows.Forms;
namespace KeyGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtSerialKey.Text=Pattern.Pattern.SerialPattern(txtUserName.Text);
            btnCopy.Enabled=true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSerialKey.Text);
            lblCopyState.Text = "Copied!";
        }
    }
}