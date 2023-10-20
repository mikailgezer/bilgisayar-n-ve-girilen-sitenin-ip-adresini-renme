using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace sitemnet_orn_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bilgisayar: " + Dns.GetHostName();

            foreach (IPAddress adres in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                textBox2.Text = "IP adresi: " + adres;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry siteadi = Dns.GetHostEntry(textBox4.Text);
                IPAddress[] ip = siteadi.AddressList;
                textBox3.Text = ip[0].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = textBox4.Text.ToString();
                ekle.SubItems.Add(textBox3.Text.ToString());

                listView1.Items.Add(ekle);

                textBox3.Clear();
                textBox4.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("Böyle bir site bulunamadı!!!");
            }
        }
    }
}
