using Laborator4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_GHERGHE_FLAVIUS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserTb.Text == "" || ParolaTb.Text == "")
            {
                MessageBox.Show("Toate campurile trebuie completate");
            }
            else
            {
                StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"D:\facultate\TTV\Proiect JSON GHERGHE_FLAVIUS\Proiect GHERGHE_FLAVIUS\userData.json"));
                string jsonString = reader.ReadToEnd();
                Users users = JsonConvert.DeserializeObject<Users>(jsonString);
                bool foundUser = false;
                foreach (User user in users.userData)
                {
                    if (user.username == UserTb.Text && user.password == ParolaTb.Text)
                    {
                        foundUser = true;
                        Stocuri Obj = new Stocuri();
                        Obj.Show();
                        this.Hide();
                    }
                }
                if (!foundUser) MessageBox.Show("Username sau parola gresite !");
            }
            {
                
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}