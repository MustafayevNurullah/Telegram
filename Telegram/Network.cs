using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Telegram
{
   public class Network
    {
        public  string IP;
        public Network()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = ip.ToString();
                }
            }
        }
       public  void StartTcpClient(string Message)
        {
           try
            {
               
        //static int TcpPort = 1032;
        //        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IP), TcpPort);
        //        TcpClient client = new TcpClient();
        //        client.Connect(endPoint);
        //            NetworkStream stream = client.GetStream();
        //            //byte[] data = Encoding.ASCII.GetBytes(Message);
        //            //stream.Write(data, 0, data.Length);
        //            data = new byte[256];
        //            string responseData = string.Empty;
        //              int bytes = stream.Read(data, 0, data.Length);
        //             responseData = Encoding.ASCII.GetString(data, 0, bytes);
                //client.Close();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException: {0}", e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show( "SocketException: {0}", e.Message);
            }
        }

    }
}
