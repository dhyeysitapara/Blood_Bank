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
    public partial class ViewPatients : Form
    {
        SqlConnection con;
        private string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JAY\source\repos\Blood_Bank\BloodBankDB.mdf;Integrated Security=True";
        private int Key = 0;
        public ViewPatients()
        {
            InitializeComponent();
            con = new SqlConnection(s);
           
        }
        void displayData()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PatientTBL", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "PatientTBL");

            dataGridView1.DataSource = ds.Tables["PatientTBL"];
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Assuming PNum is in the first column (index 0)

                PNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                PAgeTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                PPhoneTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                PGenderCb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                PBGroupCb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                PAddressTb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PAgeTb.Text == "" || PPhoneTb.Text == "" || PGenderCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    
                    String q = "UPDATE PatientTBL SET PName = @PName, PAge = @PAge, PPhone = @PPhone, PGender = @PGender, PBGroup = @PBGroup, PAddress = @PAddress WHERE PNum = @PNum";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@PName", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PAge", PAgeTb.Text);
                    cmd.Parameters.AddWithValue("@PPhone", PPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@PGender", PGenderCb.SelectedItem.ToString()); 
                    cmd.Parameters.AddWithValue("@PBGroup", PBGroupCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAddress", PAddressTb.Text);
                    cmd.Parameters.AddWithValue("@PNum", Key); 

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    con.Close();
                    displayData();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void ViewPatients_Load(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients VP = new ViewPatients();
            VP.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
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

        private void label25_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }
    }
}

