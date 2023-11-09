namespace Proiect_GHERGHE_FLAVIUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                //this.Show();
                Login obj = new Login();
                obj.Show();
            }
        }

       
    }
}