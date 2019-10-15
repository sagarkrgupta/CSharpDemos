using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate1
{
    class Program
    {

        delegate void NumberChanger(int n);

        static void Main(string[] args)
        {
            Single_Delegate();
            Multiple_Delegate();
        }

        static void Single_Delegate()
        {
            //create delegate instances
            NumberChanger nc1 = new NumberChanger(SampleClass.AddNum);
            NumberChanger nc2 = new NumberChanger(SampleClass.MultiNum);

            //calling the methods using the delegate objects
            Console.WriteLine("Single Delegate, Demo");
            nc1(25);
            Console.WriteLine("Value of Num: {0}", SampleClass.GetNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", SampleClass.GetNum());
            Console.ReadKey();
        }

        static void Multiple_Delegate()
        {
            //create delegate instances
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(SampleClass.AddNum);
            NumberChanger nc2 = new NumberChanger(SampleClass.MultiNum);


          

            //calling multicast
            Console.WriteLine("Single Delegate, Demo");
            nc = nc1;
            nc(25);
            Console.WriteLine("Value of Num: {0}", SampleClass.GetNum());

            nc += nc2;
            nc(5);
            Console.WriteLine("Value of Num: {0}", SampleClass.GetNum());


            Console.ReadKey();

        }
    }

    
}
