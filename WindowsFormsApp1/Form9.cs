using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            pictureBox1.Image = PlayerData.CreatePreview();
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            btnBack.Click += btnBack_Click;
            btnNext.Click += btnNext_Click;
            btnExit.Click += btnExit_Click;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { if (radioButton1.Checked) ApplyDecoration(radioButton1.Image); }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { if (radioButton2.Checked) ApplyDecoration(radioButton2.Image); }
        private void btnNone_Click(object sender, EventArgs e) { ApplyDecoration(null); }
        private void ApplyDecoration(System.Drawing.Image image) { PlayerData.Decoration = image; pictureBox1.Image = PlayerData.CreatePreview(); }
        private void btnBack_Click(object sender, EventArgs e) { PlayerData.Decoration = null; new Form8().Show(); Close(); }
        private void btnNext_Click(object sender, EventArgs e) { new Form10().Show(); Close(); }
        private void btnExit_Click(object sender, EventArgs e) { Application.Exit(); }

    }
}
