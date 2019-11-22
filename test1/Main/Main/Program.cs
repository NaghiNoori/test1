using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeStamp t1 = new TimeStamp();
            TimeStamp t2 = new TimeStamp();
            int someSeconds;
            /*******************************************/
            Console.Write("Please enter some _seconds to convert: ");
            someSeconds = GetPositiveIngter("Error: Please enter positive number ", 0); //You need to write this method
            Console.Write("{0} _seconds converted to TimeStamp = {1}\n", someSeconds,
            t1.ConvertFromSeconds(someSeconds));
            /*******************************************/
            Console.WriteLine("Console Data Load - Use class console method");
            t1.ReadFromConsole();
            Console.Write("{0} in _seconds is: {1} seconds.\n\n", t1, t1.ConvertToSeconds());
            /*******************************************/
            Console.Write("Please enter the number of seconds to add to {0}:", t1);
            someSeconds = GetPositiveIngter("Error: Please enter positive number ", 0);
            Console.Write(t1 + "{0} + {1} seconds = ", t1, someSeconds);
            t1.AddSeconds(someSeconds);
            Console.Write(t1 + "\n\n");
            /*******************************************/
            Console.WriteLine("Static Method Test");
            Console.WriteLine("Please enter a TimeStamp");
            t1.ReadFromConsole();
            Console.WriteLine("\n");
            Console.WriteLine("Please enter another TimeStamp");
            t2.ReadFromConsole();
            //Using static method
            Console.WriteLine("\nUsing static method: {0} + {1} = {2}", t1, t2, TimeStamp.AddTwoTimeStamps(t1, t2));

            Console.ReadKey();
        }

        static int GetPositiveIngter(string errorMessage, int min)
        {
            int input;
            bool validInput;
            validInput = int.TryParse(Console.ReadLine(), out input);
            while (validInput == false || input < min)
            {
                Console.WriteLine(errorMessage);
                validInput = int.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

    }
}
