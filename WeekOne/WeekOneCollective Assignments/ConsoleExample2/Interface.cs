using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample2
{

    interface IIinterface

    {
        void method1();
        void method2();
    }

    interface IInterface2
    {
        void method1();
        void method2();
    }
    public class MyClass : IIinterface  ,IInterface2
        {
            public void method1()
            {
                Console.WriteLine("This is method 1 ");
            }

            public void method2()
            {
                Console.WriteLine("This is method 2 ");
            }

        void IInterface2.method1()
        {
            Console.WriteLine("This is method 1 from IIinterface2");
        }

        void IInterface2.method2()
        {
            Console.WriteLine("This is method  from IIinterface2");
        }

    }



        //// Boxing is the process of converting value type into reference type. (implicitly)

        //int c = 100;
        //object abj = a;

        //Console.WriteLine(abj);

        //        // UnBoxing is the process of converting value type into reference type. (implicitly)

        //        object obj = 2000;
        //int n = (int)obj;

        //Console.WriteLine(b);
    }

