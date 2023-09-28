using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Payroll_Service
{
    internal class Payroll_Service_Operations
    {
        public static void CreateDatabase()
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; initial catalog=master; integrated security= true");
            string query = "Create database PayRoll_Service";
            SqlCommand cmd = new SqlCommand(query, con);
            //opening conection
            con.Open();
            //Execute query
            cmd.ExecuteNonQuery();

            //display a massege
            Console.WriteLine("Database Created Successfully");
            Console.WriteLine("====================================");
            //close connection
            con.Close();

        }

        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog =PayRoll_Service; integrated security = true");

        public static void CreateTable()
        {
            string query = "create table Employee_Payroll(Id int primary key Identity(1,1),Name varchar(200),Salary float,Start_Date Date)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table created successfully");
            Console.WriteLine("===============================");
            con.Close();
        }

        public static void InsertData()
        {
            // string query = "insert into Employee_Payroll values('Raj',6000.0,'2018-06-1'),('Arya',5500.0,'2020-08-03'),('Shubham',3000.0,'2023-01-10')";
            string query1 = "insert into Employee_Payroll values('Terisa',3000000.0, '2018-01-03','F',9134568977,'Karnataka','HR',50000.0, 100000.0, 50000.0,140000.0)";
            SqlCommand cmd = new SqlCommand(query1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("inserted data successfully");
            Console.WriteLine("===============================");
            con.Close();

        }

        public static void Display()
        {
            using (con)
            {
                Payroll_Service_Model model = new Payroll_Service_Model();
                string query = "select * from Employee_Payroll;";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("-------------Data-------------");
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader["ID"]);
                        model.Name = Convert.ToString(reader["Name"]);
                        model.Basic_Pay = Convert.ToSingle(reader["Basic_Pay"]);
                        model.Start_Date = Convert.ToString(reader["Start_Date"]);
                        model.Gender = Convert.ToChar(reader["Gender"]);
                        model.Phone = Convert.ToInt64(reader["Phone"]);
                        model.Address = Convert.ToString(reader["Address"]);
                        model.Department = Convert.ToString(reader["Department"]);
                        model.Deductions = Convert.ToSingle(reader["Deductions"]);
                        model.Textable_Pay = Convert.ToSingle(reader["Textable_Pay"]);
                        model.Income_Tax = Convert.ToSingle(reader["Income_Tax"]);
                        model.Net_Pay = Convert.ToSingle(reader["Net_Pay"]);

                        Console.WriteLine("ID: {0}\n Name: {1}\n Salary:{2}\n  Start_Date: {3}\n Gender: {4}\n Phone:{5}\n Address: {6}\n Department: {7} Deductions: {8}\n TextablePay: {9}\n Income Tax: {10}\n NetPay: {11} ", model.Id,
                            model.Name, model.Basic_Pay,model.Start_Date,model.Gender,model.Phone,model.Address,model.Department,model.Deductions,model.Textable_Pay,model.Income_Tax,model.Net_Pay);
                    }

                }
                con.Close();
            }

           
        }
        public static void Alter()
        {
            // string query = "alter table Employee_Payroll add Gender varchar(2)";
            //string query = "alter table employee_payroll add Deductions float";
            //string query = "alter table employee_payroll add Textable_Pay float";
            //string query = "alter table employee_payroll add Income_Tax float";
            string query = "alter table employee_payroll add Net_Pay float";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("altered table successfully");
            Console.WriteLine("===============================");
            con.Close();

        }

        public static void Update()
        {
            string query = "update Employee_Payroll set Gender='M' where Name='Raj' or Name= 'Shubham'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated data successfully");
            Console.WriteLine("===============================");
            con.Close();

        }

        public static void Rename_Colmn()
        {
            string query = "EXEC sp_RENAME 'employee_payroll.salary', 'Basic_Pay', 'COLUMN'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Rename colmn successfully");
            Console.WriteLine("===============================");
            con.Close();
        }


    }
}
