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
        // String constants
        private const string
            // Commands
            commandSort     = "sort",
            commandSearch   = "search",
            commandDetails  = "details",
            commandReviews  = "reviews",
            commandHelp     = "help",
            commandExit     = "exit",

            // top command flags
            flagTopN = "-n", flagAsc = "-a", flagSort = "-s",
            // flagSort options
            sortScore = "s", sortAlpha = "n", sortNumRev = "r",

            // Messages
            errorPrefix         = "Error: ",
            errorArgNumInval    = errorPrefix + "Invalid number of arguments.",
            errorArgFormInval   = errorPrefix + "Invalid input format.",
            errorFlagArgInval   = errorPrefix + "Unrecognized flag argument",
            errorNoResults      = errorPrefix + "No results found.",
            errorNoFind         = errorPrefix + "Couldn't find specified restaurant.",
            unrecognizedCommand = "Unrecognized command. Type '"+commandHelp+"' for a list of commands.",

            welcomeString = "Welcome to the Restaurant Reviews console UI.  Type '"+commandHelp+"' to see a list of commands.",

            helpString = "Commands:\n" +
                            commandSort+" ["+flagTopN+" n] ["+flagSort+" ["+sortScore+" | "+sortAlpha+" | "+sortNumRev+"]] ["+flagAsc+"]:" +
                                    "Displays a sorted view of restaurants. Defaults to a complete list of restaurants ordered by score in descending order\n" +
                                "\t["+flagTopN+"]: Restricts the output to only the first n results. Default shows all restaurants.\n" +
                                "\t["+flagAsc+"]: Display in ascending order. Leave this flag out for descending order.\n"+ 
                                "\t["+flagSort+ " [" + sortScore + " | " + sortAlpha + " | " + sortNumRev + "]]: Specify the sort method.\n" +
                                    "\t\t"+sortScore+": Sorts by average score. Default.\n" +
                                    "\t\t"+sortAlpha+": Sorts by name.\n" +
                                    "\t\t"+sortNumRev+": Sorts by number of reviews.\n" +
                            commandSearch +" [search terms...]: Searches for and displays restaurants by name.  Search terms are separated by spaces." +
                                    "You can add spaces to a search term by surrounding the term with quotes.\n" +
                            commandDetails+" [restaurant name]: Displays details of the named restaurant.\n" +
                            commandReviews+" [restaurant name]: Displays the reviews of the named restaurant.\n" +
                            commandHelp+": Displays this text. Again!\n" +
                            commandExit+": Closes the application.";



        static void Main(string[] args)
        {
            int n;
            string s;
            Lib.SortBy sortScheme;


            string[] input;
            Library lib = new Library();

            Console.WriteLine(welcomeString);

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
                    case commandSort:

                        if (Option(input, flagSort))
                        {
                            if (Option(input, flagSort, sortAlpha))
                            {
                                sortScheme = SortBy.Alphabetical;
                            }
                            else if (Option(input, flagSort, sortNumRev))
                            {
                                sortScheme = SortBy.NumReviews;
                            }
                            else if (Option(input, flagSort, sortScore))
                            {
                                sortScheme = SortBy.Score;
                            }
                            else
                            {
                                Option(input, flagSort, out s);
                                Console.WriteLine(errorFlagArgInval + ": " + s);
                                break;
                            }
                        } else
                        {
                            sortScheme = SortBy.Score;
                        }

                        if (Option(input, flagTopN, out n))
                        {
                            Display(lib.Sort(sortScheme, Option(input, flagAsc), n));
                        }
                        else
                        {
                            Display(lib.Sort(sortScheme, Option(input, flagAsc)));
                        }

                        break;

                    case commandSearch:
                        if (input.Length < 2)
                        {
                            Console.WriteLine(errorArgNumInval);
                            break;
                        }
                        try
                        {
                            Display(lib.Search(RemoveFirst(input)));
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine(errorNoFind);
                        }
                        break;

                    case commandDetails:
                        if (input.Length != 2)
                        {
                            Console.WriteLine(errorArgNumInval);
                            break;
                        }

                        try
                        {
                            Display(lib.RestLookup(input[1]));

                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine(errorNoFind);
                        }
                        break;

                    case commandReviews:
                        if (input.Length != 2)
                        {
                            Console.WriteLine(errorArgNumInval);
                            break;
                        }

                        try
                        {
                            Display(lib.RestLookup(input[1]).GetReviews());

                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine(errorNoFind);
                        }
                        break;

                    case "?":
                    case "??":
                    case "???":
                    case commandHelp:
                        Console.WriteLine(helpString);
                        break;

                    case "bye":
                        Console.WriteLine("Goodbye.");
                        return;
                    case "leave":
                    case "close":
                    case "quit":
                    case commandExit:
                        return;

                    default:
                        Console.WriteLine(unrecognizedCommand);
                        break;
                }
            }
        }

        private static string[] ParseInput(string s)
        {
            List<string> output = new List<string>();
            string[] quoteSplit = s.Split('"');

            if (quoteSplit.Length % 2 == 1)
            {

                for (int i = 0; i < quoteSplit.Length; i += 2)
                {
                    output.AddRange(quoteSplit[i].Split());
                    if (i < quoteSplit.Length - 1)
                    {
                        output.Add(quoteSplit[i + 1]);
                    }
                }

                for (int i = 0; i < output.Count(); i++)
                {
                    output[i] = output[i].Replace(' ', '_');
                }

                return output.ToArray();

            }
            else
            {
                return s.Split();
            }
        }

        private static void Display(Restaurant[] results)
        {
            Console.WriteLine("Name\tScore");
            Console.WriteLine("--------------");
            foreach (Restaurant r in results)
            {
                Console.WriteLine(r.Name + "\t" + r.AvgScore);
            }
        }

        private static void Display(Review[] results)
        {
            Console.WriteLine("Score:");
            foreach (Review r in results)
            {
                Console.WriteLine(r.Score);
            }
        }

        private static void Display(Restaurant result)
        {
            Console.WriteLine("Name\tScore\tReviews");
            Console.WriteLine("----------------------------");
            Console.WriteLine(result.Name + "\t" + result.AvgScore + "\t" + result.GetReviews().Count());
        }

        private static void Display(Review result)
        {
            Console.WriteLine("Score: " + result.Score);
        }


        private static bool Option(string[] input, string flag, out int value)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == flag)
                {
                    return int.TryParse(input[i + 1], out value);
                }
            }

            value = 0;
            return false;
        }

        private static bool Option(string[] input, string flag, out string value)
        {
            for(int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == flag)
                {
                    value = input[i + 1];
                    return true;
                }
            }

            value = "";
            return false;
        }

        private static bool Option(string[] input, string flag, string value)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == flag && input[i + 1] == value)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool Option(string[] input, string flag)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == flag)
                {
                    return true;
                }
            }

            return false;
        }


        private static string[] RemoveFirst(string[] input)
        {
            string[] output = new string[input.Length - 1];

            for(int i = 1; i < input.Length; i++)
            {
                output[i - 1] = input[i];
            }

            return output;
        }
    }
}
