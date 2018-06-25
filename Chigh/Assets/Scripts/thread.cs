using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class thread : MonoBehaviour
{
    private bool isEnd=false;
    public Text tx1;
    // Use this for initialization
    private void Awake()
    {
       

    }
    void Start ()
	{
 Thread th = new Thread(() =>
        {
            Thread.Sleep(1999);
            isEnd = true;
            //ReBool(isEnd);
            Debug.Log("\n" + "加载完成！！！");
        });
        th.Start();
	    th.IsBackground=true ;   //设置为后台线程
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void CreadThread()
    {
        tx1.text += "\n" + "加载完成！！！";
    }

    public bool ReBool()
    {
        return isEnd;
    }
}
