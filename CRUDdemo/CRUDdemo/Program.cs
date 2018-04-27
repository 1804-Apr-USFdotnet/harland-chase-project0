using System;

namespace CRUDdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int latestId = AddCustomer(new Customer
            {
                companyname = "Customer C#C#C",
                contactname = "Harland, Chase",
                contacttitle = "President",
                address = "Right behind you",
                city = "Value Town",
                postalcode = "31137",
                country = "USA",
                phone = "123456789",
            });
            Console.WriteLine("Added new entry");

            Customer me = FindCustomer(latestId);
            Console.WriteLine("New entry name: " + me.contactname);
            Console.WriteLine();

            Console.WriteLine("Current contact title: " + me.contacttitle);
            me = ModifyCustomer(latestId, new Customer { contacttitle = "Mega-President" });
            Console.WriteLine("Updated contact title");

            Console.WriteLine("New contact title: " + me.contacttitle);
            Console.WriteLine();

            DeleteCustomer(latestId);
            Console.WriteLine("New entry removed");

            Customer newRef = FindCustomer(latestId);
            Console.WriteLine("Was delete successful? " + (newRef == null));
            Console.WriteLine("Is the old reference intact? " + (me != null));

            Console.ReadKey();
        }

        // Create
        static int AddCustomer(Customer cust)
        {
            using (var context = new AdventureWorksLTEntities())
            {
                var newCust = context.Customers.Add(cust);
                context.SaveChanges();
                return newCust.custid;
            }
        }

        // Read
        static Customer FindCustomer(int custId)
        {
            using (var context = new AdventureWorksLTEntities())
            {
                var std = context.Customers.Find(custId);
                return std;
            }
        }

        static Employee FindEmployee(int empId)
        {
            using (var context = new AdventureWorksLTEntities())
            {
                var std = context.Employees.Find(empId);
                return std;
            }
        }

        // Update
        static Customer ModifyCustomer(int custId, Customer newValues)
        {
            using (var context = new AdventureWorksLTEntities())
            {
                var std = context.Customers.Find(custId);
                if (newValues.address != null)
                {
                    std.address = newValues.address;
                }
                if (newValues.city != null)
                {
                    std.city = newValues.city;
                }
                if (newValues.companyname != null)
                {
                    std.companyname = newValues.companyname;
                }
                if (newValues.contactname != null)
                {
                    std.contactname = newValues.contactname;
                }
                if (newValues.contacttitle != null)
                {
                    std.contacttitle = newValues.contacttitle;
                }
                if (newValues.country != null)
                {
                    std.country = newValues.country;
                }
                if (newValues.fax != null)
                {
                    std.fax = newValues.fax;
                }
                if (newValues.phone != null)
                {
                    std.phone = newValues.phone;
                }
                if (newValues.postalcode != null)
                {
                    std.postalcode = newValues.postalcode;
                }
                if (newValues.region != null)
                {
                    std.region = newValues.region;
                }
                
                context.SaveChanges();
                return std;
            }
        }

        // Delete
        static void DeleteCustomer(int custId)
        {
            using (var context = new AdventureWorksLTEntities())
            {
                var std = context.Customers.Find(custId);
                context.Customers.Remove(std);
                context.SaveChanges();
            }
        }
    }
}
