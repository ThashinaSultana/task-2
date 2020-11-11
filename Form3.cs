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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            cn = new SqlConnection("Data Source=(localdb)\\projectsV13;Initial Catalog=Database2;Integrated Security=True;Pooling=False");
            cn.Open();


            cmd = new SqlCommand("select roll from student", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            cn.Close();

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\projectsV13;Initial Catalog=Database2;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            SqlDataReader dr;
            con.Open();
            cmd = new SqlCommand("select * from student where roll = '" + comboBox1.Text + "' ",con);
           
             dr=  cmd.ExecuteReader();
                while (dr.Read())
                {
                textBox1.Text = dr["roll"].ToString();
                textBox2.Text = dr["name"].ToString();
                textBox3.Text = dr["marks"].ToString();
                textBox4.Text = dr["grade"].ToString();

            }
          
            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tempdb;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            SqlDataReader dr;
            con.Open();
            cmd = new SqlCommand("update  student set roll='"+textBox1.Text+" ',name='"+textBox2.Text+"',marks='"+textBox3.Text+"',grade='"+textBox4.Text+"' where roll='"+comboBox1.Text+"' ", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated...");

            }
            catch (Exception)
            {
                MessageBox.Show("Not updated");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\projectsV13;Initial Catalog=Database2;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            SqlDataReader dr;
            con.Open();
            cmd = new SqlCommand("Delete from student where roll='"+comboBox1.Text+"' ", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted...");

            }
            catch (Exception)
            {
                MessageBox.Show("Not deleted");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text ="";
        }
    }
}


