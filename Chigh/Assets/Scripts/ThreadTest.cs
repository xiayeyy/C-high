using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ThreadTest : MonoBehaviour {

    public Text tx1;
	// Use this for initialization
	void Start () {
        Func <int ,string ,string >  a= MyThread;   //fun 是返回值类型的委托
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string  MyThread(int i,string str)
    {
        tx1.text = "\n" + i + str;
        return "MyThread is ok!!!!!!";
    }
}
