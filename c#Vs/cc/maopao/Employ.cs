using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maopao
{
    class Employ
    {
        public string Name { get; private set; }
        public float Money { get; private set; }

        public Employ(string name, float money)
        {
            this.Name = name;
            this.Money = money;
        }

        public static  bool Compare(Employ e1, Employ e2)
        {
            if (e1.Money < e2.Money)
            {
                return false;
            }
            else return true;
        }

        public override string ToString()
        {
            return Name + ":" + Money;
        }
    }
}
