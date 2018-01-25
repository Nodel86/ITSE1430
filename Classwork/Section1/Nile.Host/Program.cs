using System;
using System.Collections;



namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
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
           static void PlayingWithVariables()..
        

      
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
