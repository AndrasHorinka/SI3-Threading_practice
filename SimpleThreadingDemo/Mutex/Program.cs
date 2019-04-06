using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mutexName = "RUNMEONLYONCE";
            Mutex mutex = new Mutex(false, mutexName);
            mutex = null;

            while (true)
            {
                try
                {
                    mutex = Mutex.OpenExisting(mutexName);
                    mutex.ReleaseMutex();
                }
                catch (WaitHandleCannotBeOpenedException e)
                {
                    Console.WriteLine(e.ToString());
                    mutex = Mutex.OpenExisting(mutexName);
                }
            }


        }
    }
}
