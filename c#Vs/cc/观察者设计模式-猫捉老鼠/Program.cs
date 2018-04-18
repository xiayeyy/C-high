using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者设计模式_猫捉老鼠
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Tom", "黄");
            Mouse mouse1 = new Mouse("Jerry", "白",cat);
            Mouse mouse2 = new Mouse("Jim", "灰",cat);

           // cat.CatCome += mouse1.Mouserun;
           // cat.CatCome += mouse2.Mouserun;
            cat.Catcoming();

            // cat.Catcoming(mouse1 ,mouse2 );
            Console.ReadKey();
        }
    }
}
