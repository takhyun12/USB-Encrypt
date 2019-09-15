using System;
using System.Windows.Forms;

namespace USBCrypt.Forms
{
    public partial class Network_Warning : Form
    {
        public Network_Warning()
        {
            InitializeComponent();
        }

        int cnt = 0;
        private void main_tm_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;

            if (cnt >= 100)
                this.Close();

            cnt += 1;
        }
    
        private void Network_Warning_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.warning_form = null;
        }

    }
}
