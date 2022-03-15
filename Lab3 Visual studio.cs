using Hotel.Models;
using System;
using System.Linq;
using System.Text.Json;


string menu;

do
{


    Console.WriteLine("(1). Add customer: ");
    Console.WriteLine("(2). Remove customer: ");
    Console.WriteLine("(3). Search for customer: ");
    Console.WriteLine("(4). Update customer: ");

    Console.Write("\n Select an option: ");

    menu = Console.ReadLine();
    try
    {

        switch (menu)
        {

            case "1":
                Addcustomer();
                break;

            case "2":
                RemoveCustomer();
                break;


            case "3":
                FindCustomer();
                break;

            case "4":
                UpdateCustomer();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! ---> Please make a selection between 0 - 3.");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;

    }
    catch (Exception ex)
    {
        Console.WriteLine("... Press a key to continue ...");
        Console.ReadKey();       
    }

}
while (menu != "0");


static void Addcustomer()
{
    using var context = new HotelContext();

    var Id = context.Customers.FirstOrDefault(c => c.Email == "Jv_88_@hotmail.com");

    if (Id == null)
    {
        Id = new Customer
        {
            LocationId = 1,
            DiscountId = 2,
            FirstName = "Jeanette",
            LastName = "Sonnerborg",
            PhoneNr = "0735210691",
            Email = "Jv_88_@hotmail.com",
           
        };

        context.Customers.Add(Id);
        context.SaveChanges();

        Console.WriteLine("Added!");

    }

}

static void RemoveCustomer()
{
    using var context = new HotelContext();

    var Id = context.Customers.FirstOrDefault(c => c.Email == "Jv_88_@hotmail.com");

    if (Id != null)
    {
        context.Customers.Remove(Id);
        context.SaveChanges(true);
        Console.WriteLine("Customer Removed! ");

    }
}

static void FindCustomer()
{
    using var context = new HotelContext();

    var Id = context.Customers.FirstOrDefault(c => c.Email == "Jv_88_@hotmail.com");

    if (Id != null) 
    {
        Console.WriteLine($"Found: ({JsonSerializer.Serialize(Id)})");
        Console.ReadLine();
        Console.Clear();
    }

}



static void UpdateCustomer()
{
    using var context = new HotelContext();

    var Id = context.Customers.FirstOrDefault(c => c.Email == "Jv_88_@hotmail.com");

    if (Id != null)
    {
        Id.PhoneNr = "0700112233";

        context.SaveChanges();
        Console.WriteLine("Customer info is now updated! ");

    }
}


