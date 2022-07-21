using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Management_System
{
    class StudentScoreClass
    {
        DBconnect connect = new DBconnect();


        //Create a function to add score
        public bool insertScore(int StudentId, string CourseName, double Score, string Description)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `score`(`StudentId`, `CourseName`, `Score`, `Description`) VALUES(@StudentId, @CourseName, @Score, @Description)", connect.getconnection);

            //@StudentId, @CourseName, @Score, @Description

            command.Parameters.Add("StudentId", MySqlDbType.Int32).Value = StudentId;
            command.Parameters.Add("@CourseName", MySqlDbType.VarChar).Value = CourseName;
            command.Parameters.Add("@Score", MySqlDbType.Double).Value = Score;
            command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
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

        //Create function to get list

        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Create a function to check alrady course score
        public bool checkScore(int StudentId, string CourseName)
        {
            DataTable table = getList(new MySqlCommand("SELECT * FROM `score` WHERE `StudentId`= " + StudentId + " AND `CourseName`= '" + CourseName + "' "));
            if (table.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Create a function to edit Score data

        public bool updatetScore(int StudentId, string CourseName, double Score, string Description)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `score` SET `Score`=@score,`Description` =@Description WHERE `StudentId`=@StudentId AND `CourseName` =@CourseName", connect.getconnection);

            //@StudentId, @CourseName @Score, @Description

            command.Parameters.Add("StudentId", MySqlDbType.Int32).Value = StudentId;
            command.Parameters.Add("CourseName", MySqlDbType.VarChar).Value = CourseName;
            command.Parameters.Add("@Score", MySqlDbType.Double).Value = Score;
            command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
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

        //Create a function to delete data

        public bool deleteScore(int StudentId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `score` WHERE `StudentId`=@StudentId", connect.getconnection);

            //@StudentId
            command.Parameters.Add("@StudentId", MySqlDbType.Int32).Value = StudentId;

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

    

