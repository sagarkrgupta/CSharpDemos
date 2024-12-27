using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton
{
    //Thread-Safe Singleton (Double-Check Locking)
    internal class ThreadSafeSingleton
    {
        private ThreadSafeSingleton() { }

        private static ThreadSafeSingleton _instance = null;
        private static readonly object lockObj = new object();

        public static ThreadSafeSingleton Instance { 
            get 
            {
                if (_instance is null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ThreadSafeSingleton();
                        }
                    }
                }
                return _instance; 
            } 
        }

    }
    /*
     * Key Points:
     * Thread-Safe: Yes (using lock).
     * Lazy Initialization: Yes.
     * Best For: Scenarios requiring manual control over thread safety.
     */
}
