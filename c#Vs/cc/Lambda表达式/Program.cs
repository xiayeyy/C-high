using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda表达式
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> plus =  (a1,a2)=> { return a1 + a2; }; // Lambda表达式参数不用声明类型，代替匿名方法
            Func<int,int> plus2 = a3 => a3+1;  //当参数只有一个时可以简写，函数体只有一句时

            //Console.WriteLine(plus(100, 50));
            Console.WriteLine(plus2( 50));

            Console.ReadKey();
        }
    }
}
