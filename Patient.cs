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
    public partial class Patient : Form
    {
        SqlConnection con;
        private string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public Patient()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PGenderCb.SelectedIndex = -1;
            PPhoneTb.Text = "";
            PAddressTb.Text = "";
            PBGroupCb.SelectedIndex = -1;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO PatientTable (PName, PAge, PGender, PPhone, PAddress, PBGroup) " +
                         "VALUES (@PName, @PAge, @PGender, @PPhone, @PAddress, @PBGroup)";


            using (SqlConnection con = new SqlConnection(s))
            {

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@PName", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PAge", PAgeTb.Text);
                    cmd.Parameters.AddWithValue("@PGender", PGenderCb.Text);
                    cmd.Parameters.AddWithValue("@PPhone", PPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@PAddress", PAddressTb.Text);
                    cmd.Parameters.AddWithValue("@PBGroup", PBGroupCb.Text);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully!");
                        Reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients vp = new ViewPatients();
            vp.Show();
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

        private void label23_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }

        private void PNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }
    }
}
