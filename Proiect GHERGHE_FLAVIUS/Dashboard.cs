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

namespace Proiect_GHERGHE_FLAVIUS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            NumaraCategorie();
            NumaraFurnizori();
            TopComanda();
           
        }
        SqlConnection Con = new SqlConnection(@"Data Source=localhost;Initial Catalog=stoc;Integrated Security=True");

        private void NumaraCategorie()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CategoriiTabel1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CatLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void NumaraFurnizori()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from FurnizorTabel1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FurLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void TopComanda()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(SumaCumparare) from ComandaTabel1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TopComandaLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Clienti Obj = new Clienti();
            Obj.Show();
            this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Furnizori Obj = new Furnizori();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Stocuri Obj = new Stocuri();
            Obj.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Categorii Obj = new Categorii();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Comenzi Obj = new Comenzi();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Stocuri Obj = new Stocuri();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {

        }
    }
}