using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func
{
    class Program
    {
        static int test(int i)
        {
            return i+1;
           
        }
        static void Main(string[] args)
        {
            Func<int, int> a = test;   //func 后 第一个为参数类型，最后一个为返回值类型

           Console.WriteLine(a(50));
            Console.ReadKey();
        }
    }
}
