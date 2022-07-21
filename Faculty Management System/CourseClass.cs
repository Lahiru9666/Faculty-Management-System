using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Faculty_Management_System
{
    class CourseClass
    {
        DBconnect connect = new DBconnect();

        //Function to insert course
        public bool insetCourse(string cName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@cn,@ch,@desc)", connect.getconnection);

            //@cn,@ch,@desc
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
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

        //Get course list
        public DataTable getCourse(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Create a update function for course edit

        public bool updateCourse(int id, string cName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET`CourseName`=@cn,`CourseHour`=@ch,`Description`=@desc WHERE  `CourseID`=@id", connect.getconnection);

            //@id, @cn,@ch,@desc
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
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

        //Create a function to delete a course using Cource id

        public bool deleteCourse(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseID` =@id", connect.getconnection);
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
    }
}
