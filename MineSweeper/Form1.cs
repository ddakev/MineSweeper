using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public int numberMines=10;
        public int rows=9;
        public int columns=9;
        public int write = 0;
        int go = 0,tt=0;
        int brn,brm;
        int[,] a = new int[25, 31];
        int[,] used = new int[25, 31];
        int[] z = new int[1500];
        public Button[,] b=new Button[25,31];

        public Form1()
        {
            this.KeyDown += new KeyEventHandler(f_KeyDown);
            InitializeComponent();
        }

        public void f_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) new_game();
            else if (e.KeyCode == Keys.Escape) this.Close();
            else if (e.KeyCode == Keys.F3) { Form2 subForm = new Form2(this); subForm.ShowDialog(); }
            else if (e.KeyCode == Keys.F4) { Form3 subForm = new Form3(this); subForm.ShowDialog(); }
            else if (e.KeyCode == Keys.F1) { Form4 subForm = new Form4(this); subForm.ShowDialog(); }
        }

        private void shownumber(int x, int y)
        {
            if (b[x, y].BackgroundImage != null) { b[x, y].BackgroundImage = null; brm++; }
            if (b[x,y].Text != "") brn++;
            if (a[x, y] == 1) { b[x, y].ForeColor = System.Drawing.Color.Blue; }
            else if (a[x, y] == 2) { b[x, y].ForeColor = System.Drawing.Color.Green; }
            else if (a[x, y] == 3) { b[x, y].ForeColor = System.Drawing.Color.Red; }
            else if (a[x, y] == 4) { b[x, y].ForeColor = System.Drawing.Color.MidnightBlue; }
            else if (a[x, y] == 5) { b[x, y].ForeColor = System.Drawing.Color.DarkRed; }
            else if (a[x, y] == 6) { b[x, y].ForeColor = System.Drawing.Color.DeepSkyBlue; }
            else if (a[x, y] == 7) { b[x, y].ForeColor = System.Drawing.Color.Brown; }
            else if (a[x, y] == 8) { b[x, y].ForeColor = System.Drawing.Color.Red; }
            b[x, y].Text = a[x, y].ToString();
            int t = (x-1) * columns + y;
            this.Controls.RemoveByKey("b" + t.ToString());
            this.Controls.Add(b[x, y]);
        }

        private void wave(int s1, int s2)
        {
            brn--;
            int s=1,f=1;
            int x=0,y=0,xx=0,yy=0;
            used[s1, s2] = 1;
            z[f++] = s1;
            z[f++] = s2;
            int t = (s1-1) * columns + s2;
            b[s1, s2].Enabled = false;
            b[s1, s2].Update();
            while (f > s)
            {
                x = z[s++];
                y = z[s++];
                xx = x - 1;
                yy = y - 1;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x;
                yy = y - 1;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x + 1;
                yy = y - 1;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x - 1;
                yy = y;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x + 1;
                yy = y;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x - 1;
                yy = y + 1;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x;
                yy = y + 1;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
                xx = x + 1;
                yy = y + 1;
                if (xx >= 1 && xx <= rows && yy >= 1 && yy <= columns && used[xx, yy] == 0) { brn--; used[xx, yy] = 1; if (a[xx, yy] == 0) { b[xx, yy].Enabled = false; b[s1, s2].Update(); z[f++] = xx; z[f++] = yy; } else shownumber(xx, yy); }
            }
            if (brn == numberMines) { game_over(0, 0); go = 1; }
                
        }

        private void game_over(int x, int y)
        {
            int l = 0;
            if (rows == 9 && columns == 9 && numberMines == 10) { l = 1; }
            else if (rows == 16 && columns == 16 && numberMines == 40) { l = 2; }
            else if (rows == 16 && columns == 30 && numberMines == 99) { l = 3; }
            else l = 0;
            int t;
            go = 1;
            tt = 0;
            timer1.Stop();
            TextReader tr1 = new StreamReader("played" + l.ToString() + ".txt");
            int num1 = Convert.ToInt32(tr1.ReadLine());
            int num2 = Convert.ToInt32(tr1.ReadLine());
            tr1.Close();
            if (x == 0 && y == 0)
            {
                TextWriter tw = new StreamWriter("played" + l.ToString() + ".txt");
                tw.WriteLine((num1 + 1).ToString());
                tw.WriteLine(num2.ToString());
                tw.Close();
            }
            else
            {
                TextWriter tw = new StreamWriter("played" + l.ToString() + ".txt");
                tw.WriteLine(num1.ToString());
                tw.WriteLine((num2 + 1).ToString());
                tw.Close();
            }
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    if (a[i, j] == -1) { if (i == x && j == y) b[i, j].ForeColor = System.Drawing.Color.Red; t = (i - 1) * columns + j; b[i, j].Text = "☼"; this.Controls.RemoveByKey("b" + t.ToString()); this.Controls.Add(b[i, j]); }
                }
            }
            if (brn == numberMines)
            {
                if (l != 0)
                {
                    TextReader tr = new StreamReader("highscores" + l.ToString() + ".txt");
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    tr.ReadLine();
                    string s = tr.ReadLine();
                    tr.Close();
                    if (Convert.ToInt32(s) > Convert.ToInt32(label1.Text)) { write = l; Form3 subForm = new Form3(this); subForm.ShowDialog(); }
                }
            }
        }

        private void b_Click(object sender, MouseEventArgs e)
        {
            if (go == 1) return;
            if (e.Button.ToString() == "Right" && ((Control)sender).Text == "") { if (((Control)sender).BackgroundImage == null && brm > 0) { brm--; ((Control)sender).BackgroundImage = MineSweeper.Properties.Resources.flag; } else if(((Control)sender).BackgroundImage != null) { brm++; ((Control)sender).BackgroundImage = null; } ((Control)sender).BackgroundImageLayout = ImageLayout.Stretch; if (brm < 10) label2.Text = "00" + brm.ToString(); else if (brm < 100) label2.Text = "0" + brm.ToString(); else label2.Text = brm.ToString(); }
            else
            {
                if (((Control)sender).BackgroundImage != null) return;
                if (((Control)sender).Text != "") return;
                if (tt == 0) { tt = 1; timer1.Start(); }
                string s = ((Control)sender).Name;
                s = s.Substring(1, s.Length - 1);
                int num = Convert.ToInt32(s);
                int col, r;
                if (num % columns == 0) { col = columns; r = num / columns; }
                else { col = num % columns; r = num / columns + 1; }
                if (a[r, col] == -1) { game_over(r, col); }
                else if (a[r, col] == 0) { for (int i = 1; i <= rows; i++) for (int j = 1; j <= columns; j++) used[i, j] = 0; wave(r, col); }
                else
                {
                    brn--;
                    if (brn == numberMines) { game_over(0, 0); go = 1; }
                    if (a[r, col] == 1) { ((Control)sender).ForeColor = System.Drawing.Color.Blue; }
                    else if (a[r, col] == 2) { ((Control)sender).ForeColor = System.Drawing.Color.Green; }
                    else if (a[r, col] == 3) { ((Control)sender).ForeColor = System.Drawing.Color.Red; }
                    else if (a[r, col] == 4) { ((Control)sender).ForeColor = System.Drawing.Color.MidnightBlue; }
                    else if (a[r, col] == 5) { ((Control)sender).ForeColor = System.Drawing.Color.DarkRed; }
                    else if (a[r, col] == 6) { ((Control)sender).ForeColor = System.Drawing.Color.DeepSkyBlue; }
                    else if (a[r, col] == 7) { ((Control)sender).ForeColor = System.Drawing.Color.Brown; }
                    else if (a[r, col] == 8) { ((Control)sender).ForeColor = System.Drawing.Color.Red; }
                    ((Control)sender).Text = a[r, col].ToString();
                }
            }
        }

        public void generate_buttons()
        {
            System.Collections.ArrayList al=new ArrayList();
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button) && c.Name != "button1"&&c.Name[0]=='b'&&c.Name!="button2") al.Add(c);
            }
            for (int i = 0; i <= al.Count - 1; i++) this.Controls.Remove((Control)al[i]);
            int locX = 16, locY = 30;
            for (int i = 1; i <= rows; i++)
            {
                locX = 16;
                locY += 30;
                for (int j = 1; j <= columns; j++)
                {
                    int p = (i - 1) * columns + j;
                    string s = ("b" + p.ToString());
                    Button b1 = new Button();
                    b1.Name = s;
                    b[i, j] = b1;
                    b[i, j].Size = new Size(30, 30);
                    b[i, j].Location = new Point(locX, locY);
                    b[i, j].Font = button1.Font;
                    locX += 30;
                    this.Controls.Add(b[i, j]);
                    b[i, j].MouseUp += new MouseEventHandler(b_Click);
                    b[i, j].KeyDown += new KeyEventHandler(f_KeyDown);
                }
            }
            this.Width = locX + 30;
            this.Height = rows * 30 + 110;
            pictureBox1.Location = new Point(16, 24);
            pictureBox2.Location = new Point(this.Width-67,24);
            label1.Location = new Point(51,28);
            label2.Location = new Point(this.Width - 126,28);
            button2.Location = new Point(this.Width / 2 - 44, 24);
        }

        public void build_array()
        {
            for (int i = 1; i <= rows; i++) for (int j = 1; j <= columns; j++) a[i, j] = 0;
            for (int i = 1; i <= numberMines; i++)
            {
                Random rand = new Random();
                int k = Math.Abs(((int)Math.Floor(rand.Next()*Math.PI)) % (rows * columns));
                if (a[k / columns+1, k % columns + 1] != 0) i--;
                else a[k / columns+1, k % columns + 1] = -1;
            }
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    if (a[i, j] == -1) continue;
                    int br = 0;
                    if (i == 1)
                    {
                        if (j == 1)
                        {
                            if (a[i, j + 1] == -1) br++;
                            if (a[i + 1, j] == -1) br++;
                            if (a[i + 1, j + 1] == -1) br++;
                        }
                        else if (j == columns)
                        {
                            if (a[i, j - 1] == -1) br++;
                            if (a[i + 1, j] == -1) br++;
                            if (a[i + 1, j - 1] == -1) br++;
                        }
                        else
                        {
                            if (a[i, j + 1] == -1) br++;
                            if (a[i + 1, j] == -1) br++;
                            if (a[i + 1, j + 1] == -1) br++;
                            if (a[i, j - 1] == -1) br++;
                            if (a[i + 1, j - 1] == -1) br++;
                        }
                    }
                    else if (i == rows)
                    {
                        if (j == 1)
                        {
                            if (a[i, j + 1] == -1) br++;
                            if (a[i - 1, j] == -1) br++;
                            if (a[i - 1, j + 1] == -1) br++;
                        }
                        else if (j == columns)
                        {
                            if (a[i, j - 1] == -1) br++;
                            if (a[i - 1, j] == -1) br++;
                            if (a[i - 1, j - 1] == -1) br++;
                        }
                        else
                        {
                            if (a[i, j + 1] == -1) br++;
                            if (a[i - 1, j] == -1) br++;
                            if (a[i - 1, j + 1] == -1) br++;
                            if (a[i, j - 1] == -1) br++;
                            if (a[i - 1, j - 1] == -1) br++;
                        }
                    }
                    else
                    {
                        if (j == 1)
                        {
                            if (a[i - 1, j] == -1) br++;
                            if (a[i - 1, j + 1] == -1) br++;
                            if (a[i, j + 1] == -1) br++;
                            if (a[i + 1, j + 1] == -1) br++;
                            if (a[i + 1, j] == -1) br++;
                        }
                        else if (j == columns)
                        {
                            if (a[i - 1, j] == -1) br++;
                            if (a[i - 1, j - 1] == -1) br++;
                            if (a[i, j - 1] == -1) br++;
                            if (a[i + 1, j - 1] == -1) br++;
                            if (a[i + 1, j] == -1) br++;
                        }
                        else
                        {
                            if (a[i - 1, j + 1] == -1) br++;
                            if (a[i, j + 1] == -1) br++;
                            if (a[i + 1, j + 1] == -1) br++;
                            if (a[i - 1, j] == -1) br++;
                            if (a[i - 1, j - 1] == -1) br++;
                            if (a[i, j - 1] == -1) br++;
                            if (a[i + 1, j - 1] == -1) br++;
                            if (a[i + 1, j] == -1) br++;
                        }
                    }
                    a[i, j] = br;
                }
            }
        }

        public void new_game()
        {
            go = 0;
            tt = 0;
            timer1.Stop();
            brm = numberMines;
            if (brm < 10) label2.Text = "00" + brm.ToString();
            else if (brm < 100) label2.Text = "0" + brm.ToString();
            else label2.Text = brm.ToString();
            brn = rows * columns;
            label1.Text = "000";
            build_array();
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    b[i, j].Text = "";
                    b[i, j].Enabled = true;
                    b[i, j].ForeColor = System.Drawing.Color.Black;
                    b[i, j].BackgroundImage = null;
                    b[i, j].Update();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.KeyDown += new KeyEventHandler(f_KeyDown);
            button1.Hide();
            generate_buttons();
            new_game();
        }

        private void новаИграF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_game();
        }

        private void изходEscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void опцииF3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 subForm = new Form2(this);
            subForm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int o;
            o = Convert.ToInt32(label1.Text);
            o++;
            if (o < 10) { label1.Text = "00" + o.ToString(); }
            else if (o < 100) { label1.Text = "0" + o.ToString(); }
            else label1.Text = o.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new_game();
        }

        private void статистикаF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 subForm = new Form3(this);
            subForm.ShowDialog();
        }

        private void заМиночистачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 subForm = new AboutBox1(this);
            subForm.ShowDialog();
        }

        private void какСеИграеF1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 subForm = new Form4(this);
            subForm.ShowDialog();
        }
    }
}
