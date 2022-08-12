using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Site_Emlak_Kayit_Otomasyonu_DB_Baglantili
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "ymnbeykoz" && mskdSifre.Text == "343400")
            {
                FrmEmlakKayit emlakKayit = new FrmEmlakKayit();
                emlakKayit.Show();
                this.Hide();
            }
        }
    }
}
