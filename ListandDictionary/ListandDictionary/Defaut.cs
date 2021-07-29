using System;
using System.Collections.Generic;
using System.Text;

namespace ListandDictionary
{
    class Defaut
    {

        // If we have to give the value in the parameter here we dont really
        // have to instanciate it in the main
        public void info(int regno, float salary, string ssn = "Not Available")
        {
            Console.WriteLine("Hello world");

        }

        public Defaut(int x = 100)
        {

        }

        public Defaut()
        {

        }
    }
}
