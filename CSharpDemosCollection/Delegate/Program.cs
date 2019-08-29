using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        public delegate void addnum(int a, int b);
        public delegate void subnum(int a, int b);


        public delegate void rectDelegate(double height, double width);



        static void Main(string[] args)
        {

            SomeClass d1 = new SomeClass();

            //For ssingle delegate
            // creating object of delegate, name as "del_obj1"  
            addnum del_obj1 = new addnum(d1.AdditionFN);
            subnum del_obj2 = new subnum(d1.SubtractionFN);

            // pass the values to the methods by delegate object 
            del_obj1(100, 40);
            del_obj2(100, 60);

            Console.ReadKey();

            Console.WriteLine();

            //For ssingle delegate




            // For MultiCasst Delegate

            // creating delegate object, name as "rectdele" 
            // and pass the method as parameter by  
            // class object "rect" 
            rectDelegate rectdele = new rectDelegate(d1.area);
            //or
            // rectDelegate rectdele1 = d1.area;

            // call 2nd method "perimeter" 
            // Multicasting 

            rectdele += d1.perimeter;

            // pass the values in two method  
            // by using "Invoke" method 
            rectdele.Invoke(6.3, 4.2);
            Console.WriteLine();

            // call the methods with
            // different values 
            rectdele.Invoke(16.3, 10.3);

            Console.ReadKey();
        }
    }
}
