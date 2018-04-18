using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duoboWeituo
{
    class Program
    {
        static void Test1()
        {
            Console.WriteLine("Test1");
        }

        static void Test2()
        {
            Console.WriteLine("Test2");
        }

        static void Main(string[] args)
        {  
            Action a = Test1;   

            a += Test2;   //多播委托  ,a既指向test1，又指向test2
            a -= Test1; //去掉

            a();  //当一个委托没有指向任何方法的时候，应用会出现空指针异常
            Console.ReadKey();
        }
    }
}
