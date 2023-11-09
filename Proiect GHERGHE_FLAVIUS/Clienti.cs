using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_GHERGHE_FLAVIUS
{


    public partial class Clienti : Form
    {
        private OpenFileDialog op;
        private List<JObject> listaClienti;
        public Clienti()
        {
            InitializeComponent();
            op = new OpenFileDialog();
            op.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\");
            listaClienti = new List<JObject>();
        }



        private void ArataClienti()
        {


        }


        private void SalveazaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Clienti.json";
            Stream stream = new FileStream(path, FileMode.Truncate,
            FileAccess.Write, FileShare.Write);
            TextWriter write = new StreamWriter(stream);
            JsonWriter jsonWriter = new JsonTextWriter(write);
            jsonWriter.WriteStartArray();
            //parcurgem elementele din listaClienti si le adaugam iar in fisier
            foreach (JObject film in listaClienti)
            {
                jsonWriter.WriteRaw(film.ToString());

                jsonWriter.WriteRaw(",");

            }
            //adaugam un nou obiect JSON creat din datele introduse
            jsonWriter.WriteRaw(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Nume = NumeClientTb.Text,
                Gen = GenTb.Text,
                Telefon = TelefonTb.Text,
                Adresa = AdresaTb.Text
            })); ;
            jsonWriter.WriteEndArray();
            jsonWriter.Close();
            write.Close();
            stream.Close();

            //adaugam obiectul si in listaClienti si facem refresh la DataGridView
            listaClienti.Add(JObject.FromObject(new
            {
                Nume = NumeClientTb.Text,
                Gen = GenTb.Text,
                Telefon = TelefonTb.Text,
                Adresa = AdresaTb.Text
            }));
        }

        private void ClientiAfisare_MouseClick(object sender, MouseEventArgs e)
        {
            NumeClientTb.Text = ClientiAfisare.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void EditeazaBtn_Click(object sender, EventArgs e)
        {
            ClientiAfisare.SelectedRows[0].Cells[0].Value = NumeClientTb.Text;
        }

        private void StergeBtn_Click(object sender, EventArgs e)
        {
            ClientiAfisare.Rows.RemoveAt(ClientiAfisare.Rows[0].Index);
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

        private void Clienti_Load(object sender, EventArgs e)
        {

        }

        private void IncarcaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Clienti.json";
            var json = File.ReadAllText(path);
            DataTable listaFurnizori = JsonConvert.DeserializeObject<DataTable>(json);
            ClientiAfisare.DataSource = listaFurnizori;
        }
        private void refreshLista()
        {

        }
        public class Clientii
        {
            public string Nume { get; set; }

            public string Gen { get; set; }
            public int Telefon { get; set; }
            public string Adresa { get; set; }
        }
    }
}
