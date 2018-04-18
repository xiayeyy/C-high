using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 匿名方法
{
    class Program
    {
        static int  Test1(int arg1, int arg2)
        {
            return arg1 + arg2;
        }


        static void Main(string[] args)
        {
          //  Func <int ,int, int > plus = Test1;
            Func<int, int, int> plus = delegate ( int a1,int a2){ return a1 + a2; }; //匿名方法，会省代码，多用于回调。


            Console.WriteLine(plus(10,50));

            Console.ReadKey();
        }
    }
}
