using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton
{
    public sealed class MySingleton
    {
        // Private constructor to prevent external instantiation
        private MySingleton() { }

        private static  MySingleton instance;
        private static readonly object lockObject = new object();

        public static MySingleton Instance {
            get
            {
                if (instance == null)
                {
                    lock (lockObject) 
                    {
                        if (instance == null)
                        {
                            instance = new MySingleton();
                        }
                    }
                    
                }

                return instance;
            }
        }
    }
}
