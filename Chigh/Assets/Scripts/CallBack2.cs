using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class CallBack2 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Debug.Log("程序开始运行：");
        Thread.CurrentThread.Name = "Main Thread";
        Calculator cal = new Calculator();
        int result = cal.Add(6, 8);
        Debug.Log(string.Format("结果为: {0}\n", result));
        // 做某些其它的事情，模拟需要执行3 秒钟
        for (int i = 1; i <= 3; i++)
        {
            Thread.Sleep(TimeSpan.FromSeconds(i));
            Debug.Log(string.Format("线程：{0}:  执行了 {1} s 时间(s).", Thread.CurrentThread.Name, i));
        }
        Debug.Log("其它的事情完成");
    }
    public class Calculator
    {
        public int Add(int x, int y)
        {
            if (Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = "Pool Thread";
            }
            Debug.Log(string.Format("开始计算{0}+{1}=?", x, y));
            // 执行某些事情，模拟需要执行2 秒钟
            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Debug.Log(string.Format("线程：{0}: 添加 执行了{1}s 时间(s).", Thread.CurrentThread.Name, i));
            }
            Debug.Log("计算成功!");
            return x + y;
        }
    }
}
