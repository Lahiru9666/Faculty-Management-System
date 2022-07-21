using MySql.Data.MySqlClient;
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
    public partial class ManageStudentScoreForm : Form
    {
        CourseClass course = new CourseClass();
        StudentScoreClass Score = new StudentScoreClass();
        public ManageStudentScoreForm()
        {
            InitializeComponent();
        }

        private void ManageStudentScoreForm_Load(object sender, EventArgs e)
        {
            //Populate comboBox with Couese Name
            comboBox_Select_Course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_Select_Course.DisplayMember = "CourseName";
            comboBox_Select_Course.ValueMember = "CourseName";

            //Show score on datagridview

            showScore();
        }

        public void showScore()
        {
            DataGridView_score.DataSource = Score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFname,student.StdLname,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentId=student.StdId"));
        }

        private void button_update_Click(object sender, EventArgs e)
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


                    if (Score.updatetScore(StudentId, CourseName, Scor, Description))
                    {

                        
                        showScore();
                        button_clear.PerformClick();
                        MessageBox.Show("Score Edited Complete", "Update Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Score Not Edit", "Update Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            
            if (textBox_Student_Id.Text == "")
            {
                MessageBox.Show("Field Error- Need student Id", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int Student_Id = Convert.ToInt32(textBox_Student_Id.Text);

                if (MessageBox.Show("Are you sure you want to remove this Score", "Delete Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Score.deleteScore(Student_Id))
                    {
                        showScore();
                        MessageBox.Show("Score Removed", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_clear.PerformClick();
                    }
                }
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Student_Id.Clear();
            textBox_Score.Clear();
            textBox_Description.Clear();
            textBox_search.Clear();
        }

        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            textBox_Student_Id.Text = DataGridView_score.CurrentRow.Cells[0].Value.ToString();
            comboBox_Select_Course.Text = DataGridView_score.CurrentRow.Cells[3].Value.ToString();
            textBox_Score.Text = DataGridView_score.CurrentRow.Cells[4].Value.ToString();
            textBox_Description.Text = DataGridView_score.CurrentRow.Cells[5].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_score.DataSource=Score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFname,student.StdLname,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentId=student.StdId WHERE CONCAT(student.StdFname,student.StdLname,score.CourseName)LIKE '%"+textBox_search.Text+"%'"));
                   
        }
    }
}
 