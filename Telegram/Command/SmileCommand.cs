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
        public SmileView SmileView { get; set; }
        public event EventHandler CanExecuteChanged;
        MessageView MessageView;
        MessageViewModel MessageViewModel;
        public SmileCommand(MessageViewModel messageViewModel,MessageView messageView)
        {
           MessageViewModel = messageViewModel;
            MessageView = messageView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SmileView = new SmileView(MessageViewModel);
            Grid border = new Grid();
            if(state==1)
            {

            border.Width = 250;
            border.Height = 50;
            border.Name = "Kele";
                border.VerticalAlignment = VerticalAlignment.Bottom;
                border.Margin = new Thickness(0, 0, 0, 50);
                border.Children.Add(SmileView);
                
            MessageView.MessageGrid.Children.Add(border);
                state = 0;
            }
            else
            {
                state = 1;
                border.Children.Clear();
                MessageView.MessageGrid.Children.RemoveAt(0);
                
            }
        }
    }
}
