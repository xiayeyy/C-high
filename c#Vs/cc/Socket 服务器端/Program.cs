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
        static void Main(string[] args)
        {
            //1 创建Socket
            Socket tcpserver = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp );
            //2 绑定Ip和端口号  192.168.1.102
            IPAddress iPAddress = new IPAddress(new byte[] { });
            EndPoint point = new IPEndPoint(iPAddress,8888);  //IPEndPoint 对 ip +端口做封装的类,端口号尽量设大

            tcpserver.Bind(point);  //向操作系统申请一个端口和 ip号 用来做通信
        }
    }
}
