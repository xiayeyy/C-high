using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件
{
    class Program
    {
        public delegate void Mydelegate();
        event   Mydelegate de1;   //委托类型变量，作为类的成员   事件

        static void Main(string[] args)
        {
            Program p = new Program();
            p.de1 = Test1;
            p.de1();
            Console.ReadKey();
        }

        static void Test1()
        {
            Console.WriteLine("test1");
        }
    }
}
