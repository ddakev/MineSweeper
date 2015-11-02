using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form3 : Form
    {
        string n1, n2, n3, n4, n5;
        int r1, r2, r3, r4, r5, p;
        Form1 mainForm;
        public Form3(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void writetohi(int q)
        {
            TextWriter tw = new StreamWriter("highscores"+q.ToString()+".txt");
            tw.WriteLine(n1);
            tw.WriteLine(r1.ToString());
            tw.WriteLine(n2);
            tw.WriteLine(r2.ToString());
            tw.WriteLine(n3);
            tw.WriteLine(r3.ToString());
            tw.WriteLine(n4);
            tw.WriteLine(r4.ToString());
            tw.WriteLine(n5);
            tw.WriteLine(r5.ToString());
            tw.Close();
            mainForm.write = 0;
            Name1.Text = n1;
            Name2.Text = n2;
            Name3.Text = n3;
            Name4.Text = n4;
            Name5.Text = n5;
            textBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mainForm.write != 0)
            {
                if (textBox1.Text == "") return;
                else
                {
                    if (p == 1) n1 = textBox1.Text;
                    else if (p == 2) n2 = textBox1.Text;
                    else if (p == 3) n3 = textBox1.Text;
                    else if (p == 4) n4 = textBox1.Text;
                    else if (p == 5) n5 = textBox1.Text;
                    writetohi(mainForm.write);
                }
            }
            this.Close();
        }

        private void updatehi(int q)
        {
            TextReader tr = new StreamReader("highscores"+q.ToString()+".txt");
            n1 = tr.ReadLine();
            r1 = Convert.ToInt32(tr.ReadLine());
            n2 = tr.ReadLine();
            r2 = Convert.ToInt32(tr.ReadLine());
            n3 = tr.ReadLine();
            r3 = Convert.ToInt32(tr.ReadLine());
            n4 = tr.ReadLine();
            r4 = Convert.ToInt32(tr.ReadLine());
            n5 = tr.ReadLine();
            r5 = Convert.ToInt32(tr.ReadLine());
            tr.Close();
            int r = Convert.ToInt32(mainForm.label1.Text);
            if (r > r4) { r5 = r; p = 5; }
            else if (r > r3) { r5 = r4; r4 = r; p = 4; n5 = n4; }
            else if (r > r2) { r5 = r4; r4 = r3; r3 = r; p = 3; n5 = n4; n4 = n3; }
            else if (r > r1) { r5 = r4; r4 = r3; r3 = r3; r2 = r; p = 2; n5 = n4; n4 = n3; n3 = n2; }
            else { r5 = r4; r4 = r3; r3 = r2; r2 = r1; r1 = r; p = 1; n5 = n4; n4 = n3; n3 = n2; n2 = n1; }
            Name1.Text = n1;
            Name2.Text = n2;
            Name3.Text = n3;
            Name4.Text = n4;
            Name5.Text = n5;
            Res1.Text = r1.ToString();
            Res2.Text = r2.ToString();
            Res3.Text = r3.ToString();
            Res4.Text = r4.ToString();
            Res5.Text = r5.ToString();
            if (p == 1) textBox1.Location = new Point(30,50);
            else if (p == 2) textBox1.Location = new Point(30, 80);
            else if (p == 3) textBox1.Location = new Point(30, 110);
            else if (p == 4) textBox1.Location = new Point(30, 140);
            else if (p == 5) textBox1.Location = new Point(30, 170);
            textBox1.Show();
            textBox1.SelectAll();
        }

        private void en_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mainForm.write != 0)
                {
                    if (textBox1.Text == "") return;
                    else
                    {
                        if (p == 1) n1 = textBox1.Text;
                        else if (p == 2) n2 = textBox1.Text;
                        else if (p == 3) n3 = textBox1.Text;
                        else if (p == 4) n4 = textBox1.Text;
                        else if (p == 5) n5 = textBox1.Text;
                        writetohi(mainForm.write);
                    }
                }
            }
        }

        private void en2_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mainForm.write != 0)
                {
                    if (textBox1.Text == "") return;
                    else
                    {
                        if (p == 1) n1 = textBox1.Text;
                        else if (p == 2) n2 = textBox1.Text;
                        else if (p == 3) n3 = textBox1.Text;
                        else if (p == 4) n4 = textBox1.Text;
                        else if (p == 5) n5 = textBox1.Text;
                        writetohi(mainForm.write);
                    }
                }
                this.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.KeyDown += new KeyEventHandler(en_pressed);
            comboBox1.KeyDown += new KeyEventHandler(en2_pressed);
            textBox1.Text = "Player1";
            textBox1.Hide();
            readfromfile(1);
            if (mainForm.write == 1) { comboBox1.SelectedIndex = 0; updatehi(1); }
            else if (mainForm.write == 2) { comboBox1.SelectedIndex = 1; updatehi(2); }
            else if (mainForm.write == 3) { comboBox1.SelectedIndex = 2; updatehi(3); }
        }

        private void readfromfile(int q)
        {
            TextReader tr = new StreamReader("highscores"+q.ToString()+".txt");
            Name1.Text = tr.ReadLine();
            Res1.Text = tr.ReadLine();
            Name2.Text = tr.ReadLine();
            Res2.Text = tr.ReadLine();
            Name3.Text = tr.ReadLine();
            Res3.Text = tr.ReadLine();
            Name4.Text = tr.ReadLine();
            Res4.Text = tr.ReadLine();
            Name5.Text = tr.ReadLine();
            Res5.Text = tr.ReadLine();
            tr.Close();
            tr = new StreamReader("played" + q.ToString() + ".txt");
            int num1 = Convert.ToInt32(tr.ReadLine());
            int num2 = Convert.ToInt32(tr.ReadLine());
            NumW.Text = num1.ToString();
            NumL.Text = num2.ToString();
            NumA.Text = (num1 + num2).ToString();
            if (num1 == 0 && num2 == 0) Pro.Text = "0%";
            else Pro.Text = (100 * num1 / (num1 + num2)).ToString() + "%";
            tr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("highscores1.txt");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.Close();
            tw = new StreamWriter("highscores2.txt");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.Close();
            tw = new StreamWriter("highscores3.txt");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.WriteLine("Anonymous");
            tw.WriteLine("999");
            tw.Close();
            tw = new StreamWriter("played1.txt");
            tw.WriteLine("0");
            tw.WriteLine("0");
            tw.Close();
            tw = new StreamWriter("played2.txt");
            tw.WriteLine("0");
            tw.WriteLine("0");
            tw.Close();
            tw = new StreamWriter("played3.txt");
            tw.WriteLine("0");
            tw.WriteLine("0");
            tw.Close();
            Name1.Text = Name2.Text = Name3.Text = Name4.Text = Name5.Text = "Anonymous";
            Res1.Text = Res2.Text = Res3.Text = Res4.Text = Res5.Text = "999";
            NumW.Text = NumL.Text = NumA.Text = "0";
            Pro.Text = "0%";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            readfromfile(comboBox1.SelectedIndex+1);
        }
    }
}
