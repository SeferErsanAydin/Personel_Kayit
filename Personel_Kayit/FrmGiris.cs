using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-F5HD02D\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici Where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            if (dr1.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
            baglanti.Close();
        }
    }
}
