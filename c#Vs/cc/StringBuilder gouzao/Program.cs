using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_gouzao
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder sb = new StringBuilder("ssaasad");
            // 方便对一个字符串进行频繁的操作
            StringBuilder sb = new StringBuilder("ssaasad",20); //初始化新的字符串初始值，长度超过原来长度后会自动申请新的内存，长度为原来两倍 
            sb.Append("新的字符串");
            sb.Remove(0, 5);

            // string s1 = sb.ToString();
            //sb.Replace("a", "");
            // Console.Write(s1);
            sb.Remove(0, 3);  // 移除序号，长度

            Console.Write(sb);

            Console.ReadKey();

        }
    }
}
