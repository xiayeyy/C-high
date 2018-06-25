using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ThreadTest 
{
   public  Func<int, string, string> a;   //fun 是返回值类型的委托
    public IAsyncResult ar;
    public  bool isWait;
    // Use this for initialization
     public  string   ThreadStart()
     {
      
         ar = a.BeginInvoke(100, "YOY", null, null);
        isWait = true;
        //while (ar.IsCompleted == false)
        //{
        //    tx1.text += " .";
        //    Thread.Sleep(10);
        //}
        //tx1.text += a.EndInvoke(ar);

        //等待句柄

        // bool isEnd = ar.AsyncWaitHandle.WaitOne(1000);  //表示超时时间  1000 时间内结束返回true
        string end = a.EndInvoke(ar);
        return end;
    }

    // Update is called once per frame
    public void ThreadUpdate()
    {
        if (isWait)
        {
            //tx1.text += " .";
        }
    }

   public  string MyThread(int i, string str)
    {
       
        Thread.Sleep(999);
        string  ret = "\n" + i + str;
        isWait = false;
        return ret;
        
    }
}
