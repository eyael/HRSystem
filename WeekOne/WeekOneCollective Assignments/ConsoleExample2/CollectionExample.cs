using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample2
{
    class CollectionExample

    {
        public void myMethod()
        {
            // peek, pop, push

            Stack<int> Marks = new Stack<int>();
            Marks.Push(100);
            Marks.Push(200);
            Marks.Push(300);
            Marks.Push(400);
            Console.WriteLine(Marks.Peek());
            Console.WriteLine(Marks.Pop());
            Console.WriteLine(Marks.Peek());

            int count = 4;

            foreach (var item in Marks)
            {
                Console.WriteLine(item);
            }


            // peek, dequeue, enqueue

            Queue<string> Countries = new Queue<string>();

            Countries.Enqueue("USA");
            Countries.Enqueue("Japan");
            Countries.Enqueue("India");
            Countries.Enqueue("Australia");
            Console.WriteLine(Countries.Peek());
            Console.WriteLine(Countries.Dequeue());
            Console.WriteLine(Countries.Peek());

            foreach (var item in Countries)
            {
                Console.WriteLine(item);
            }

            

           Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(101, "Tom");
            dictionary.Add(102, "Eric");
            dictionary.Add(103, "Sheila");
            dictionary.Add(104, "Mary");
            foreach(KeyValuePair<int, string> kvp in dictionary)
            {
                Console.WriteLine(kvp.Key + "|" + kvp.Value);
            }


        }
    }



}
