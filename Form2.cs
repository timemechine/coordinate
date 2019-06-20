using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s = new string[7];
            s[0] = textBox1.Text;
            s[1] = textBox2.Text;
            s[2] = textBox3.Text;
            s[3] = textBox4.Text;
            s[4] = textBox5.Text;
            s[5] = textBox6.Text;
            s[6] = textBox7.Text;
            Form1 f1 = (Form1)this.Owner;
            f1.listview1(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
