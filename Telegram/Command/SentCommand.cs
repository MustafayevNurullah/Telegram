using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            messageViewModel.MessageList = new ObservableCollection<ClientEntity>();
            MessageViewModel = messageViewModel;
           Task.Run(()=>Recive());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
       void Recive()
        {
            while(true)
            {
                byte[] bytes = new byte[256];
                string dataa ;
                int i;
                    string responseData ;
                if ((i = NetworkStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                    dataa = Encoding.ASCII.GetString(bytes, 0, i);
                    ClientEntity clientEntity = new ClientEntity();
                    clientEntity.SenderMessage = dataa;
                    var action = new Action(() => { MessageViewModel.MessageList.Add(clientEntity); });
                    Task.Run(() => App.Current.Dispatcher.BeginInvoke(action));
                }
            }
        }
        byte[] data;
        public void Execute(object parameter)
        {
            Task.Run(() => {

                if (MessageViewModel.CurrentText != null)
                {
                    ClientEntity clientEntity = new ClientEntity();
                    clientEntity.SentMessage = MessageViewModel.CurrentText;
                   
                    var action = new Action(() => { MessageViewModel.MessageList.Add(clientEntity); });
                    MessageViewModel.CurrentText += $"{IP}";
                    Task.Run(() => App.Current.Dispatcher.BeginInvoke(action)).Wait();
                     data = Encoding.ASCII.GetBytes(MessageViewModel.CurrentText);
                    NetworkStream.Write(data, 0, data.Length);
                    MessageViewModel.CurrentText = null;
                }
            });

        }
    }
}
