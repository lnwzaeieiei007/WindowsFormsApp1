using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form = Application.OpenForms["Form1"] as Form1;
            if (form != null) form.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
