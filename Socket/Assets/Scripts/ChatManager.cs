using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using System.Net;
using System.Text;
using UnityEngine.UI;
using System.Threading;

public class ChatManager : MonoBehaviour
{

    public string ip = "192.168.1.102";  //ip地址
    public int port = 8888;  //端口号
    public InputField t1;
    public Text t2;
    private Socket cliet;
   Thread t;
    byte[] data = new byte[1024];
    private string message="";

    void Start()
    {
        Connet();
    }

    // Update is called once per frame
    void Update()
    {
        if (message != null && message != "")
        {
            t2.text += "\n" + message;
            message = "";//清空消息
        }
    }

    void Connet()
    {
        cliet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //与服务器端连接建立
        cliet.Connect(new IPEndPoint(IPAddress.Parse(ip), port));

      //  t = new Thread(ReceiveMessage);
     //   t.Start();
       StartCoroutine(ReceiveMessage());
    }

    IEnumerator ReceiveMessage()
    {
        yield return new  WaitForSeconds (0.1f);
        while (true)
        {
            if (cliet.Connected == false)
                break;

            int length = cliet.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
           // t2.text += "\n" + message;
        }
    }
    void ReceiveMessage1()
    {
        while (true)
        {
            if (cliet.Connected == false)
             break;

                int length = cliet.Receive(data);
             message = Encoding.UTF8.GetString (data,0,length );
           // t2.text += "\n" + message;
        }
    }


    void SendMessage(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        cliet.Send(data);
    }

    public void ButtonSend()
    {
        SendMessage(t1.text);
        t1.text = "";
    }

    void OnDestroy()
    {
        cliet.Shutdown(SocketShutdown.Both);
        cliet.Close();  //关闭连接
    }
}
