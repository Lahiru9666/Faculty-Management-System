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
using DGVPrinterHelper;

namespace Faculty_Management_System
{
    public partial class PrintStudentScoreForm : Form
    {
        StudentScoreClass score = new StudentScoreClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintStudentScoreForm()
        {
            InitializeComponent();
        }

        private void PrintStudentScoreForm_Load(object sender, EventArgs e)
        {
            showScore();
        }

        //show score list in DataGrideView
        public void showScore()
        {
            DataGridView_PrintScoreList.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFname,student.StdLname,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentId=student.StdId"));
        }

        private void button_searchScore_Click(object sender, EventArgs e)
        {
            DataGridView_PrintScoreList.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFname,student.StdLname,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentId=student.StdId WHERE CONCAT(student.StdFname,student.StdLname,score.CourseName)LIKE '%" + textBox_search.Text + "%'"));

        }

        private void button_printScore_Click(object sender, EventArgs e)
        {
            //Print PDF file
            printer.Title = "Faculty Managment System Student Course List";
            printer.SubTitle = string.Format("Date : {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "FACULTY MANAGEMENT SYSTEM";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_PrintScoreList);
        }
    }
}
