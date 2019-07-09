using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Command;
using Telegram.View;

namespace Telegram.ViewModel
{
    public class MessageViewModel : BaseViewModel
    {
      public  PaperclipCommand PaperclipCmd { get; set; }
        public SmileCommand SmileCmd { get; set; }
        public VoiceCommand VoiceCmd { get; set;  }
        public MessageViewModel( MessageView messageView)
        {
            PaperclipCmd = new PaperclipCommand();
            SmileCmd = new SmileCommand(this,messageView);
            VoiceCmd = new VoiceCommand();

        }


        string currenttext;
        public string CurrentText
        {
            get
            {
                return currenttext;
            }
            set
            {
                currenttext = value;
                OnPropertyChange(new PropertyChangedEventArgs(nameof(CurrentText)));
            }
         }



    }
}
