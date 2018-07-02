using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [AttributeUsage(AttributeTargets.Class)] //表示特性类用到的特性结构有哪些
    sealed class MyAttribute : System.Attribute
    {

        //一般特性类以Arritbute结尾，需要继承自 System .Attribute，一般情况下声明为 sealed,表示目标结构的一些状态
        //定义一些字段或属性，一般不定义方法

        public int Id { get; set; }
        public string Name { get; set; }
        public string Vestion { get; set; }

        public MyAttribute(string str)
        {
            Name = str;
            Vestion = str;
        }
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class InvokeOnKeyPressAttribute : Attribute
    {
        public KeyCode KeyCode { get; set; }
    }

