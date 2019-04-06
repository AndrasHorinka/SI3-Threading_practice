using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback thread = new WaitCallback(ShowMyText);

            try
            {
                ThreadPool.QueueUserWorkItem(thread, "elso text");
                ThreadPool.QueueUserWorkItem(thread, "masodik text");
                ThreadPool.QueueUserWorkItem(thread, "harmadik text");
                ThreadPool.QueueUserWorkItem(thread, "negyedik text");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void ShowMyText(object state)
        {
            string newVariable = (string)state;
            Console.WriteLine(newVariable + " " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
