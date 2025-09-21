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

namespace Blood_Bank
{
    public partial class ViewDonoe : Form
    {
        SqlConnection con;
        private string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public ViewDonoe()
        {
            InitializeComponent();
            con = new SqlConnection(s);

        }
        void displayData()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DonorTable", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "DonorTBL");
          
            dataGridView1.DataSource = ds.Tables["DonorTBL"];
        }
        private void ViewDonoe_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(s);
            try
            {
                con.Open();
                displayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Donor d = new Donor();
            d.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonoe VD = new ViewDonoe();
            VD.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients VP = new ViewPatients();
            VP.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodStock b = new BloodStock();
            b.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            BloodTransfert BT = new BloodTransfert();
            BT.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }
    }
}
