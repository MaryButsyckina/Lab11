using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.Net;

namespace Lab11
{
    internal class TCPclient
    {
        public Socket tcpClient;
        public int client_id;
        public string server_ip;
        public int port;

        public TCPclient()
        {
            client_id = 0;
            server_ip = "192.168.0.184";
            port = 8888;
        }

        public bool Connect() 
        {
            try
            {
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                tcpClient.Connect(server_ip, port);
                tcpClient.ReceiveTimeout = 500;
                return true;
            }
            catch { return false; }
        }
        public bool Send(string msg) 
        {
            try
            {
                tcpClient.Send(Encoding.Default.GetBytes(msg));
                return true;
            }
            catch { return false; }
        }
        public string Receive(int bytes) 
        {
            byte[] buffer = new byte[bytes];
            int count;
            try
            {
                count = tcpClient.Receive(buffer);
            }
            catch { return String.Empty; }
            return Encoding.Default.GetString(buffer, 0, count);
        }
        public void Disconnect() 
        {
            tcpClient.Close();
        }
    }
}
