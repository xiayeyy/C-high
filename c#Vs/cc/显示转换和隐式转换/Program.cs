using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 显示转换和隐式转换
{
    class Program
    {
        static void Main(string[] args)
        {
            byte mybyte = 155;  //byte类型取值在0-255
            int myint = mybyte;  //int 范围大，编译器自动进行隐式转换 
            mybyte = (byte)myint;//强制转换
        }
    }
}
