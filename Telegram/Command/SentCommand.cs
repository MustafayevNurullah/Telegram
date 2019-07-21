using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using Telegram.View.UserControls;
using Telegram.ViewModel;

namespace Telegram.Command
{
    public class SentCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        MessageViewModel MessageViewModel;
        MessageView MessageView;
            static int TcpPort = 1032;
            static string IP = "192.168.1.9";
            TcpClient client = new TcpClient();
        NetworkStream NetworkStream;
        public SentCommand(MessageViewModel messageViewModel,MessageView messageView)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IP), TcpPort);
            client.Connect(endPoint);
            NetworkStream stream = client.GetStream();
            NetworkStream = stream;
            MessageView = messageView;
            messageViewModel.MessageList = new ObservableCollection<ClientEntity>();
            MessageViewModel = messageViewModel;
            Task.Run(()=>Recive());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public string GetImagePath(byte[] buffer, int counter)
        {
            ImageConverter ic = new ImageConverter();
          System.Drawing.Image img = ( System.Drawing.Image)ic.ConvertFrom(buffer);
            Bitmap bitmap1 = new Bitmap(img);
            bitmap1.Save($@"C:\Users\User\Desktop\image{counter}.png");
            var imagepath = $@"C:\Users\User\Desktop\image{counter}.png";
            return imagepath;
        }
        void Recive()
        {
            while(true)
            {
                byte[] bytes = new byte[1100000];
                string dataa ;
                int i;
                 string responseData ;
                if ((i = NetworkStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                    dataa = Encoding.ASCII.GetString(bytes, 0, i);
                    if (dataa.Contains("PNG"))
                    {
                    StaticImage.State = 2;

                        StaticImage.image = GetImagePath(bytes, bytes.Count()); 
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            MessageView.MessageLIstBox.Items.Add(new SendImageUC());

                        }));
                        break;
                    }
                    else
                    {
                        StaticImage.State = 2;

                        ClientEntity clientEntity = new ClientEntity();
                    clientEntity.SenderMessage = dataa;
                        // var action = new Action(() => { MessageViewModel.MessageList.Add(clientEntity); });
                        // Task.Run(() => App.Current.Dispatcher.BeginInvoke(action));
                        StaticImage.Message = dataa;
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            MessageView.MessageLIstBox.Items.Add(new SendMessageUC());

                        }));
                    }
                }
            }
        }
        byte[] data;
        public void Execute(object parameter)
        {
            Task.Run(() => {

                    StaticImage.State = 1;
                if (MessageViewModel.CurrentText != null)
                {
                    ClientEntity clientEntity = new ClientEntity();
                    clientEntity.SentMessage = MessageViewModel.CurrentText;

                    // var action = new Action(() => { MessageViewModel.MessageList.Add(clientEntity); });
                    //Task.Run(() => App.Current.Dispatcher.BeginInvoke(action)).Wait();
                    data = Encoding.ASCII.GetBytes(MessageViewModel.CurrentText);
                    StaticImage.Message = MessageViewModel.CurrentText;

                    App.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageView.MessageLIstBox.Items.Add(new SendMessageUC());

                    }));
                    NetworkStream.Write(data, 0, data.Length);
                    MessageViewModel.CurrentText = null;
                }
                if (MessageViewModel.Currentdata != null)
                {
                    ClientEntity clientEntity = new ClientEntity();
                    clientEntity.SentImage = MessageViewModel.IMagePAth;
                    StaticImage.image = MessageViewModel.IMagePAth;
                    App.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageView.MessageLIstBox.Items.Add(new SendImageUC());

                    }));

                    //var action = new Action(() => { MessageViewModel.MessageList.Add(clientEntity); });
                    //Task.Run(() => App.Current.Dispatcher.BeginInvoke(action)).Wait();
                    NetworkStream.Write(MessageViewModel.Currentdata, 0, MessageViewModel.Currentdata.Length);
                    MessageViewModel.Currentdata = null;
                }
            });
        }
    }
}
