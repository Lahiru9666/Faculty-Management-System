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
    public partial class Main_Form : Form
    {
        StudentClass student = new StudentClass();
        
        public Main_Form()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentCount();
        }

        //Create a function to display student count
        private void studentCount()
        {
            // Display values
            label_totalstd.Text = "Total STudent : " + student.totalstudent();
            label_malestd.Text = "Male : " + student.malestudent();
            label_femalestd.Text = "Female : " + student.femalestudent();
        }

        private void Panel_Slide_Paint(object sender, PaintEventArgs e)
        {

        }   

        private void customizeDesign()
        {
            Panel_Student_Sub_Menu.Visible = false;
          //  Panel_Course_Sub_Menu.Visible = false;
            //Panel_Score_Sub_Menu.Visible = false;
                         
        }

        private void hideSubmenu()
        {
            if (Panel_Student_Sub_Menu.Visible == true)
                Panel_Student_Sub_Menu.Visible = false;

         //   if (Panel_Course_Sub_Menu.Visible == true)
           //     Panel_Course_Sub_Menu.Visible = false;

          //  if (Panel_Score_Sub_Menu.Visible == true)
              //  Panel_Score_Sub_Menu.Visible = false;

        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void Button_Registraton_Click(object sender, EventArgs e)
        {
           
            showSubmenu(Panel_Student_Sub_Menu);
        }
        #region Student_Sub_menu
        private void Button_Registration_Click(object sender, EventArgs e)
        {
            openChildForm(new Registration_Form());
            hideSubmenu();
        }

        private void Button_Manage_Student_Click(object sender, EventArgs e)
        {

            openChildForm(new ManageStudent_Form());

            hideSubmenu();
        }

        private void Button_Status_Click(object sender, EventArgs e)
        {
            hideSubmenu(); 
        }

        private void Button_Std_Print_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudent());
            hideSubmenu();
        }
        #endregion Student_Sub_menu
        private void button6_Click(object sender, EventArgs e)
        {
          //  showSubmenu(Panel_Course_Sub_Menu);
        }
        #region Couse_Sub_Menu
        private void Button_New_Course_Click(object sender, EventArgs e)
        {
            openChildForm(new CourseForm());
            hideSubmenu();
        }

        private void Button_Manage_Course_Click(object sender, EventArgs e)
        {

            openChildForm(new ManageCourseForm());
            hideSubmenu();
        }

        private void Button_Course_Print_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCourseForm()); 

            hideSubmenu();
        }
        #endregion Couse_Sub_Menu
        private void Button_Score_Click(object sender, EventArgs e)
        {
          //  showSubmenu(Panel_Score_Sub_Menu);
        }

        //Show register form in main form
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }



        #region Score_Sub_Menu
        private void Button_New_Score_Click(object sender, EventArgs e)
        {
            openChildForm(new StudentScoreForm());
            hideSubmenu();
        }

        private void Button_Manage_Score_Click(object sender, EventArgs e)
        {

            openChildForm( new ManageStudentScoreForm());
            hideSubmenu();
        }

        private void Button_Score_Print_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudentScoreForm());
            hideSubmenu();
        }
        #endregion Score_Sub_Menu

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel_Logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cov);
            studentCount();
        }

    

        private void button_exit_Click_1(object sender, EventArgs e)
        {
            StudentLoginForm login = new StudentLoginForm();
            this.Hide();
            login.Show();
        }
    }
}
