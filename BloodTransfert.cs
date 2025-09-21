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
    public partial class BloodTransfert : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        public BloodTransfert()
        {
            InitializeComponent();
        }
        void displayData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PNum FROM PatientTable", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Pnum", typeof(string));
                dt.Load(dr);

                PIdCb.ValueMember = "Pnum";
                PIdCb.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void getdata()
        {
            if (PIdCb.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid Patient ID.");
                return;
            }

            try
            {
                con.Open();
                string query = "SELECT * FROM PatientTable WHERE PNum = @PNum";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PNum", PIdCb.SelectedValue.ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    PNameTb.Text = dr["PName"].ToString();
                    PBGroupTb.Text = dr["PBGroup"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the selected patient.");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        int stock;
        void getstock(string bloodGroup)
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM BloodTable WHERE BGroup = @BGroup";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BGroup", bloodGroup);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    stock = Convert.ToInt32(dr["BStock"]);
                    // Display stock or perform further logic as needed
                }
                else
                {
                    //MessageBox.Show("No blood stock found for the blood group: " + bloodGroup);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Available Blood Stock: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        private void BloodTransfert_Load(object sender, EventArgs e)
        {
            displayData();
        }
        private void PIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
            getstock(PBGroupTb.Text);
            if(stock>0)
            {
                button2.Visible = true;
                Avilbletbl.Text = "Avilble Stock";
                Avilbletbl.Visible = true;
            }
            else
            {
                Avilbletbl.Text = "Stock Not Avilble";
                Avilbletbl.Visible = true;
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

        private void label21_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
