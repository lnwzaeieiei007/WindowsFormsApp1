using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            pictureBox1.Image = PlayerData.CreatePreview();
            btnBack.Click += btnBack_Click;
            btnRestart.Click += btnRestart_Click;
            btnExit.Click += btnExit_Click;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new Form9();
            form.Show();
            Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            PlayerData.Reset();
            Form form = Application.OpenForms["Form1"] as Form;
            if (form == null) form = new Form1();
            form.Show();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
