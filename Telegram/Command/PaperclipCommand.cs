﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Telegram.Command
{
   public class PaperclipCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public PaperclipCommand()
        {

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
