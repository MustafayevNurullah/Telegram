using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.ViewModel
{
   public class SendIMageViewModel:BaseViewModel
    {
       public SendIMageViewModel()
        {

        }

        private Image SendImage_;

        public Image SendImage
        {
            get { return SendImage_; }
            set { SendImage_ = value; OnPropertyChange(new PropertyChangedEventArgs(nameof(SendImage))); }
        }


    }
}
