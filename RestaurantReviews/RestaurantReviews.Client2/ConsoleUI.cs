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
            string errorPrefix = "Error: ";
            string argNumInval = errorPrefix + "Invalid number of arguments";
            string argFormInval = errorPrefix + "Invalid input format";
            string argOverflow = errorPrefix + "Invalid input size";

            int topN;

            string[] input;

            Console.WriteLine("*Welcome String*");

            while(true)
            {
                Console.Write(">");
                input = Parse(Console.ReadLine().ToLower());

                if (input.Length < 1)
                {
                    Console.WriteLine("Unrecognized input");
                    continue;
                }
                
                switch (input[0])
                {
                    case "top":
                        if (input.Length != 2)
                        {
                            Console.WriteLine(argNumInval);
                            break;
                        }

                        try
                        {
                            topN = int.Parse(input[1]);
                            Console.WriteLine();
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

                    case "search":
                    case "details":
                    case "reviews":

                    case "?":
                    case "help":
                        Console.WriteLine("List of commands:");
                        Console.WriteLine("");
                        break;

                    case "leave":
                    case "exit":
                    case "quit":
                        return;

                    default:
                        Console.WriteLine("Unrecognized command. Type 'help' or '?' for a list of commands.");
                        break;
                }
            }
        }

        private static string[] Parse(string s)
        {
            throw new NotImplementedException();
        }
    }
}
