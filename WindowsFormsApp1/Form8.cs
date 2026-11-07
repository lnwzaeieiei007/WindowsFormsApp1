using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            pictureBox1.Image = PlayerData.CreatePreview();
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            btnBack.Click += btnBack_Click;
            btnNext.Click += btnNext_Click;
            btnExit.Click += btnExit_Click;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { if (radioButton1.Checked) ApplyAccessory(radioButton1.Image); }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { if (radioButton2.Checked) ApplyAccessory(radioButton2.Image); }
        private void btnNone_Click(object sender, EventArgs e) { ApplyAccessory(null); }
        private void ApplyAccessory(System.Drawing.Image image) { PlayerData.Accessory = image; pictureBox1.Image = PlayerData.CreatePreview(); }
        private void btnBack_Click(object sender, EventArgs e) { PlayerData.Accessory = null; new Form7().Show(); Close(); }
        private void btnNext_Click(object sender, EventArgs e) { new Form9().Show(); Close(); }
        private void btnExit_Click(object sender, EventArgs e) { Application.Exit(); }
    }
}
