using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Command;
using Telegram.Command.Smile;
using Telegram.View;

namespace Telegram.ViewModel
{
    public class MessageViewModel : BaseViewModel
    {
      public  PaperclipCommand PaperclipCmd { get; set; }
        public SmileCommand SmileCmd { get; set; }
        public VoiceCommand VoiceCmd { get; set;  }
        public Smile1Command Smile1Cmd { get; set; }
        public Smile2Command Smile2Cmd { get; set; }
        public Smile3Command Smile3Cmd { get; set; }
        public Smile4Command Smile4Cmd { get; set; }
        public Smile5Command Smile5Cmd { get; set; }
        public MessageView MessageView;
        public MessageViewModel( MessageView messageView)
        {
            MessageView = messageView;
            PaperclipCmd = new PaperclipCommand();
            SmileCmd = new SmileCommand(this,messageView);
            VoiceCmd = new VoiceCommand();
            Smile1Cmd = new Smile1Command(this);
            Smile2Cmd = new Smile2Command();
            Smile3Cmd = new Smile3Command();
            Smile4Cmd = new Smile4Command();
            Smile5Cmd = new Smile5Command();
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
