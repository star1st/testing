using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad2
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2(Form1 ff1)
        {
            f1 = ff1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.button1.Text = "Find";
            this.Text = "FIND";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f1.textBox1.Text.Contains(this.textBox1.Text))
            {
                MessageBox.Show("Find Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not Found!");
                this.Close();
            }
        }
    }
}
