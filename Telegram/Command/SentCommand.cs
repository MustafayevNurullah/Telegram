using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telegram.Entity;
using Telegram.View;
using Telegram.ViewModel;

namespace Telegram.Command
{
    public class SentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MessageViewModel MessageViewModel;
        MessageView MessageView;
     //   Network Network;
            static int TcpPort = 1032;
            static string IP = "10.1.16.27";
            TcpClient client = new TcpClient();
        NetworkStream NetworkStream;
        public SentCommand(MessageViewModel messageViewModel,MessageView messageView)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IP), TcpPort);
            client.Connect(endPoint);
            NetworkStream stream = client.GetStream();
            NetworkStream = stream;
           // Network network = new Network();
          //  Network = network;
            MessageView = messageView;
            MessageViewModel = messageViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if(MessageViewModel.CurrentText!=null)
            {
                ClientEntity clientEntity = new ClientEntity();
                clientEntity.SentMessage = MessageViewModel.CurrentText;
                MessageViewModel.MessageList.Add(clientEntity);
                MessageViewModel.CurrentText += $"`{IP}";
                byte[] data = Encoding.ASCII.GetBytes(MessageViewModel.CurrentText);
                NetworkStream.Write(data, 0, data.Length);
                
                data = new byte[256];
                string responseData = string.Empty;
                int bytes = NetworkStream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                ClientEntity clientEntity1 = new ClientEntity();
                clientEntity1.SenderMessage = responseData;
                MessageViewModel.MessageList.Add(clientEntity1);

                MessageViewModel.CurrentText = null;

            }
        }
    }
}
