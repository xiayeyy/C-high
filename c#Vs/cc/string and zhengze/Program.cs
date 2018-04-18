using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_and_zhengze
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "这是.一个.字符串";
            string d = "  sasdasdas  ";
            int slength = s.Length;
           

            char a = s[3];

            // Console.Write(a);
            int res = s.CompareTo("assa"); //逐位判断，0代表相等 ，s靠前返回-1；否则返回1
            string s1= s.Replace("这", "1111");  //替换指定字符或字符串,但对原字符串不产生影响
            string[] s2arry = s.Split('.');// 指定字符，把字符串拆分为数组
            foreach (var temp in s2arry)
            {
               // Console.WriteLine(temp);
            }

            string s3 = s.Substring(3, 5); //输出低3位之后5个字符，不给定长度则输出之后所有

            // string s4 = d.ToLower(); //将字符串变为小写
            string s4 = d.ToUpper ();  //将字符串变为大写

            string s5 = d.Trim();  //删除首尾的空白,玩家注册用户名

            int index = s.IndexOf("一个"); //输出包含 子字符串的序号，不存在返回-1

            string s6 = s.Insert(3, "输出包含 子字符串的序号"); //指定位置插入

            Console.WriteLine(s6);
            Console.ReadKey();
        }
    }
}
