using System;
using System.Collections;



namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            while (!quit)
            {
                //Display menu
                char choice = DisplayMenu();

                //Process menu selection
                switch (choice)
                {
                    // case "l":
                    case 'L':
                    ListProducts();
                    break;

                    case 'a':
                    case 'A':
                    AddProduct();
                    break;

                    case 'q':
                    case 'Q':
                    quit = true;
                    break;
                };
            };
        }

        static void AddProduct()
        {
            //Get name
            _name = ReadString("Enter name:", true);

            //Get Price
            _price = ReadDecimal("Enter price:", 0);

            //Get description
            _description = ReadString("Enter optional description:", false);

        }
        private static decimal ReadDecimal( string message, decimal minValue )

        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                decimal result;
                //  if (Decimal.TryParse(value, out decimal result))
                {

                    //If not required or not empty
                    //    if (result >= minValue)
                  //  return result;
                };

                Console.WriteLine("Value must be >={0}", minValue);

            } while (true);
        }
        private static string ReadString( string message, bool isRequired )
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();



                //If not required or not empty
                //if (result >= minValue)
                // return result;
                return value;


                // Console.WriteLine("Value must be >={0}", minValue);

            } while (true);
        }

        static void ListProducts()
        {
            //Are there any products?
            if (_name != null && _name != "")
            {

                //Display a product
                Console.WriteLine(_name);
                Console.WriteLine(_price);
                Console.WriteLine(_description);
            } else
                Console.WriteLine("No products");
        }

        //Data for a product
        static string _name;
        static decimal _price;
        static string _description;


        private static char DisplayMenu()
        {
            do
            {
                Console.WriteLine("L)ist Products");
                Console.WriteLine("A)dd Products");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();

                if (input == "L" || input == "l")
                    return input[0];
                else if (input == "A")
                    return input[0];
                else if (input == "Q")
                    return input[0];

                Console.WriteLine("Please choose a valid option");
            } while (true);

        }


        static void PlayingWithPrimitives()
        {
            //Primitive
            decimal unitPrice = 10.5M;

            //Real decalaration
            System.Decimal unitPrice2 = 10.5M;

            //Current
            System.DateTime now = System.DateTime.Now;

            System.Collections.ArrayList items;

        }
        static void PlayingWithVariables()

        {

            //Single decls
            int hours = 0;
            //Don't
            //int hours;
            //hours =0;
            double rate = 10.25;

            if (false)
                hours = 0;

            int hours2 = hours;

            //Multiple decls
            string firstName, lastName;

            //string @class;

            //Single assignment
            firstName = "Bob";
            lastName = "Miller";

            // Multiple assignment
            firstName = lastName = "Sue";

            //Math ops
            int x = 0, y = 10;
            int add = x + y;
            int subtract = x - y;
            int multiply = x * y;
            int divide = x / y;
            int modulous = x % y;

            //x = x + 10;
            x += 10;
            double ceiling = Math.Ceiling(rate);
            double flooor = ceiling;
        }



    }
}

