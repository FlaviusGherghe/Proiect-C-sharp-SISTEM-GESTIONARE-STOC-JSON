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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;

namespace Proiect_GHERGHE_FLAVIUS
{

    public partial class Stocuri : Form
    {

        private OpenFileDialog op;
        private List<JObject> listaProduse;

        public Stocuri()
        {

            InitializeComponent();
            op = new OpenFileDialog();
            op.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\");
            listaProduse = new List<JObject>();
            frmSampleCategoriiJson_Load();
            frmSampleFurnizoriJson_Load();

        }
        private void ArataProduse()
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Stocuri_Load(object sender, EventArgs e)
        {
        }


     
        private void SalveazaBtn_Click(object sender, EventArgs e)
        {

            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Produse.json";
            Stream stream = new FileStream(path, FileMode.Truncate,
            FileAccess.Write, FileShare.Write);
            TextWriter write = new StreamWriter(stream);
            JsonWriter jsonWriter = new JsonTextWriter(write);
            jsonWriter.WriteStartArray();
            //parcurgem elementele din listaClienti si le adaugam iar in fisier
            foreach (JObject produs in listaProduse)
            {
                jsonWriter.WriteRaw(produs.ToString());

                jsonWriter.WriteRaw(",");

            }
            //adaugam un nou obiect JSON creat din datele introduse
            jsonWriter.WriteRaw(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Nume = NumeProdusTb.Text,
                Categorie = CategorieTb.Text,
                Cantitate = CantitateTb.Text,
                PretCumparare = PretCumparareTb.Text,
                PretVanzare = PretVanzareTb.Text,
                Data = DataTb.Text,
                Furnizori = FurnizoriTb.Text
            }));
            jsonWriter.WriteEndArray();
            jsonWriter.Close();
            write.Close();
            stream.Close();

            //adaugam obiectul si in listaClienti si facem refresh la DataGridView
            listaProduse.Add(JObject.FromObject(new
            {
                Nume = NumeProdusTb.Text,
                Categorie = CategorieTb.Text,
                Cantitate = CantitateTb.Text,
                PretCumparare = PretCumparareTb.Text,
                PretVanzare = PretVanzareTb.Text,
                Data = DataTb.Text,
                Furnizori = FurnizoriTb.Text
            }));
      
        }

        private void ProduseAfisare_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        private void StergeBtn_Click(object sender, EventArgs e)
        {

         
        }
        private void CategorieTb_SelectedIndexChanged(object sender, EventArgs e)
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
        private void CautareFiltruTextBox()
        {
            string searchValue = CautareTb.Text;
            ProduseAfisare.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in ProduseAfisare.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            ProduseAfisare.Rows[rowIndex].Selected = true;
                            valueResult = true;
                            break;
                        }
                    }

                }
                if (!valueResult)
                {
                    MessageBox.Show("Nu am putut gasi" + CautareTb.Text, "Negasit");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void CautareBtn_Click(object sender, EventArgs e)
        {
            CautareFiltruTextBox();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            ArataProduse();
            CautareTb.Text = "";
        }

        private void EditeazaBtn_Click(object sender, EventArgs e)
        {
          
        }

        private void TexteGoale()
        {
           
        }

        private void ProfitFiltruTextBox()
        {
            
        }

        private void CautareCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfitFiltruTextBox();
        }

        private void IncarcaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Produse.json";
            var json = File.ReadAllText(path);
            DataTable listaProduse = JsonConvert.DeserializeObject<DataTable>(json);
            ProduseAfisare.DataSource = listaProduse;
        }

        private void refreshLista()
        {
            string output = JsonConvert.SerializeObject(this.ProduseAfisare.DataSource);
            System.IO.File.WriteAllText("Produse.json", output);

        }
        private void frmSampleCategoriiJson_Load()
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Categorii.json";
            //Read the Array
            var str = File.ReadAllText(path);
            //Sort the Array
            var x = JsonConvert.DeserializeObject<List<CATEGORIII>>(str);
            //Added sorted JArray to List<Incident>
            CategorieTb.DataSource = x;
            CategorieTb.DisplayMember = "Categorie"; // Change 2. No .ToString()

        }

        public class CATEGORIII
        {
            public string Categorie { get; set; }
        }

        public class RootObject
        {
            public List<string> Categorie { get; set; }
        }

        private void frmSampleFurnizoriJson_Load()
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Furnizori.json";
            //Read the Array
            var str = File.ReadAllText(path);
            //Sort the Array
            var x = JsonConvert.DeserializeObject<List<FURNIZORIII>>(str);
            //Added sorted JArray to List<Incident>
            FurnizoriTb.DataSource = x;
            FurnizoriTb.DisplayMember = "Nume"; // Change 2. No .ToString()

        }

        public class FURNIZORIII
        {
            public string Nume { get; set; }
        }

        public class RootObject2
        {
            public List<string> Nume { get; set; }
        }

        public class JsonIncarcareProduse
        {
            public string Nume { get; set; }
            public string Categorie { get; set; }
            public int Cantitate { get; set; }
            public int PretCumparare { get; set; }
            public int PretVanzare { get; set; }
            public DateTime Data { get; set; }
            public string Furnizori { get; set; }
        }
    }


}

