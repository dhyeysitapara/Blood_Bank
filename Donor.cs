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
    public partial class Donor : Form
    {
        SqlConnection con;
        private string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public Donor()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            DNameTb.Text = "";       
            DAgeTb.Text = "";        
            DGenderCb.SelectedIndex = -1; 
            DPhoneTb.Text = "";     
            DAddressTb.Text = "";    
            DBGroupCb.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO DonorTable (DName, DAge, DGender, DPhone, DAddress, DBGroup) " +
                          "VALUES (@DName, @DAge, @DGender, @DPhone, @DAddress, @DBGroup)";

            
            using (SqlConnection con = new SqlConnection(s))
            {
              
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                   
                    cmd.Parameters.AddWithValue("@DName", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@DAge", DAgeTb.Text);
                    cmd.Parameters.AddWithValue("@DGender", DGenderCb.Text);
                    cmd.Parameters.AddWithValue("@DPhone", DPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@DAddress", DAddressTb.Text);
                    cmd.Parameters.AddWithValue("@DBGroup", DBGroupCb.Text);

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

        private void label18_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }

        private void Donor_Load(object sender, EventArgs e)
        {

        }
    }
}
