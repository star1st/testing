using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OLD.DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        myConn conn = new myConn();

       
        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Text = "All Data";
            this.button2.Text = "Populate";
            this.label1.Text = "Name";
            this.label2.Text = "Address";
            this.label3.Text = "DOB";
            this.label4.Text = "Year";

            this.button3.Text = "Populate Country";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open(); 
            OleDbCommand cmd = new OleDbCommand("select * from student", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
             dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.oleDbConnection1.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from student", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["sid"].ToString());
            }


            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from student where sid = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["sname"].ToString();
                textBox2.Text = dr["sadd"].ToString();
                textBox3.Text = dr["sdob"].ToString();
                textBox4.Text = dr["sdoby"].ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox3.Items.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from cities where cname = '" + comboBox2.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comboBox3.Items.Add(dr["ciname"].ToString());
            }

            conn.oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from countries", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["cname"].ToString());
            }


            conn.oleDbConnection1.Close();
        }
    }
}
