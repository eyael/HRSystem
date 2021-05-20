using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleExample2.patient;

namespace ConsoleExample2
{
    class Program
    {
        static void Main(string[] args)
        {

            CollectionExample col = new CollectionExample();
            col.myMethod();

            MyClass c = new MyClass();
            c.method1();
            c.method2();

            IInterface2 inter = new MyClass();
            inter.method1();
            inter.method2();



            bool check = true;

            string chcker = "dotnet application is fun";

            check = chcker.Contains("dotnet");

            Console.WriteLine(check);


           

            int w = 9;
            int x = 10;
            int y = 3;
            int z = x % y;
            int zz = w / y;

            Console.WriteLine(z); // 1 modules 
            Console.WriteLine(zz); // with no reminder 

            Console.ReadLine();

            int a = 100;
            int? b = null;

            if (b == null)
                a = 0;
            else
                a = b.Value;

            a = b ?? 0;

            Console.WriteLine(a);



            //Ternary Operater 

            int f = 10; int g = 8;

            var result = f < g ? "Your result should be negative " : "you r right ";

            Console.WriteLine(result);
            Console.ReadLine();

            float marks = 10.9f;

            int mymarks = 10;

            mymarks = Convert.ToInt32(marks);
            Console.WriteLine(mymarks);
            Console.ReadLine();

            Console.Write("please enter your age ");

            byte age = 0;
            try
            {
                age = byte.Parse(Console.ReadLine());
                Console.WriteLine($"you are {age} enter your age ");

            }

            catch
            {
                Console.WriteLine("You need to wirte numeral ");
            }

            

            int[] myArray = { 1, 2, 3, 4, 5 };

            for (int h = 0; h < myArray.Length; h++)

            {
                Console.WriteLine(h);
            }

            

            Console.WriteLine("Which city you like most");
            string userCity = Console.ReadLine();

            switch (userCity)
            {
                case "New York":
                    Console.WriteLine("Welcome to New York");
                    break;
                case "Los Angeles":
                    Console.WriteLine("Welcome to Los Angeles");
                    break;
                case "Illinois":
                    Console.WriteLine("Welcome to Illinois");
                    break;
                default:
                    Console.WriteLine("Enter a city ");
                    break;
            }
            Console.ReadLine();



            

                int maxNumber = 10;
                int previousNumber = 0;
                int nextNumber = 1;

                Console.WriteLine("Fibonacci Series of " + maxNumber + " numbers:");

                int i = 1;
                while (i <= maxNumber)
                {
                    Console.WriteLine(previousNumber + " ");
                    int sum = previousNumber + nextNumber;
                    previousNumber = nextNumber;
                    nextNumber = sum;
                    i++;
                }
                Console.ReadLine();


                int? totalTicket = null;
                int availableTickt = 0;
                if (totalTicket == null)

                    availableTickt = 0;
                else
                    availableTickt = (int)totalTicket;

                availableTickt = totalTicket ?? 0;



                int choise = 0;

                Console.WriteLine("Please enter your choise ");

                // bool check = int.TryParse(Console.ReadLine(), out choise);

                if (check == true)
                    Console.WriteLine("Good Job");
                else
                    Console.WriteLine("Try again");


                ArrayList arraylist = new ArrayList();
                arraylist.Add(7);
                arraylist.Add("Eyael");
                arraylist.Add(10.3);
                arraylist.Add(true);

                //foreach (object i in arraylist)
                //{
                //    Console.WriteLine(i);
                //}

               

            

          
            int nexnum = 0;
            int prvnum = 1;

            Console.WriteLine("Fibonacci Series of " + 10 + " numbers:");

            int p = 1;
            while (p <= 10)
            {
                Console.WriteLine(previousNumber + " ");
                int sum = previousNumber + nextNumber;
                previousNumber = nextNumber;
                nextNumber = sum;
                i++;
            }

            int k = 0;
            int l = 1;
            int m = 1;

            Console.WriteLine("1 1");

            while (k <= 50)
            {
                k = l + m;
                Console.WriteLine(k + " ");
                l = m;
                m = k;

            }

            //Dictionary<int, Patient> dictionary = new Dictionary<int, Patient>();
            //dictionary.Add(101, "Tom");
            //dictionary.Add(102, "Eric");
            //dictionary.Add(103, "Sheila");
            //dictionary.Add(104, "Mary");

            //foreach (KeyValuePair<int, string> kvp in dictionary)
            //{
            //    Console.WriteLine(kvp.Key + "|" + kvp.Value);
            //}


            List<Patient> ptlist = new List<Patient>();
            Patient p1 = new Patient();
            p1.id = 101;
            p1.name = "Timothy";
            p1.mobile = "342943943";
            ptlist.Add(p1);
            Patient p2 = new Patient();
            p2.id = 102;
            p2.name = "Dorothy";
            p2.mobile = "777777";
            ptlist.Add(p2);

            foreach (Patient item in ptlist)
            {
                Console.WriteLine(item.id + " | " + item.name + " | " + item.mobile);
            }
           
            Dictionary<int, Patient> dictionary = new Dictionary<int, Patient>();
            Patient p3 = new Patient();
            p1.id = 101;
            p1.name = "Timothy";
            p1.mobile = "342943943";
            dictionary.Add(p1.id, p1);

            Patient p4 = new Patient();
            p2.id = 102;
            p2.name = "Dorothy";
            p2.mobile = "777777";

            dictionary.Add(p2.id, p2);
            foreach (KeyValuePair<int, Patient> kvp in dictionary)
            {
                Console.WriteLine(kvp.Key + " | " + kvp.Value.name + " | " + kvp.Value.mobile);
            }

            Console.ReadLine();
        }





        

        }
    }



            

           

            

          

            

    

