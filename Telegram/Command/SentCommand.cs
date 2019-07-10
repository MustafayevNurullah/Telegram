using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telegram.View;
using Telegram.ViewModel;

namespace Telegram.Command
{
    public class SentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MessageViewModel MessageViewModel;
        MessageView MessageView;
        public SentCommand(MessageViewModel messageViewModel,MessageView messageView)
        {
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

            ListBoxItem a = new ListBoxItem();
                // a.Content = MessageViewModel.CurrentText;
                //   <ImageBrush ImageSource="/Image/Paperclip.png" Stretch = "Fill" />
                a.Content = MessageViewModel.CurrentText;
            a.HorizontalContentAlignment = HorizontalAlignment.Right;
            a.Height = 40;
            a.HorizontalAlignment = HorizontalAlignment.Right;
            a.Width = MessageViewModel.CurrentText.Count()*6;
            a.Background = System.Windows.Media.Brushes.GreenYellow;
            MessageView.MessageLIstBox.Items.Add(a);
            MessageViewModel.CurrentText = null;
            }
        }
    }
}
