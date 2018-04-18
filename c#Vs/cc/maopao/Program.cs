using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maopao
{
    class Program
    {

        static void sort(int[] myarry)
        {
            bool right;
            do
            {
                right = false;
                for (int i = 0; i < myarry.Length - 1; i++)  //冒泡排序
                {
                    if (myarry[i] > myarry[i + 1])
                    {
                        int term = myarry[i + 1];
                        myarry[i + 1] = myarry[i];
                        myarry[i] = term;
                        right = true;
                    }
              }
            }
            while (right == true);

        }

        static void Compare<T>(T[] tarry , Func <T,T,bool > method)
        {
            bool right;
            do
            {
                right = false;
                for (int i = 0; i < tarry.Length - 1; i++)  //冒泡排序
                { 
                    if (method(tarry[i] ,tarry[i + 1]))
                    {
                        T term = tarry[i + 1];
                        tarry[i + 1] = tarry[i];
                        tarry[i] = term;
                        right = true;
                    }
                }
            }
            while (right == true);
        }

        static void Main(string[] args)
        {
            //  int[] myarry = new int[] { 156, 68544, 632, 21654, 85, 5, 163, 35, 654, 45, 5, 64354 };
            //  sort(myarry);

            //  foreach (var temp in myarry)
            //  {
            //      Console.Write(temp + " ");
            //   }   
            Employ[] em = new Employ[] { new Employ ("as",465), new Employ("ass", 15), new Employ("a1s", 46585), new Employ("aass", 4675), };
            Compare<Employ>(em, Employ.Compare);
            foreach (Employ em1 in em)
            {
                Console.Write(em1.ToString () + "|");
            }
            Console.ReadKey();
        }
    }
}
