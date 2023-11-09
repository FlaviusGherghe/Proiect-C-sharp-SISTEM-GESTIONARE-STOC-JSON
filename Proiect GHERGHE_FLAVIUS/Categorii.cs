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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect_GHERGHE_FLAVIUS
{
    public partial class Categorii : Form
    {

        private OpenFileDialog op;
        private List<JObject> listaCategorii;
        public Categorii()
        {
            InitializeComponent();
            op = new OpenFileDialog();
            op.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\");
            listaCategorii = new List<JObject>();


        }

        private void ArataCategorii()
        {



        }



        private void SalveazaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Categorii.json";
            Stream stream = new FileStream(path, FileMode.Truncate,
            FileAccess.Write, FileShare.Write);
            TextWriter write = new StreamWriter(stream);
            JsonWriter jsonWriter = new JsonTextWriter(write);
            jsonWriter.WriteStartArray();
            //parcurgem elementele din listaCategorii si le adaugam iar in fisier
            foreach (JObject film in listaCategorii)
            {
                jsonWriter.WriteRaw(film.ToString());

                jsonWriter.WriteRaw(",");

            }
            //adaugam un nou obiect JSON creat din datele introduse
            jsonWriter.WriteRaw(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Categorie = CategorieTb.Text,

            }));
            jsonWriter.WriteEndArray();
            jsonWriter.Close();
            write.Close();
            stream.Close();

            //adaugam obiectul si in listaCategorii si facem refresh la DataGridView
            listaCategorii.Add(JObject.FromObject(new
            {
                Categorie = CategorieTb.Text,

            }));

        }

        private void CategoriiAfisare_MouseClick(object sender, MouseEventArgs e)
        {
            CategorieTb.Text = CategoriiAfisare.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void EditeazaBtn_Click(object sender, EventArgs e)
        {
            CategoriiAfisare.SelectedRows[0].Cells[0].Value = CategorieTb.Text;
        }

        private void StergeBtn_Click(object sender, EventArgs e)
        {
            CategoriiAfisare.Rows.RemoveAt(CategoriiAfisare.Rows[0].Index);
        }
        private void CountCat()
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
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Categorii.json";
            var json = File.ReadAllText(path);
            DataTable listaCategorii = JsonConvert.DeserializeObject<DataTable>(json);
            CategoriiAfisare.DataSource = listaCategorii;
        }
        private void refreshLista()
        {

        }
    }
}

