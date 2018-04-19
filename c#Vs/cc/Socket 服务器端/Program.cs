using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_服务器端
{
    class Program
    {

        static List<Client> clientlist = new List<Client>();
        static void Main(string[] args)
        {
            //1 创建Socket
            Socket tcpserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2 绑定Ip和端口号  192.168.1.102
            IPAddress iPAddress = new IPAddress(new byte[] { 192, 168, 1, 102 });
            EndPoint point = new IPEndPoint(iPAddress, 8888);  //IPEndPoint 对 ip +端口做封装的类,端口号尽量设大
            tcpserver.Bind(point);  //向操作系统申请一个端口和 ip号 用来做通信
            //3 开始监听 等待客户端做链接
            tcpserver.Listen(100);  //最大连接数
            Console.WriteLine("sever runniing ····");

            while (true)
            {
                // tcpserver.Accept();  //暂停线程，直到有一个客户端连接，之后执行下面
                Socket clien = tcpserver.Accept();  //使用返回的socet 和客户端做通信
                Console.WriteLine("一个客户端连接");
                //string message = "Hellow!";
                // byte[] data = Encoding.UTF8.GetBytes(message);  //对字符串做编码，得到一个字符串的字节数组
                //clien.Send(data);

                Client client =new Client (clien);//把每个客户端收发消息逻辑放到client类处理
                clientlist.Add(client);
            }
        }
    }
}
