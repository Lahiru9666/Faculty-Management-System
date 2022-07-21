using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Faculty_Management_System
{
    public partial class StudentLoginForm : Form
    {
        StudentClass student = new StudentClass();
        public StudentLoginForm()
        {
            InitializeComponent();
        }

      


        private void Login_Click(object sender, EventArgs e)
        {

            if (textBox_username.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show("Fill Login Data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                string username = textBox_username.Text;
                string password = textBox_password.Text;

                DataTable table = student.getList(new MySqlCommand("SELECT * FROM `user` WHERE `UserName`= '" + username + "' AND `Password`='" + password + "'"));

                if (table.Rows.Count > 0)
                {
                    Main_Form main = new Main_Form();
                    this.Hide();
                    main.Show();

                }

                else
                {
                    MessageBox.Show("Username and Password not exists", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void CLoseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CLoseButton_MouseEnter(object sender, EventArgs e)
        {
            CLoseButton.ForeColor = Color.Red;
        }

        private void CLoseButton_MouseLeave(object sender, EventArgs e)
        {
            CLoseButton.ForeColor = Color.Transparent;
        }
    }
}
    

