using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form2 : Form
    {
        Form1 mainForm;
        public Form2(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (mainForm.rows == 9 && mainForm.columns == 9 && mainForm.numberMines == 10) radioButton1.Checked = true;
            else if (mainForm.rows == 16 && mainForm.columns == 16 && mainForm.numberMines == 40) radioButton4.Checked = true;
            else if (mainForm.rows == 16 && mainForm.columns == 30 && mainForm.numberMines == 99) radioButton5.Checked = true;
            else { radioButton2.Checked = true; textBox1.Text = mainForm.rows.ToString(); textBox2.Text = mainForm.columns.ToString(); textBox3.Text = mainForm.numberMines.ToString(); }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label2.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (s == "") { textBox1.Text = "0"; return; }
            if (s[s.Length - 1] > '9' || s[s.Length - 1] < '0')
            {
                textBox1.Text = s.Substring(0, s.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string s = textBox2.Text;
            if (s == "") { textBox2.Text = "0"; return; }
            if (s[s.Length - 1] > '9' || s[s.Length - 1] < '0')
            {
                textBox2.Text = s.Substring(0, s.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            if (s == "") { textBox3.Text = "0"; return; }
            if (s[s.Length - 1] > '9' || s[s.Length - 1] < '0')
            {
                textBox3.Text = s.Substring(0, s.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (Convert.ToInt32(textBox1.Text) > 24) { textBox1.Text = "24"; }
                else if (Convert.ToInt32(textBox1.Text) < 9) { textBox1.Text = "9"; }
                if (Convert.ToInt32(textBox2.Text) > 30) { textBox2.Text = "30"; }
                else if (Convert.ToInt32(textBox2.Text) < 9) { textBox2.Text = "9"; }
                if (Convert.ToInt32(textBox3.Text) > 668) { textBox3.Text = "668"; }
                else if (Convert.ToInt32(textBox3.Text) < 10) { textBox3.Text = "10"; }
                mainForm.rows = Convert.ToInt32(textBox1.Text);
                mainForm.columns = Convert.ToInt32(textBox2.Text);
                mainForm.numberMines = Convert.ToInt32(textBox3.Text);
                this.Close();
            }
            else if (radioButton1.Checked == true)
            {
                mainForm.rows = 9;
                mainForm.columns = 9;
                mainForm.numberMines = 10;
            }
            else if (radioButton4.Checked == true)
            {
                mainForm.rows = 16;
                mainForm.columns = 16;
                mainForm.numberMines = 40;
            }
            else if (radioButton5.Checked == true)
            {
                mainForm.rows = 16;
                mainForm.columns = 30;
                mainForm.numberMines = 99;
            }
            this.Close();
            mainForm.build_array();
            mainForm.generate_buttons();
            mainForm.new_game();
        }
    }
}
