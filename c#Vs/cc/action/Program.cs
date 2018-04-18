using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace action
{
    class Program
    {
        static void PrintString()
        {
            Console.WriteLine("Action");
        }

        static void PrintString(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            Action<string> a = PrintString;  //定义一个没有返回值的 委托 方法重载时系统会自动寻找匹配的方法
            a("asdasdasd");
            Console.ReadKey();
        }
    }
}
