using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Site_Emlak_Kayit_Otomasyonu_DB_Baglantili
{
    public partial class FrmEmlakKayit : Form
    {
        public FrmEmlakKayit()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=RABIA-AYDEMIR;Initial Catalog=EmlakKayitProgrami;Integrated Security=True");

        private void verileriGoster()
        {
            //her defasında listview'e tekrardan bilgileri sıralanmaması için temizlettim.
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tblSitelerBilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["sat_kira"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metrekare"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["dileksikayet"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSite.Text == "Acarlar")
            {
                btnAcarlar.BackColor = Color.Red;
                btnAvrupa.BackColor = Color.SandyBrown;
                btnEvora.BackColor = Color.SandyBrown;
                btnNida.BackColor = Color.SandyBrown;
            }
            if (cmbSite.Text == "Evora")
            {
                btnAcarlar.BackColor = Color.SandyBrown;
                btnAvrupa.BackColor = Color.SandyBrown;
                btnEvora.BackColor = Color.Red;
                btnNida.BackColor = Color.SandyBrown;
            }
            if (cmbSite.Text == "Avrupa")
            {
                btnAcarlar.BackColor = Color.SandyBrown;
                btnAvrupa.BackColor = Color.Red;
                btnEvora.BackColor = Color.SandyBrown;
                btnNida.BackColor = Color.SandyBrown;
            }
            if (cmbSite.Text == "Nida")
            {
                btnAcarlar.BackColor = Color.SandyBrown;
                btnAvrupa.BackColor = Color.SandyBrown;
                btnEvora.BackColor = Color.SandyBrown;
                btnNida.BackColor = Color.Red;
            }
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into tblSitelerBilgi (id,site,sat_kira,oda,metrekare,fiyat,blok,no,adsoyad,telefon,dileksikayet) values ('" + txtID.Text.ToString() + "','" + cmbSite.Text.ToString() + "','" + cmbSatKira.Text.ToString() + "','" + cmbOda.Text.ToString() + "','" + txtMetrekare.Text.ToString() + "','" + txtFiyat.Text.ToString() + "','" + cmbBlok.Text.ToString() + "','" + txtNo.Text.ToString() + "','" + txtAdSoyad.Text.ToString() + "','" + mskTelefon.Text.ToString() + "','" + richDilekSikayet.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }

        // id'e göre silme işlemi gerçekleşecek.
        int id = 0;
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from tblSitelerBilgi where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }


        //listView' e çift tıklanıldığı zaman içeriklerinin ait olduğu yerlere sıralanmasını sağlar.
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            cmbSite.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cmbSatKira.Text = listView1.SelectedItems[0].SubItems[2].Text;
            cmbOda.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtMetrekare.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtFiyat.Text = listView1.SelectedItems[0].SubItems[5].Text;
            cmbBlok.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txtNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtAdSoyad.Text = listView1.SelectedItems[0].SubItems[8].Text;
            mskTelefon.Text = listView1.SelectedItems[0].SubItems[9].Text;
            richDilekSikayet.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {

        }
    }
}
