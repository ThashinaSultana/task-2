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


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tempdb;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            SqlDataReader dr;
            con.Open();
            cmd = new SqlCommand("Select Max(roll)+1 from student", con);
            dr = cmd.ExecuteReader();
          

                while (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                  
            }
          
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection("Data Source=(localdb)\\projectsV13;Initial Catalog=Database2;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("insert into student values('" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"','"+textBox4.Text+"')", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved...");

            }
            catch (Exception)
            {
                MessageBox.Show("Not Saved");
            }

          
                con.Close();
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}