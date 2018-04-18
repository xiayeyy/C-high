using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaopao
{
    public class Class1
    {
        public string Name { get; private set; }
        public float Money { get; private set; }

        public Class1(string name ,float money)
        {
            this.Name = name;
            this.Money = money;
        }

        public bool Compare(Class1 e1, Class1 e2)
        {
            if (e1.Money > e2.Money)
            {
                return false;
            }
            else return true;
        }
    }
}
