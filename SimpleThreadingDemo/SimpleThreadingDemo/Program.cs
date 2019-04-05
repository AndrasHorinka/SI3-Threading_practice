using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Counting();
        }


        public static void Counting()
        {
            int countLimit = 10;
            for (int i = 1; i <= countLimit; i++)
            {
                Console.WriteLine("Thread: {0}, Count {1}", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(10);
            }
        }
    }
}
