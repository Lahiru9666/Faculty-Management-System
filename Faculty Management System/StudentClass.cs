using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Faculty_Management_System
{
    class StudentClass
    {
        //Create a function to add a new student to the  database
        DBconnect connect = new DBconnect();

        public bool insertStudent(string fname, string lname, DateTime bdate, string gender, string phone, string email, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Student`(`StdFname`, `StdLname`, `StdBirthday`, `Gender`, `StdPhone`, `StdEmail`, `StdAddress`, `StdPhoto`) VALUES(@fn, @ln, @bd, @gd, @ph, @email, @adr, @img)", connect.getconnection);

                //@fn, @ln, @bd, @gd, @ph, @email, @adr, @img
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.colseConnect();
                return true;
            }
            else
            {
                connect.colseConnect();
                return false;
            }
        }

        //Get Student table
        public DataTable getStudentlist(MySqlCommand command)
        {
            command.Connection= connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }

        //Create a fuction to execute the count quary(tatal male, female)
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.colseConnect();
            return count;
        }
        //get the total student
        public string totalstudent()
        {
            return exeCount("SELECT COUNT(*) FROM student");
        }

        //get male student count 
        public string malestudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE `Gender`='Male'");
        }


        //get female student count 
        public string femalestudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE `Gender`='female'");
        }


        //Cretae a function serch for student (Fname, Lname, Address)
        public DataTable searchStudent(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE CONCAT(`StdFname`,`StdLname`,`StdAddress`) LIKE '%"+ searchdata +"%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }

        //Create a fuction edit for student
        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string email, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student` SET `StdFname`=@fn,`StdLname`=@ln,`StdBirthday`=@bd,`Gender`=@gd,`StdPhone`=@ph,`StdEmail`=@email,`StdAddress`=@adr,`StdPhoto`=@img WHERE `StdId`= @id", connect.getconnection);

            //@id, @fn, @ln, @bd, @gd, @ph, @email, @adr, @img
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;  
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.colseConnect();
                return true;
            }
            else
            {
                connect.colseConnect();
                return false;
            }
        }

        //Create a function to delete a student
        public bool deleteStudent(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `student` WHERE `StdId` = @id", connect.getconnection);

            //@id
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.colseConnect();
                return true;
            }
            else
            {
                connect.colseConnect();
                return false;
            }
        }


        //Create function for all command in student Db
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }

}