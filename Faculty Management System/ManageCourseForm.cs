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
    public partial class ManageCourseForm : Form
    {
        CourseClass course = new CourseClass();
        public ManageCourseForm()
        {
            InitializeComponent();
        }

        private void ManageCourceForm_Load(object sender, EventArgs e)
        {
            showData();
        }

        //Show data of the course
        private void showData()
        {
            //show course list on datagridview
            DataGridView_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_CourseName.Clear();
            textBox_CourseHour.Clear();
            textBox_Description.Clear();

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_CourseName.Text == "" || textBox_CourseHour.Text == "" || textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need Course Data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_id.Text);
                string cName = textBox_CourseName.Text;
                int chr = Convert.ToInt32(textBox_CourseHour.Text);
                string desc = textBox_Description.Text;

                if (course.updateCourse(id, cName, chr, desc))
                {

                    showData();

                    button_clear.PerformClick();
                    MessageBox.Show("Course Update Successfuly", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Course Not Edit", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need Course Id", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {


                    int id = Convert.ToInt32(textBox_id.Text);
                    if (course.deleteCourse(id))
                    {

                        showData();

                        button_clear.PerformClick();
                        MessageBox.Show("Course Deleted", "Removed Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Removed Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_course.CurrentRow.Cells[0].Value.ToString();
            textBox_CourseName.Text = DataGridView_course.CurrentRow.Cells[1].Value.ToString();
            textBox_CourseHour.Text = DataGridView_course.CurrentRow.Cells[2].Value.ToString();
            textBox_Description.Text = DataGridView_course.CurrentRow.Cells[3].Value.ToString();
        }


        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`)LIKE '%"+textBox_search.Text+"%'"));
            textBox_search.Clear();
        }
    }
}


