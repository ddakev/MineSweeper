using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MineSweeper
{
    public partial class Form4 : Form
    {
        int val = 0;
        Form1 mainForm;
        public Form4(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int p = vScrollBar1.Value - val;
            val = vScrollBar1.Value;
            System.Collections.ArrayList al = new ArrayList();
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Label) || c.GetType() == typeof(PictureBox)) al.Add(c);
            }
            for (int i = 0; i <= al.Count - 1; i++)
            {
                ((Control)al[i]).Location = new Point(((Control)al[i]).Location.X, ((Control)al[i]).Location.Y - p*3);
            }
        }
    }
}
