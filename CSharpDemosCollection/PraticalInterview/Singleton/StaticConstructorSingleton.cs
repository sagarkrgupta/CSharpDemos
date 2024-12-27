using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton
{
    //Static Constructor Singleton
    internal sealed class StaticConstructorSingleton
    {
        static StaticConstructorSingleton()
        {
            _instance = new StaticConstructorSingleton();
        }
        private StaticConstructorSingleton() { }

        private static readonly StaticConstructorSingleton _instance;


        public static StaticConstructorSingleton Instance => _instance;
    }

    /*
     * Key Points:
Thread-Safe: Yes (CLR guarantees thread safety for static constructors).
Lazy Initialization: No.
Best For: Simple scenarios where eager initialization is acceptable.

     */
}
