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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void listview1(string[] s)
        {
            listView1.FocusedItem = listView1.Items[listView1.Items.Count - 1];
            listView1.Items.Insert(listView1.Items.Count, new ListViewItem(new string[] { s[0], s[1], s[2], s[3], s[4], s[5], s[6] }));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Elliptse _elsp = Ellipses.SetEllipse(comboBox1.SelectedIndex); //获得当前椭球索引
            textBox20.Text = _elsp.name;
            textBox2.Text = _elsp.a.ToString("F4");
            textBox3.Text = _elsp.b.ToString("F6");
            textBox4.Text = Math.Sqrt(_elsp.e1).ToString("F12");
            textBox5.Text = Math.Sqrt(_elsp.e2).ToString("F9");
            textBox6.Text = _elsp.f.ToString("F9");
            _elsp.f = 1 / _elsp.f;
            string f = "(1/" + _elsp.f.ToString("F2") + ")";
            textBox6.Text += f;
            textBox7.Text = _elsp.c.ToString("F12");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                MessageBox.Show("请先导入数据！");
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog(this);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string[] s1 = new string[listView1.Items.Count];
            string[] s2 = new string[listView1.Items.Count];
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                s1[i] = double.Parse(Form1.data.s[i][2]).ToString("F2");
                s2[i] = double.Parse(Form1.data.s[i][3]).ToString("F2");
                listView1.Items[i].SubItems[2].Text = s1[i];
                listView1.Items[i].SubItems[3].Text = s2[i];
            }
        }
        public struct data
        {
            public static string[][] s;
        }
        public struct select
        {
            public static string[] s1;
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string[] s1 = new string[listView1.Items.Count];
            string[] s2 = new string[listView1.Items.Count];
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                s1[i] = Form1.data.s[i][2];
                s2[i] = Form1.data.s[i][3];
                listView1.Items[i].SubItems[2].Text = s1[i];
                listView1.Items[i].SubItems[3].Text = s2[i];
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string[] s1 = new string[listView1.Items.Count];
            string[] s2 = new string[listView1.Items.Count];
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                Ang a, b;
                a.val = double.Parse(Form1.data.s[i][2]);
                b.val = double.Parse(Form1.data.s[i][3]);
                s1[i] = AngelTransformation.AngtoDec(a).ToString("F8");
                s2[i] = AngelTransformation.AngtoDec(b).ToString("F8");
                listView1.Items[i].SubItems[2].Text = s1[i];
                listView1.Items[i].SubItems[3].Text = s2[i];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox8.Text == ""))
            {
                MessageBox.Show("必需数据不足！");
            }
            else
            {
                dPoint dp = new dPoint();
                kPoint kp = new kPoint();
                dp.L = double.Parse(textBox1.Text);
                dp.B = double.Parse(textBox8.Text);
                int what = comboBox1.SelectedIndex;
                kp = Gauss.Forsol(dp, what);
                textBox10.Text = kp.X.ToString("F6");
                textBox11.Text = kp.Y.ToString("F6");
                double L0;
                L0 = 6 * ((int)(dp.L / 6) + 1) - 3;
                textBox12.Text = L0.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
                MessageBox.Show("必需数据不足！");
            else
            {
                dPoint dp = new dPoint();
                kPoint kp = new kPoint();
                double L0;
                L0 = double.Parse(textBox12.Text);
                kp.X = double.Parse(textBox10.Text);
                kp.Y = double.Parse(textBox11.Text);
                dp = Gauss.BackCal(kp, comboBox1.SelectedIndex);
                textBox1.Text = dp.B.ToString("F8");
                textBox8.Text = (dp.L + L0).ToString("F8");
            }
        }

        private void 导入数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(txt)|*.txt|所有文件(*.*)|*.*";
            string sepatator = ",";
            char[] cgap = sepatator.ToCharArray();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader sr1 = new StreamReader(fs, Encoding.ASCII);
                string[][] s = new string[999][];
                for (int i = 0; i < 9999; i++)
                {
                    string str1 = sr1.ReadLine();
                    if (str1 == null)
                        break;
                    string[] str2 = str1.Split(cgap, StringSplitOptions.None);
                    ListViewItem b = new ListViewItem(new string[] { str2[0], str2[1], str2[2],
                        str2[3], str2[4],str2[5],str2[6] });
                    listView1.Items.Add(b);
                    s[i] = str2;
                }
                Form1.data.s = s;
            }
        }

        private void 导出为数据文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(txt)|*.txt|所有文件(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string s = "";
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j < listView1.Items[i].SubItems.Count; j++)
                    {
                        if (j == listView1.Items[i].SubItems.Count - 1)
                            s += listView1.Items[i].SubItems[j].Text;
                        else
                            s += listView1.Items[i].SubItems[j].Text + ",";
                    }
                    s += "\n";
                }
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                fs.Seek(0, SeekOrigin.Begin);
                byte[] info = new ASCIIEncoding().GetBytes(s);
                fs.Write(info, 0, info.Length);
                MessageBox.Show("导出成功！");
            }
        }

        private void 清空选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                listView1.Items.RemoveAt(lvi.Index);
            }
        }

        private void 清空数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void 高斯投影正反算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[3].Text;
            string[] s = new string[4];
            for (int i = 0; i <= 3; i++)
            {
                s[i] = listView1.SelectedItems[0].SubItems[i].Text;
            }
            Form1.select.s1 = s;
        }

        private void 坐标转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox8.Text == ""))
            {
                MessageBox.Show("必需数据不足！");
            }
            else
            {
                dPoint dp = new dPoint();
                dp.L = double.Parse(textBox1.Text);
                dp.B = double.Parse(textBox8.Text);
                double r;
                int what = comboBox1.SelectedIndex;
                r = CoordinateTransforming.ConvergenceAngle(dp, what);
                textBox9.Text = r.ToString("F8");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "" || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == "")
                MessageBox.Show("必需数据不足！");
            else
            {
                double X = double.Parse(textBox16.Text);
                double Y = double.Parse(textBox17.Text);
                double xita = double.Parse(textBox18.Text);
                double k = double.Parse(textBox19.Text);
                kPoint kp = new kPoint();
                kp.X = double.Parse(textBox10.Text);
                kp.Y = double.Parse(textBox11.Text);
                kPoint kp1 = new kPoint();
                kp1 = CoordinateTransforming.ParaSwi(kp, X, Y, xita, k);
                ListViewItem b = new ListViewItem(new string[] { Form1.select.s1[0], Form1.select.s1[1],
                    kp.X.ToString(), kp1.X.ToString(),kp.Y.ToString(), kp1.Y.ToString() });
                listView2.Items.Add(b);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

