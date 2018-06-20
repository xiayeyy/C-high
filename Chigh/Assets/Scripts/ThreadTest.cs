using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreadTest : MonoBehaviour {

    public Text tx1;
	// Use this for initialization
	void Start () {
        Action  at1= MyThread;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MyThread()
    {
        
    }
}
