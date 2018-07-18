using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace streamreader_01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text;
            if (File.Exists(s))
            {
                StreamReader sr = new StreamReader(s);
                textBox3.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "SR & SW";
            button1.Text = "Read";
            label1.Text = "File Loc. : ";
            label2.Text = "File Name : ";
            button2.Text = "Exit";
            button3.Text = "Write";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text;
            StreamWriter sw = new StreamWriter(s);
            sw.Write(textBox3.Text);
            MessageBox.Show("File has Written");
            sw.Close();
        }
    }
}
