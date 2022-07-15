using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseKey_template
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        /////////////////// this codes helps us to Encryption
        Dictionary<int, string> lockCodes = new Dictionary<int, string>()
        {
            {1,"A" },{2,"D" },{3,"B" },{4,"C" },{5,"E" },{6,"H" },{7,"F" },{8,"G" },
            {9,"L" },{10,"M" },{11,"H" },{12,"I" },{13,"K" },{14,"J" },{15,"O" },{16,"M" },
            {17,"Q" },{18,"R" },{19,"P" },{20,"S" },{21,"Z" },{22,"U" },{23,"W" },{24,"V" },
            {25,"X" },{26,"Y" }
        };
        private string SerialPattern()
        {
            // we need this info to check serial number and create our pattern
            string username = txtUserName.Text;
            short directoryLength = (short)Environment.CurrentDirectory.Length;
            string systemUserName = Environment.UserName;
            short systemUserNameLength = (short)systemUserName.Length;
            string Pattern = ""; //our lock pattern
            //to control directory length
            if (directoryLength<20)
            {
                Pattern += lockCodes[systemUserNameLength +16] + lockCodes[systemUserNameLength];
            }else if (systemUserNameLength>=20&& systemUserNameLength <= 26)
            {
                Pattern += lockCodes[systemUserNameLength -16] + lockCodes[systemUserNameLength];
            }else if(systemUserNameLength > 26 && systemUserNameLength < 100)
            {
                Pattern += lockCodes[systemUserNameLength - 87] + lockCodes[systemUserNameLength - 86];
            }
            else
            {
                Pattern += lockCodes[Convert.ToInt16(systemUserNameLength.ToString("0")) + 5] +
                    lockCodes[Convert.ToInt16(systemUserNameLength.ToString("0")) + 7];
            }
            Pattern += lockCodes[username.Length];
            Pattern += lockCodes[systemUserName.Length];
            return Pattern;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text!="" && txtLicenseKey.Text!="") //check if inputs aren't null
            {
                if (txtLicenseKey.Text==SerialPattern())
                {
                    MessageBox.Show("your welcom");
                }
                else
                {
                    MessageBox.Show("wrong license key");
                }
            }
        }
    }
}