using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telegram.View;
using Telegram.ViewModel;

namespace Telegram.Command
{
   public class SmileCommand : ICommand
    {
        int state = 1;
        SmileView SmileView = new SmileView();
        public event EventHandler CanExecuteChanged;
        MessageView MessageView;
        public SmileCommand(MessageViewModel messageViewModel,MessageView messageView)
        {
            MessageView = messageView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Grid border = new Grid();
            if(state==1)
            {

            border.Width = 100;
            border.Height = 400;
            border.Name = "Kele";
                border.Children.Add( SmileView);
            MessageView.MessageGrid.Children.Add(border);
                state = 0;
            }
            else
            {
                state = 1;
                border.Children.Clear();
                MessageView.MessageGrid.Children.RemoveAt(1);
                
            }
        }
    }
}
