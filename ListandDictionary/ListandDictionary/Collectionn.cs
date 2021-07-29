using System;
using System.Collections.Generic;
using System.Text;

namespace ListandDictionary
{
    class Collectionn
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

            //int count = 4;

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

            
        

            Dictionary<int, Customer> dictionary = new Dictionary<int, Customer>();
            Customer p1 = new Customer();
            p1.userInfo();
            dictionary.Add(p1.id, p1);

            Customer p2 = new Customer();
            p2.userInfo();

            dictionary.Add(p2.id, p2);
            foreach (KeyValuePair<int, Customer> kvp in dictionary)
            {
                Console.WriteLine(kvp.Key + " | " + kvp.Value.name + " | " + kvp.Value.mobile);
            }


        }
    }
}