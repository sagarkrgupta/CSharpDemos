using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class SomeClass
    {
        
        public void AdditionFN(int x,int y) =>  Console.WriteLine($"Addition of {x} and {y} is : {(x + y)}");
        public void SubtractionFN(int x, int y) => Console.WriteLine($"Subtraction of {x} and {y} is : {(x - y)}");



        // for multicast
        // "area" method 
        public void area(double height, double width) => Console.WriteLine("Area is: {0}", (width * height));
        // "perimeter" method 
        public void perimeter(double height, double width) => Console.WriteLine("Perimeter is: {0} ", 2 * (width + height));
        


    }
}
