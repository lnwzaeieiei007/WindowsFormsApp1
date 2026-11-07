using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            PlayerData.BaseImage = pictureBox1.Image;
            pictureBox1.Image = PlayerData.CreatePreview();
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            btnBack.Click += btnBack_Click;
            btnNext.Click += btnNext_Click;
            btnExit.Click += btnExit_Click;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { if (radioButton1.Checked) ApplyHair(radioButton1.Image); }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { if (radioButton2.Checked) ApplyHair(radioButton2.Image); }
        private void btnNone_Click(object sender, EventArgs e) { ApplyHair(null); }
        private void ApplyHair(System.Drawing.Image image) { PlayerData.Hair = image; pictureBox1.Image = PlayerData.CreatePreview(); }

        private void btnBack_Click(object sender, EventArgs e) { PlayerData.Hair = null; new Form2().Show(); Close(); }
        private void btnNext_Click(object sender, EventArgs e) { new Form4().Show(); Close(); }
        private void btnExit_Click(object sender, EventArgs e) { Application.Exit(); }

    }
}
