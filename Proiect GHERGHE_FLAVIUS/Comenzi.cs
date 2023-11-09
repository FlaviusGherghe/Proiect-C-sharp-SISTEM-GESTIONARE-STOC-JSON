using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
using static Proiect_GHERGHE_FLAVIUS.Stocuri;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect_GHERGHE_FLAVIUS
{
    public partial class Comenzi : Form
    {
        private OpenFileDialog op;
        private List<JObject> listaComenzi;
        private List<JObject> listaComenziFactura;
      
        public Comenzi()
        {
            InitializeComponent();
            op = new OpenFileDialog();
            op.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\");
            listaComenzi = new List<JObject>();
            listaComenziFactura = new List<JObject>();
        
            Client();
            Produs();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=localhost;Initial Catalog=stoc;Integrated Security=True");

        private void Client()
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Clienti.json";
            //Read the Array
            var str = File.ReadAllText(path);
            //Sort the Array
            var x = JsonConvert.DeserializeObject<List<CLIENTI>>(str);
            //Added sorted JArray to List<Incident>
            ClientTb.DataSource = x;
            ClientTb.DisplayMember = "Nume"; // Change 2. No .ToString()
        }

        private void Produs()
        {
            string path2 = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Produse.json";
            //Read the Array
            var str = File.ReadAllText(path2);
            //Sort the Array
            var y = JsonConvert.DeserializeObject<List<PRODUSE>>(str);
            //Added sorted JArray to List<Incident>
            ProduseTb.DataSource = y;
            ProduseTb.DisplayMember = "Nume"; // Change 2. No .ToString()
        }
        public class PRODUSE
        {
            public string Nume { get; set; }
            public int PretVanzare { get; set; }
        }

        public class CLIENTI
        {
            public string Nume { get; set; }
        }


        private void ProdusNume()
        {
            string nIndex = ProduseTb.SelectedIndex.ToString();
            NumeProdusTb.Text = nIndex.ToString();

        }

      


        private void ProduseTb_SelectionChangeComitted(object sender, EventArgs e)
        {
            ProdusNume();
        }
        int n = 0;
        int LBLTotal = 0;
        private void AddFacturaBtn_Click(object sender, EventArgs e)
        {
            if (NumeProdusTb.Text == "" || CantitateTb.Text == "")
            {
                MessageBox.Show("Lipsesc informatiile necesare");
            }
            else
            {
                int total = Convert.ToInt32(CantitateTb.Text) * Convert.ToInt32(PretTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ComenziAfisare);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = NumeProdusTb.Text;
                newRow.Cells[2].Value = PretTb.Text;
                newRow.Cells[3].Value = CantitateTb.Text;
                newRow.Cells[4].Value = total;
                ComenziAfisare.Rows.Add(newRow);
                LBLTotal = LBLTotal + total;
                TotalLbl.Text = "Rezultat:" + LBLTotal;
                SumaTb.Text = "" + LBLTotal;
                n++;
                ActualizeazaStoc();
                MessageBox.Show("Produs adaugat");

            }
        }

        private void ArataComenzi()
        {
            Con.Open();
            string Query = "select * from ComandaTabel1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ComenziAfisare2.DataSource = ds.Tables[0];
            Con.Close();

        }


        private void ActualizeazaStoc()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update ProdusTabel1 set Cantitate = @Pcantitate where ProdusCod = @PrKey", Con);


                cmd.Parameters.AddWithValue("@Pcantitate", CantitateTb.Text);

                cmd.Parameters.AddWithValue("@PrKey", ProduseTb.SelectedValue.ToString());
                cmd.ExecuteNonQuery();

                Con.Close();

            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }


        }
        private void ComandaBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Comenzi.json";
            Stream stream = new FileStream(path, FileMode.Truncate,
            FileAccess.Write, FileShare.Write);
            TextWriter write = new StreamWriter(stream);
            JsonWriter jsonWriter = new JsonTextWriter(write);
            jsonWriter.WriteStartArray();
            //parcurgem elementele din listaFurnizori si le adaugam iar in fisier
            foreach (JObject film in listaComenzi)
            {
                jsonWriter.WriteRaw(film.ToString());

                jsonWriter.WriteRaw(",");

            }
            //adaugam un nou obiect JSON creat din datele introduse
            jsonWriter.WriteRaw(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Client = ClientTb.Text,
                User = GenTb.Text,
                Data = DataComandaTb.Text,
                Suma = SumaTb.Text
            }));
            jsonWriter.WriteEndArray();
            jsonWriter.Close();
            write.Close();
            stream.Close();

            //adaugam obiectul si in listaFurnizori si facem refresh la DataGridView
            listaComenzi.Add(JObject.FromObject(new
            {
                Client = ClientTb.Text,
                User = GenTb.Text,
                Data = DataComandaTb.Text,
                Suma = SumaTb.Text
            }));
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
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\Comenzi.json";
            var json = File.ReadAllText(path);
            DataTable listaComenzi = JsonConvert.DeserializeObject<DataTable>(json);
            ComenziAfisare2.DataSource = listaComenzi;
        }

        private void IncarcaBtn2_Click(object sender, EventArgs e)
        {
            string path = @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\ComenziFactura.json";
            var json = File.ReadAllText(path);
            DataTable listaComenziFactura = JsonConvert.DeserializeObject<DataTable>(json);
            ComenziAfisare2.DataSource = listaComenziFactura;
        }
    }
}
