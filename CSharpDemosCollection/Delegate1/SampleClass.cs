using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate1
{
   public class SampleClass
    {
        delegate void NumberChanger(int n);
        public static int num = 10;

        public static void AddNum(int x)
        {
            num += x;
        }

        public static void MultiNum(int x)
        {
            num *= x;
        }
        public static int GetNum()
        {
            return num;
        }

        public static void Run()
        {
          
        }

    }
}
