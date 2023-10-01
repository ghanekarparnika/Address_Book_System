// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using AddressBook_Demo;
using System.Data.SqlClient;

Console.WriteLine("Welcome to Address-Book");
//AddressBook_Operations.CreateDataBase();
//AddressBook_Operations.CreateTable();
//AddressBook_Operations.InsertData();
//AddressBook_Operations.Update();
//AddressBook_Operations.Delete();
//AddressBook_Operations.InsertMutiData();



//AddressBookSystem addressBookSystem = new AddressBookSystem();



while (true)
{
    Console.WriteLine("Address Book System");
    Console.WriteLine("1. Create Address Book");
    Console.WriteLine("2. Add Contact to Address Book");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice: ");

   


    if (int.TryParse(Console.ReadLine(), out int choice))
    {

        switch (choice)
    {
        case 1:
            AddressBookSystem.CreateAddressBook();
            break;
        case 2:
            AddressBookSystem.AddContactToAddressBook();
            break;
        case 3:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
    }
    else
    {
        // Handle the case where the input is not a valid integer
        Console.WriteLine("Invalid choice. Please enter a valid integer.");
    }

}

    

   




