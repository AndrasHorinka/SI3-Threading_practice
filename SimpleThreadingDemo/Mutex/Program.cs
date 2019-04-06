using System;
using System.Threading;

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
                    Console.WriteLine("test");
                    //mutex.ReleaseMutex();
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
