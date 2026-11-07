using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            pictureBox1.Image = PlayerData.CreatePreview();
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            btnBack.Click += btnBack_Click;
            btnNext.Click += btnNext_Click;
            btnExit.Click += btnExit_Click;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { if (radioButton1.Checked) ApplyShirt(radioButton1.Image); }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { if (radioButton2.Checked) ApplyShirt(radioButton2.Image); }
        private void btnNone_Click(object sender, EventArgs e) { ApplyShirt(null); }
        private void ApplyShirt(System.Drawing.Image image) { PlayerData.Shirt = image; pictureBox1.Image = PlayerData.CreatePreview(); }
        private void btnBack_Click(object sender, EventArgs e) { PlayerData.Shirt = null; new Form4().Show(); Close(); }
        private void btnNext_Click(object sender, EventArgs e) { new Form6().Show(); Close(); }
        private void btnExit_Click(object sender, EventArgs e) { Application.Exit(); }


        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
