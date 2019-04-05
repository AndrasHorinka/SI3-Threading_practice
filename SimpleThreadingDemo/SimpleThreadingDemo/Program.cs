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
        }


        public static void Counting()
        {
            int countLimit = 10;
            for (int i = 0; i < countLimit; i++)
            {
                Console.WriteLine("Thread: {}, Count {}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}
