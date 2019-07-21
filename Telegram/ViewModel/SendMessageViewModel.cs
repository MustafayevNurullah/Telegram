using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.ViewModel
{
   public class SendMessageViewModel:BaseViewModel
    {
     public SendMessageViewModel()
        {

        }

     
        private string  message;
        public string Message
        {
            get
            {
                return StaticImage.Message;
            }
            set { message = value; OnPropertyChange(new PropertyChangedEventArgs(nameof(Message))); }

        }
        private int state;

        public int State
        {
            get { return StaticImage.State; }
            set { state = value; OnPropertyChange(new PropertyChangedEventArgs(nameof(State))); }
        }

    }
}
