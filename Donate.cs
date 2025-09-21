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
    public partial class Donate : Form
    {
        SqlConnection con;
        private string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JAY\source\repos\Blood_Bank\BloodBankDB.mdf;Integrated Security=True";

        public Donate()
        {
            InitializeComponent();
        }

        void displayData()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DonorTBL", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "DonorTBL");

            dataGridView1.DataSource = ds.Tables["DonorTBL"];
        }

      /*  void blood()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BloodTbl", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "BloodTbl");

            dataGridView1.DataSource = ds.Tables[0];
        }*/

        private void Donate_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(s);
            try
            {
                con.Open();
                displayData();
               // blood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* DNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DBGroupTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();*/
        }
     /*   private void Reset()
        {
            DNameTb.Text = "";
            DBGroupTb.Text = "";
        }*/
        private void button3_Click(object sender, EventArgs e)
        {/*
            if(DNameTb.Text == "" )
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {

                    int stock = 1;
                    String q = "UPDATE BloodTbl SET BStock='"+stock+"'where DGroup='"+ DBGroupTb.Text+ "'";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@PName", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@PBGroup", DBGroupTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation");
                    con.Close();
                    Reset();
                    displayData();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }*/
        }
    }
}
