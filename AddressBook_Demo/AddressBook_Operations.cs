using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Demo
{
    internal class AddressBook_Operations
    {
        //creating Database Address Book
        public static void CreateDataBase()
        {
            SqlConnection con = new SqlConnection("data source= (localdb)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            string query = "Create database AddressBook";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Database created successfully");
            Console.WriteLine("===========================================");
            con.Close();
        }


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

        public static void InsertData()
        {
            string query = "insert into Contact values('Udit','Ghanekar','India','Pune','Maharashtra',400034,7734560049,'uditghanekar@gmail.com'),('Madhavi','Kumar','India','Panaji','Goa',400072,7734567789,'madhavikumar@gmail.com'),('Ankita','Poyarekar','India','Banglore','Karnataka',400072,8834567789,'ankitap@gmail.com')";
            
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("inserted data successfully");
            Console.WriteLine("===============================");
            con.Close();

        }


        public static void Update()
        {
            string query = "update Contact set Last_Name='Deshmukh' where First_Name='Udit'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated data successfully");
            Console.WriteLine("===============================");
            con.Close();

        }
    }
}
