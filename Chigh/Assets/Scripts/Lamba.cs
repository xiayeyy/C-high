using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lamba : MonoBehaviour
{

    delegate bool MyBol(int x, int y);
    delegate bool MyBol_2(int x, string y);
    delegate int calculator(int x, int y); //委托类型
    delegate void VS();
    void Start()
    {
        MyBol Bol = (x, y) => x == y;
        MyBol_2 Bol_2 = (x, s) => s.Length > x;
        calculator C = (X, Y) => X * Y;
        VS S = () => Debug.Log("我是无参数Labada表达式");
        //
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        int oddNumbers = numbers.Count(n => n % 2 == 1);
        //
        List<People> people = LoadData();//初始化
        IEnumerable<People> results = people.Where(delegate (People p) { return p.age > 20; });


    }

    private static List<People> LoadData()
    {
        List<People> people = new List<People>();   //创建泛型对象  
        People p1 = new People(21, "guojing");       //创建一个对象  
        People p2 = new People(21, "wujunmin");     //创建一个对象  
        People p3 = new People(20, "muqing");       //创建一个对象  
        People p4 = new People(23, "lupan");        //创建一个对象  
        people.Add(p1);                     //添加一个对象  
        people.Add(p2);                     //添加一个对象  
        people.Add(p3);                     //添加一个对象  
        people.Add(p4);
        return people;
    }

}

public class People
{
    public int age { get; set; }                //设置属性  
    public string name { get; set; }            //设置属性  
    public People(int age, string name)      //设置属性(构造函数构造)  
    {
        this.age = age;                 //初始化属性值age  
        this.name = name;               //初始化属性值name  
    }


}
