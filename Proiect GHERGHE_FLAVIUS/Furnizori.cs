using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_GHERGHE_FLAVIUS
{
    public partial class Furnizori : Form
    {
        private OpenFileDialog op;
        private List<JObject> listaFurnizori;
        public Furnizori()
        {
            InitializeComponent();
            op = new OpenFileDialog();
            op.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\");
            listaFurnizori = new List<JObject>();
        
        }

        private void ArataFurnizori()
        {


        }


        private void SalveazaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Furnizori.json";
            Stream stream = new FileStream(path, FileMode.Truncate,
            FileAccess.Write, FileShare.Write);
            TextWriter write = new StreamWriter(stream);
            JsonWriter jsonWriter = new JsonTextWriter(write);
            jsonWriter.WriteStartArray();
            //parcurgem elementele din listaFurnizori si le adaugam iar in fisier
            foreach (JObject film in listaFurnizori)
            {
                jsonWriter.WriteRaw(film.ToString());

                jsonWriter.WriteRaw(",");

            }
            //adaugam un nou obiect JSON creat din datele introduse
            jsonWriter.WriteRaw(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Nume = NumeFurnizorTb.Text,
                Telefon = TelefonFurnizorTb.Text,
                Adresa = AdresaFurnizorTb.Text
            }));
            jsonWriter.WriteEndArray();
            jsonWriter.Close();
            write.Close();
            stream.Close();

            //adaugam obiectul si in listaFurnizori si facem refresh la DataGridView
            listaFurnizori.Add(JObject.FromObject(new
            {
                Nume = NumeFurnizorTb.Text,
                Telefon = TelefonFurnizorTb.Text,
                Adresa = AdresaFurnizorTb.Text
            }));

        }


        private void FurnizoriAfisare_MouseClick(object sender, MouseEventArgs e)
        {
            NumeFurnizorTb.Text = FurnizoriAfisare.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void EditeazaBtn_Click(object sender, EventArgs e)
        {
            FurnizoriAfisare.SelectedRows[0].Cells[0].Value = NumeFurnizorTb.Text;

        }
        private void StergeBtn_Click(object sender, EventArgs e)

        {

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

        private void IncarcaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Furnizori.json";
            var json = File.ReadAllText(path);
            DataTable listaFurnizori = JsonConvert.DeserializeObject<DataTable>(json);
            FurnizoriAfisare.DataSource = listaFurnizori;
        }
        public class Furnizorii
        {
            public string Nume { get; set; }
            public int Telefon { get; set; }
            public string Adresa { get; set; }
        }
    }
}


