using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket_服务器端
{
    class Client
    {
        private Thread t;
        private Socket c1;
        private byte[] data = new byte[1024]; //数据容器
        public Client(Socket s)
        {
            c1 = s;
            //使用线程处理客户端数据接收
             t = new Thread(ReceiveMessage);
            t.Start();

        }

        private void ReceiveMessage()
        {
            while (true)
            {
                if (c1.Poll(10, SelectMode.SelectRead)) //判断socket 是否断开，断开跳出线程
                {    
                    break;
                }
                int lengh= c1.Receive(data );
                string message = Encoding.UTF8.GetString(data, 0, lengh);//接受到数据的时候，把数据分发到客户端
                Console.WriteLine("收到了消息:" + message);
            }
        }
    }
}
