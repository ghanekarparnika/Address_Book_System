using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDemo
{
    internal class AddressBookOperations
    {

        //creating Database Address Book
        public static void CreateDataBase()
        {
            SqlConnection con = new SqlConnection("data source= (localdb)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            string query = "Create database AddressBook";
            SqlCommand cmd=new SqlCommand(query, con);
             con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Database created successfully");
            Console.WriteLine("===========================================");
            con.Close();
        }


        //making connection global
        public static SqlConnection con = new SqlConnection("data source= (localdb)\\MSSQLLocalDB; initial catalog=AddressBook; integrated security=true");

        //ctrating table contact in Adress book Database
        public static void CreateTable()
        {
            string query = "create table Contact(First_Name varchar(100),Last_Name varchar(100),Address varchar(100),City varchar(100),State varchar(100),zip int,Phone bigint,Email varchar(100))";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table created successfully");
            Console.WriteLine("===============================");
            con.Close();
        }
    }
}
