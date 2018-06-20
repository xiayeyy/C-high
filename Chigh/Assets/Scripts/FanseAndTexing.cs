#define  test3  //定义一个宏

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Linq ;
using System.Text ;
using UnityEngine.UI;

[My ("我的特性",Id  =100)]   //自动省略Arrtibute
public class FanseAndTexing : MonoBehaviour {


    public Text t1;
    // Use this for initialization
    void Start ()
	{
	    Test1();Test2("222222222");
             Test3();Test4();
        t1.text = "11111111111111111";




    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("stringempty")]
    void StrEmpty()
    {
        t1.text = string.Empty;
    }

   // [Obsolete("这个方法过时了，用Test2代替",true)]//提示过时；true时报错
    [Obsolete("这个方法过时了，用Test2代替")]   
    void Test1()
    {
        print("1111111111");
    }


   [DebuggerStepThrough ] //调试时跳过
  static   void Test2(string str)
    {
        print(str);    
    }


    

    [Conditional("test3")]     //当宏定义存在时，表示可以被引用
    void Test3()
    {
        print("33333333333");
    }

    
    void Test4()
    {
       print("44444444");
    }



}
