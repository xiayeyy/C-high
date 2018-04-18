using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weituo
{

    class Program
    {
        // private delegate string GetString();

     static   void Main(string[] args)
        {

            // int x = 40;
            // GetString a = x.ToString;
            // string s = a();       //常用的初始化和调用
            // Console.WriteLine(s);

            Printstring method = method1;
            pringstr(method);
           // method += method1;
            Console.ReadKey();
        }
        private delegate void Printstring();




        static void pringstr(Printstring print)
        {
            print();
        }

        static void method1()
        {
            Console.WriteLine("method1");
        }



    }
}