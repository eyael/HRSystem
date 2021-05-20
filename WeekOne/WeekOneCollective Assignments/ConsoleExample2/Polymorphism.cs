using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample2
{
    class cars
    {
        public void discount()
        {
            Console.WriteLine("Sorry you dont have discount");
        }
    }

    class HyundaiCivic
    {

    }

    class Maruthi
    {
        public new void discount()
        {
            Console.WriteLine("you got discount");
        }
    }
}
