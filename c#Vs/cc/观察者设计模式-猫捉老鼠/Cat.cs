using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者设计模式_猫捉老鼠
{/// <summary>
/// 
/// </summary>
    class Cat
    {
        private  string Name;
        private  string Color;
        public Cat(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        //被观察者状态发生改变
        //public void Catcoming(Mouse mouse1,Mouse mouse2 )
        //{
        //    Console.WriteLine(Color + "颜色的" + Name + "过来了");
        //    mouse1.Mouserun();
        //    mouse2.Mouserun();
        //}

        public void Catcoming()
        {
            Console.WriteLine(Color + "颜色的" + Name + "过来了");
            //CatCome?.Invoke();
            if (CatCome != null)
            {
                CatCome();
            }
    
        }
        //public Action CatCome;
        public event  Action CatCome;  //声明一个事件 ,不能通过对象调用，不能在类的外部触发
    }
}
