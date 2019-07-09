using System;
using System.Net;
using System.Windows;
using System.Windows.Input;
using Telegram.ViewModel;

namespace Telegram.Command
{
    public class Smile1Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MessageViewModel MessageViewModel;
      public Smile1Command(MessageViewModel messageViewModel)
        {
            MessageViewModel = messageViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {


          
              MessageBox.Show( WebUtility.UrlDecode("%F0%9F%98%B1"));


        }  
}
}
