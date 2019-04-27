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
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter all data");
                    return;
                }
                StreamReader check = new StreamReader("courses center.txt");
                string scheck = check.ReadToEnd();
                check.Close();
                if (scheck.Contains(textBox1.Text + "|"))
                {
                    MessageBox.Show("this id is exist,try to change it");
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                else
                {
                    StreamWriter fs = new StreamWriter("courses center.txt", true);
                    string r = textBox1.Text + "|"
                                + textBox2.Text + "|"
                                + textBox3.Text + "|"
                                + textBox4.Text + "|"
                                 + textBox5.Text + "|"
                                + textBox6.Text;
                    fs.WriteLine(r);
                    fs.Close();
                    MessageBox.Show("Student is Added");
                    foreach (Control c in this.Controls)
                    {
                        if (c is TextBox)
                            c.Text = "";
                    }
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                StreamReader s = new StreamReader("courses center.txt");
                string line = "";
                bool found = false;
                do
                {
                    line = s.ReadLine();
                    if (line != null)
                    {
                        string[] data = line.Split('|');
                        if (data[0] == textBox1.Text)
                        {
                            textBox1.Text = data[0];
                            textBox2.Text = data[1];
                            textBox3.Text = data[2];
                            textBox4.Text = data[3];
                            textBox5.Text = data[4];
                            textBox6.Text = data[5];
                            found = true;
                            break;
                        }
                    }
                }
                while (line != null);
                s.Close();
                if (!found)
                {
                    MessageBox.Show("this id not found!");
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("please enter id");
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            TextBox txt = new TextBox();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Font = this.Font;
            frm.Size = this.Size;
            frm.Text = "All Data";
            txt.Multiline = true;
            txt.Dock = DockStyle.Fill;
            txt.ReadOnly = true;
            frm.Controls.Add(txt);

            try
            {
                StreamReader sr = new StreamReader("courses center.txt");
                string all = sr.ReadToEnd();
                sr.Close();
                txt.Text = all;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            frm.ShowDialog();


        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                StreamReader file = new StreamReader("courses center.txt");
                string oldData;
                string newData = "";
                while ((oldData = file.ReadLine()) != null)
                {
                    string[] rows = oldData.Split("|".ToCharArray());
                    if (rows[0] != textBox1.Text)
                    {
                        newData += oldData + Environment.NewLine;
                    }
                }
                MessageBox.Show("student is deleted");
                file.Close();
                if (!string.IsNullOrEmpty(newData))
                    System.IO.File.WriteAllText("courses center.txt", newData);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label7.Visible = textBox7.Visible = button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] arr = File.ReadAllLines("courses center.txt");
            for(int i=0;i<arr.Length;i++)
            {
                string[] c = arr[i].Split('|');
                if (c[0] == textBox7.Text)
                {
                    string line = textBox1.Text + '|' + textBox2.Text + '|' + textBox3.Text +
                        '|' + textBox4.Text + '|' + textBox5.Text + '|' + textBox6.Text;
                    arr[i] = line;
                }
            }
            File.WriteAllLines("courses center.txt",arr);
        }
    }
}
