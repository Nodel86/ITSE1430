using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ITSE-1430
/*
*
* 
* 
* 
//Ashton Harris
*/

namespace AshtonHarris.MovieLib.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                //Equality
                bool isEqual = quit.Equals(10);
                //Display menu
                char choice = DisplayMenu();

                //Process menu selection
                switch (Char.ToUpper(choice))
                {
                    // case 'l':
                    case 'L':
                        ListMovie();
                        break;

                    //case 'a':
                    case 'A':
                        AddMovie();
                        break;

                    //case 'r'
                    case 'R':
                        RemoveMovie();
                        break;

                    // case 'q':
                    case 'Q':
                        quit = true;
                        break;
                };
            };
        }

         //Add a movie
            static void AddMovie()
        {
            //Get Movie Name
            _name = ReadString("Enter name: " true);

            //Get description
            _description = Readstring("Enter optional description: ", false);

        }

        //List Movie
        static void ListMovie()
        {
            if (!String.IsNullOrEmpty(_name))
            {
                var msg = _name;

                string msg = _name;
                Console.WriteLine(msg);

                if (!String.IsNullOrEmpty(_description))
                    Console.WriteLine(_description);
            }
            else
                Console.WriteLine("No movies");
        }

        //Data for a product
        static string _name;
        static string _description;
    };
    //Read String
    private static string ReadString(string message, bool isRequired)
    {
        do
        {
            Console.Write(message);

            string value = Console.ReadLine();

            if (!isRequired || value != "")
                return value;

            Console.WriteLine("Value is required");
        } while (true);

        //Read a Decimal
        private static decimal ReadDecimal(string message, decimal minValue )
    {
        do
        {
            Console.Write(message);

            string value = Console.ReadLine();

            if (Decimal.TryParse(value, out decimal results))
            {
                if (results >= minValue)
                    return results;
            };

            string msg = String.Format("Value must be >={0}", minValue);
            Console.WriteLine("Value must be >= {0}", minValue);
        } while (true);

       
        }
        //Display Menu
        private static char DisplayMenu()
        {
            do
            {
                Console.WriteLine("L)ist Movie");
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("R)emove Movie");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();

                input = input.Trim();
                input = input.ToUpper();

                if (String.Compare(input, "L", true) == 0)
                    return input[0];
                else if (input == "A")
                    return input[0];
                else if (input == "R")
                    return input[0];
                else if (input == "Q")
                    return input[0];

                Console.WriteLine("Please choose a valid option");
            } while (true);


    
    }

    }
}
