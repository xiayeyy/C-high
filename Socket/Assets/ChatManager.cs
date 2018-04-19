using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using System.Net;
using System.Text;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public string ip = "192.168.1.102";  //ip地址
    public int port = 8888;  //端口号
    public InputField t1;
    private Socket cliet;
    void Start()
    {
        Connet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Connet()
    {
        cliet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //与服务器端连接建立
        cliet.Connect(new IPEndPoint(IPAddress.Parse(ip), port));

    }

    void SendMessage(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        cliet.Send(data);
    }

    public void ButtonSend()
    {
        SendMessage(t1.text);
    }

     void OnDestroy()
    {
        cliet.Shutdown(SocketShutdown.Both );
        cliet.Close();  //关闭连接
    }
}
