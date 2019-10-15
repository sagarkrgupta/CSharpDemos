using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace AsyncDemo
{
    class Program
    {
       
        static void Main(string[] args)
        {
            bool exit = false;
            
            while (!exit)
            {
                Clear();

                WriteLine("Displaying Menu....");
                WriteLine("1) Execute Sync Method ");
                WriteLine("2) Execute Async Method ");
                WriteLine("3) Execute Parallel Async Method (1500 milisecond )");
                WriteLine("0) Exit ");
                WriteLine("++++++++++++++++++++++++++++++++++++++++ ");

                var selection = ReadLine();

                if (string.IsNullOrEmpty(selection))
                    continue;
                
                int choice = Int32.Parse(selection);

                switch (choice)
                {
                    case 1:
                        Call_SyncMethod();
                        break;
                    case 2:
                        Call_AsyncMethod();
                        break;
                    case 3:
                        Call_ParallelAsyncMethod();
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        break;
                }



            }

           
        }

        private static void Call_SyncMethod()
        {


            Sync sync = new Sync();
            sync.IntialCall(); // min time= 31xx milisecond

            ReadKey();
        }

        private static async Task Call_AsyncMethod()
        {
            Async async = new Async();

           await async.IntialCallAsync();
            ReadKey();
        }
        private static async Task Call_ParallelAsyncMethod()
        {
            ParallelAsync async = new ParallelAsync();

            await async.IntialCall_ParallelAsync();
            ReadKey();
        }
        

    }
}
