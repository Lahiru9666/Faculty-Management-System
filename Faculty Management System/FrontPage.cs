using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Management_System
{
    public partial class FrontPage : Form
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private void ExitForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int startpoint=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            ProgressIndicator.Start();
            if(startpoint > 50)
            {
                StudentLoginForm login = new StudentLoginForm();
                ProgressIndicator.Stop();
                timer1.Stop();
                this.Hide();
                login.Show();
            }
        }

        private void ProgressIndicator_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton12_Click(object sender, EventArgs e)
        {

        }
    }
}
