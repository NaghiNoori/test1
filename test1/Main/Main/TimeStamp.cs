using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class TimeStamp
    {
        // Fields
        private int _hours;
        private int _minutes;
        private int _seconds;
        private const int MIN_TIME = 0;
        private const int MAX_TIME = 59;
        // Properties
        public int Hours
        {
            get
            {
                return _hours;
            }

            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be negative", "Hours");
                _hours = value;
            }
        }

        public int Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Minutes cannot be negative", "Minutes");
                /*else if (value > MAX_TIME)
                {
                    throw new ArgumentException("Minutes exceeded Max Value");
                }*/
                _minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Seconds cannot be negative", "Seconds");
                else if (value > MAX_TIME)
                {
                    throw new ArgumentException("Seconds exceeded Max Value");
                }
                _seconds = value;
            }
        }

        // Constructor
        public TimeStamp()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }

        // Methods
        public TimeStamp ConvertFromSeconds(int SecondsToConvert)
        {
            Hours = SecondsToConvert / 3600;
            SecondsToConvert %= 3600;
            Minutes = SecondsToConvert / 60;
            SecondsToConvert %= 60;
            Seconds = SecondsToConvert;
            return this;
        }

        public int ConvertToSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }

        public void AddSeconds(int TheSeconds)
        {
            TheSeconds += ConvertToSeconds();
            ConvertFromSeconds(TheSeconds);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}: {2}\n", Hours, Minutes, Seconds);
        }

        public void ReadFromConsole()
        {
            Console.WriteLine("Please enter number of hours ");
            GetValue("Error! hours cannot be negative ", 0);
            Console.WriteLine("Please enter number of minutes ");
            GetValue("Error! Please enter a number between 0..59 ", MIN_TIME, MAX_TIME);
            Console.WriteLine("Please enter number of seconds ");
            GetValue("Error! Please enter a number between 0..59 ", MIN_TIME, MAX_TIME);
            

        }

        private int GetValue(string errorMessage, int min, int max = int.MaxValue)
        {
            int input;
            bool validInput;
            validInput = int.TryParse(Console.ReadLine(), out input);
            while (validInput == false || input < min || input > max)
            {
                Console.WriteLine(errorMessage);
                validInput = int.TryParse(Console.ReadLine(), out input);
            }

            return input;
        }

        static public TimeStamp AddTwoTimeStamps(TimeStamp TimeStampOne, TimeStamp TimeStampTwo)
        {
            TimeStamp t3 = new TimeStamp();
            int secs = TimeStampOne.ConvertToSeconds() + TimeStampTwo.ConvertToSeconds();
            return t3.ConvertFromSeconds(secs);
        }
    }
}
