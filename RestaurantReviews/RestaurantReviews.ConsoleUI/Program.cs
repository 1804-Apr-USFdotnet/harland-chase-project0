using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviews.Lib;

namespace RestaurantReviews.Client
{
    class ConsoleUI
    {
        static void Main(string[] args)
        {
            string argNumInval = "Invalid number of arguments";
            string argFormInval = "Invalid input format";
            string argOverflow = "Invalid input size";

            string input;
            string[] inputSplit;

            Console.WriteLine("*Welcome String*");

            while(true)
            {
                Console.Write(">");
                input = Console.ReadLine().ToLower();
                inputSplit = input.Split(' ');

                if (inputSplit.Length < 1)
                {
                    Console.WriteLine("Unrecognized");
                    continue;
                }
                
                switch (inputSplit[0])
                {
                    case "top":
                        if (inputSplit.Length != 2)
                        {
                            Console.WriteLine(argNumInval);
                            break;
                        }
                        try
                        {
                            //TODO
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(argFormInval);
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(argOverflow);
                        }

                        break;

                    case "?":
                    case "help":
                        Console.WriteLine("List of commands:");
                        Console.WriteLine("");
                        break;

                    case "exit":
                    case "quit":
                        return;

                    default:
                        Console.WriteLine("Unrecognized command.");
                        break;
                }
            }
        }
    }
}
