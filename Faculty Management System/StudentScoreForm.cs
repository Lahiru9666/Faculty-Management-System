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
    public partial class StudentScoreForm : Form
    {
        CourseClass course = new CourseClass();
        StudentClass student = new StudentClass();
        StudentScoreClass Score = new StudentScoreClass();

        public StudentScoreForm()
        {
            InitializeComponent();
        }


        //cretae a function to show ddata on datagrideview score

        private void showScore()
        {
            DataGridView_StudentList.DataSource = Score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFname,student.StdLname,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentId=student.StdId"));
        }
        private void StudentScoreForm_Load(object sender, EventArgs e)
        {
            //Populate comboBox with Couese Name
            comboBox_Select_Course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_Select_Course.DisplayMember = "CourseName";
            comboBox_Select_Course.ValueMember = "CourseName";



            //To show data on score GrideView
            showScore();
            //Display student list o datagridview

            DataGridView_StudentList.DataSource = student.getList(new MySqlCommand("SELECT `StdId`,`StdFname`,`StdLname` FROM `student`"));
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (textBox_Student_Id.Text == "" || textBox_Score.Text == "")
            {
                MessageBox.Show("Need Score Data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int StudentId = Convert.ToInt32(textBox_Student_Id.Text);
                string CourseName = comboBox_Select_Course.Text;
                double Scor = Convert.ToInt32(textBox_Score.Text);
                string Description = textBox_Description.Text;

                if (!Score.checkScore(StudentId, CourseName)) 
                {


                    if (Score.insertScore(StudentId, CourseName, Scor, Description))
                    {

                        //showData();
                        showScore();
                        button_Clear.PerformClick();
                        MessageBox.Show("New Score Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Score Not Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                     else
                {
                    MessageBox.Show("The score for this course are alrady exists", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }



        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Student_Id.Clear();
            textBox_Score.Clear();
            comboBox_Select_Course.SelectedIndex = 0;
            textBox_Description.Clear();
        }

        private void DataGridView_StudentList_Click(object sender, EventArgs e)
        {
            textBox_Student_Id.Text = DataGridView_StudentList.CurrentRow.Cells[0].Value.ToString();
        }

       

        private void label_Student_Score_Click_1(object sender, EventArgs e)
        {
            DataGridView_StudentList.DataSource = student.getList(new MySqlCommand("SELECT `StdId`,`StdFname`,`StdLname` FROM `student`"));
        }

        private void label_Show_student_Score_Click_1(object sender, EventArgs e)
        {
            showScore();
        }
    }
}
