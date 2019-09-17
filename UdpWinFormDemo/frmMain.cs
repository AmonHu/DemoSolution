using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpWinFormDemo
{
    public partial class frmMain : Form
    {
        delegate void UpdateUI(string txt);

        private bool isContinue;

        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(1399))
                {
                    isContinue = true;
                    while (isContinue)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var result = await udpClient.ReceiveAsync();
                        UpdateUI update = UpdateForm;
                        //txtData.Text += (Encoding.ASCII.GetString(result.Buffer));
                        this.Invoke(update, Encoding.ASCII.GetString(result.Buffer));
                    }
                }
            });
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            isContinue = false;
        }

        private void UpdateForm(string txt)
        {
            txtData.Text += txt + "\r\n";
        }
    }
}
