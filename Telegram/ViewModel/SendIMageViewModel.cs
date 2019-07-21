﻿using System;
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

        private string SendImage_;

        public string SendImage
        {
            get { return StaticImage.image; }
            set { SendImage_ = value; OnPropertyChange(new PropertyChangedEventArgs(nameof(SendImage))); }
        }

        private int state;

        public int State
        {
            get { return StaticImage.State; }
            set { state = value; OnPropertyChange(new PropertyChangedEventArgs(nameof(State))); }
        }


    }
}
