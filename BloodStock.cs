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
    public partial class BloodStock : Form
    {
        SqlConnection con;
        private string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public BloodStock()
        {
            InitializeComponent();
        }
        void displayData()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BloodTable", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "BloodTbl");

            dataGridView1.DataSource = ds.Tables["BloodTbl"];
        }
        int stock; // Declare stock globally to be accessible
        void getstock(string bloodGroup)
        {
            try
            {
                con.Open();
                string query = "SELECT Stock FROM BloodTable WHERE BGroup = @BGroup";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BGroup", bloodGroup);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    stock = Convert.ToInt32(dr["Stock"]);
                    MessageBox.Show("Available Stock for Blood Group " + bloodGroup + ": " + stock);
                }
                else
                {
                    MessageBox.Show("No blood stock found for the blood group: " + bloodGroup);
                }
            }
            catch (Exception ex)
            {
             //   MessageBox.Show("Error fetching blood stock: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
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

        private void label17_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }

        private void BloodStock_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(s);
            try
            {
                con.Open();
                displayData();
                getstock(BGroup.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void BGroup_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
