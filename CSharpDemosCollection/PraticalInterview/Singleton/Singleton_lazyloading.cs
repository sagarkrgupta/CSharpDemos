using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton
{
    //Lazy Initialization Singleton (Thread-Safe with Lazy<T>)
    internal sealed class Singleton_lazyloading
    {
        private Singleton_lazyloading()
        {
            
        }

        
        private static readonly Lazy<Singleton_lazyloading> _lazyInstance = new Lazy<Singleton_lazyloading>(()=> new Singleton_lazyloading());

        public static Singleton_lazyloading Instance { get { return _lazyInstance.Value; } }

        /*
        Key Points:
        Thread-Safe: Yes (handled internally by Lazy<T>).
        Lazy Initialization: Yes (only created when accessed for the first time).
        Best For: Modern C# applications where lazy loading is required.
        */
    }
}
