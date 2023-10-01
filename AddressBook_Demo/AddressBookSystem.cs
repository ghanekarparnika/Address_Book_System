using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Demo
{
    public class AddressBookSystem
    {
        public static SqlConnection con = new SqlConnection("data source= (localdb)\\MSSQLLocalDB; initial catalog=AddressBook; integrated security=true");
       private static Dictionary<string,string> addressBookDictionary = new Dictionary<string, string>();

       

        public static void CreateAddressBook()
        {
            Console.Write("Enter the name of the Address Book: ");
            string addressBookName = Console.ReadLine();


            // Check if the address book name is already in the dictionary
            if (addressBookDictionary.ContainsKey(addressBookName))
            {
                Console.WriteLine($"Address Book '{addressBookName}' already exists.");
                return;
            }


            // Create a new table for the address book in the database
            string createTableQuery = $"CREATE TABLE {addressBookName} (FirstName VARCHAR(200), LastName VARCHAR(200), City VARCHAR(200), Phone VARCHAR(200),Email VARCHAR(200))";

            using (con)
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(createTableQuery, con))
                {
                    command.ExecuteNonQuery();
                }
            }

            // Add the address book to the dictionary
            addressBookDictionary.Add(addressBookName, addressBookName);
            Console.WriteLine($"Address Book '{addressBookName}' created successfully.");
            con.Close();
        }

   
        public static void AddContactToAddressBook()
        {
            Console.Write("Enter the name of the Address Book: ");
            string addressBookName = Console.ReadLine();

            Console.Write("Enter  First Name: ");
            string fname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lname = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();


            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            // Insert the contact into the specified address book table
            string insertQuery = $"INSERT INTO {addressBookName}(FirstName,LastName,City,Phone, Email)  VALUES (@FirstName,@LastName ,@City,@Phone, @Email)";

            using (con)
            {
                con.Open(); 
                using (SqlCommand command = new SqlCommand(insertQuery, con))
                {
                    command.Parameters.AddWithValue("@FirstName", fname);
                    command.Parameters.AddWithValue("@LastName", lname);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Contact added successfully.");
            con.Close();
        }
       

    }


}
