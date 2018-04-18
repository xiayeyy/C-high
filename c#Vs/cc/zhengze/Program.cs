using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zhengze
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Nothing is  true ,everything  is  promitted";

           // string res = Regex.Replace(s, "^", "开始");  //定位元字符 ^ 开头
            string res = Regex.Replace(s, "$", "结束"); //定位元字符 $ 开头

            string ss = Console.ReadLine();
            //for (int i=0; i<s.Length;i++)
            //{
            //    if (ss[i] < '0' || ss[i] > '9')
            //    {
            //        Console.Write("非数字");
            //        Console.ReadKey();
            //        break;

            //    }
            //    else
            //    {
            //        Console.Write("数字");
            //        Console.ReadKey();
            //    }
            //}

            // string pattern = @"^\d*$";  //正则表达式  数字字符串 ^开头 * 0个或多个 $结尾 \d数字
            //string pattern = @"^\w*$";  //正则表达式  字符串 ^开头 * 0个或多个 $结尾 \w 数字 字母 下划线
            // [abc] 匹配[]里的字符  ，[^abc] 匹配abc之外的字符
            //  /W  /D 补集   | 择一匹配
            //string pattern = @"^\d{5,12}$";  //{}重复描述字符  QQ 号5-12位
            string pattern = @"(ab\w{2}){2}";  // 使用()进行分组 ab/wab/w 
            bool ismatch= Regex.IsMatch(ss, pattern);  //判断ss是否符合表达式

            //string cc = Regex.Replace(ss, pattern, "!");
            string cc = Regex.Replace(ss, pattern, "!");

            Console.Write(ismatch);
            Console.ReadKey();
        }
    }
}
