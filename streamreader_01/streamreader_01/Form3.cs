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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "FS";
            button1.Text = "Read";
            button3.Text = "Write";
            label1.Text = "File Loc. : ";
            label2.Text = "File Name : ";
            button2.Text = "Exit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            string s = textBox1.Text + textBox2.Text;
            byte[] bb = new byte[100];
            char[] ch = new char[100];

            if (File.Exists(s))
            {
                FileStream fs = new FileStream(s, FileMode.OpenOrCreate);
                fs.Read(bb, 0, 100);
                fs.Close();
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(bb, 0, bb.Length, ch, 0);
                foreach (char c in ch)
                {
                    this.textBox3.Text += c;
                }
                Console.WriteLine(ch);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text;
            byte[] bb = new byte[100];
            char[] ch = new char[100];

            if (File.Exists(s))
            {
                FileStream fs = new FileStream(s, FileMode.Create);
                ch = textBox3.Text.ToCharArray();
                Encoder enc = Encoding.UTF8.GetEncoder();
                enc.GetBytes(ch, 0, ch.Length, bb, 0,true); //true ka keyword buffer ko clean krta h uska purana garbage delete karta he
                fs.Write(bb, 0, bb.Length);
                fs.Close();
                //foreach (char c in ch)
                
                //    this.textBox3.Text = c.ToString();
                //}
                //Console.WriteLine(ch);
            }
        }
    }
}
