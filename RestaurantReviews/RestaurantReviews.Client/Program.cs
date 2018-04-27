using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviews.Lib;
using RestaurantReviews.Model;

namespace RestaurantReviews.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorPrefix = "Error: ";
            string errorArgNumInval = errorPrefix + "Invalid number of arguments";
            string errorArgFormInval = errorPrefix + "Invalid input format";
            string errorArgOverflow = errorPrefix + "Invalid input size";
            string unrecognizedCommand = "Unrecognized command. Type 'help' or '?' for a list of commands.";

            int topN;

            string[] input;
            Library lib = new Library();

            //Console.WriteLine("*Welcome String*");

            while (true)
            {
                Console.Write(">");
                input = ParseInput(Console.ReadLine().ToLower());

                if (input.Length < 1)
                {
                    Console.WriteLine(unrecognizedCommand);
                    continue;
                }

                switch (input[0])
                {
                    case "top":
                        if (input.Length != 2)
                        {
                            Console.WriteLine(errorArgNumInval);
                            break;
                        }

                        try
                        {
                            topN = int.Parse(input[1]);
                            Display(lib.Sort(SortBy.Score, false, topN));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(errorArgFormInval);
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(errorArgOverflow);
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
                        Console.WriteLine(unrecognizedCommand);
                        break;
                }
            }
        }

        private static string[] ParseInput(string s)
        {
            throw new NotImplementedException();
        }

        private static void Display(Restaurant[] results)
        {
            throw new NotImplementedException();
        }

        private static void Display(Review[] results)
        {
            throw new NotImplementedException();
        }
    }
}
