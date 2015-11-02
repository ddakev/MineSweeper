using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Speech.Synthesis;
using System.IO;

namespace MineSweeper
{
    partial class AboutBox1 : Form
    {
        Form1 mainForm;
        public AboutBox1(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
