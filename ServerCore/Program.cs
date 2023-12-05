using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // DNS (Domain Name System)
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            // Socket
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // 연결
                listenSocket.Bind(endPoint);

                // Backlog : 최대 대ㅣㄱ수
                listenSocket.Listen(10);

                while (true)
                {
                    Console.WriteLine("Listening...");

                    Socket clientSocket = listenSocket.Accept();

                    // 받는다
                    byte[] recvBuff = new byte[1024];
                    int recvBytes = clientSocket.Receive(recvBuff);
                    string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                    Console.WriteLine($"[From Client] {recvData}");

                    // 보낸다
                    byte[] sendBuff = Encoding.UTF8.GetBytes("Welcome to MMORPG Server !");
                    clientSocket.Send(sendBuff);

                    // 연락 끊음
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
