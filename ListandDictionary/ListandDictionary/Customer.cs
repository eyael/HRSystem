using System;
using System.Collections.Generic;
using System.Text;

namespace ListandDictionary
{
    class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string mobile { get; set; }

        public void userInfo()
        {
            Console.WriteLine("Enter your ID");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your name");
            name = Console.ReadLine();

            Console.WriteLine("Enter your adress");
            adress = Console.ReadLine();

            Console.WriteLine("Enter your mobile");
            mobile = Console.ReadLine();
        }
    }
}
