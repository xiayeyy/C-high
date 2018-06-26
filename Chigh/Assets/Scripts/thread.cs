using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
//using System.Threading.Tasks;


public class thread : MonoBehaviour
{
    private bool isEnd = false;
    public Text tx1;

    public Thread th;
    // Use this for initialization
 
    void Start()
    {
        while (true)
        {
            th = new Thread(MyTest);
        }

       // th =new Thread (MyTest);

        //th.IsBackground=true ;   //设置为后台线程
        //th.Priority = System.Threading.ThreadPriority.Lowest;   //线程优先级

        // th.Start();
        // th.Join();         //暂停当前线程，等t线程执行完后继续

        //线程池
        //ThreadPool.QueueUserWorkItem(Mythread);   
        //ThreadPool.QueueUserWorkItem(Mythread);
        //ThreadPool.QueueUserWorkItem(Mythread);
        //ThreadPool.QueueUserWorkItem(Mythread);
        //ThreadPool.QueueUserWorkItem(Mythread);

       

    }

    void MyTest()
    {
        
         //Thread.Sleep(2999);
        if (isEnd == true)
        {
             Debug.Log("\n" + "加载完成！！！" + Thread.CurrentThread.ManagedThreadId);
        }

        //ReBool(isEnd);
        isEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
             th.Abort(); 
        }
    }

    void CreadThread()
    {
        tx1.text += "\n" + "加载完成！！！";
    }

    public bool ReBool()
    {
        return isEnd;
    }

    void Mythread(object sete)
    {
        Debug.Log("开启=========="+Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(899);
    }
}
