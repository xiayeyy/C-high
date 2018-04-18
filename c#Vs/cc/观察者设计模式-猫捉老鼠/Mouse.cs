using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者设计模式_猫捉老鼠
{
    class Mouse
    {
        private string Name;
        private string Color;

        public Mouse(string name, string color, Cat cat)
        {
            this.Name = name;
            this.Color = color;
            cat.CatCome += Mouserun;
        }

        public void Mouserun()
        {
            Console.WriteLine(Color + "颜色的" + Name + "说大家快跑！！");
          

        }

    }

}
