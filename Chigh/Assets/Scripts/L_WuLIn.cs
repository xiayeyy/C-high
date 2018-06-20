
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public  class L_WuLin
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Kongfu { get; set; }
    public int Leave { get; set; }

    public override string ToString()
    {
        return string.Format("ID: {0}, Name: {1}, Age: {2}, Kongfu: {3}, Leave: {4}", ID, Name, Age, Kongfu, Leave);
    }
}

public  class L_KongFu
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Power { get; set; }

    public override string ToString()
    {
        return string.Format("ID: {0}, Name: {1}, Power: {2}", ID, Name, Power);
    }
}

