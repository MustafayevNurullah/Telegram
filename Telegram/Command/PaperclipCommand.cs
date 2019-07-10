using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telegram.View;

namespace Telegram.Command
{
   public class PaperclipCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MessageView MessageView;
        public PaperclipCommand(MessageView messageView)
        {
            MessageView = messageView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if(ofd.FileName!=null)
            {
                string filename = Path.GetFileName(ofd.FileName);
                string fileformat = Path.GetExtension(ofd.FileName);
                switch(fileformat)
                {
                    case  ".pdf":
                        ofd.FileName = "C:\\Users\\User\\source\\repos\\Telegram2\\Telegram\\Image\\Pdf.png";
                        break;
                    case ".docx":
                        ofd.FileName = "C:\\Users\\User\\source\\repos\\Telegram2\\Telegram\\Image\\Word.png";
                        break;
                }
             ListBoxItem a = new ListBoxItem();
            Image image = new Image();
            BitmapImage bi = new BitmapImage(new Uri(ofd.FileName));
            image.Source = bi;
            ImageBrush imageBrush = new ImageBrush(bi);
                imageBrush.Stretch = Stretch.Fill;
            a.Background = imageBrush;
            a.HorizontalContentAlignment = HorizontalAlignment.Right;
            a.Height = 100;
                a.Width = 100;
            a.HorizontalAlignment = HorizontalAlignment.Right;
            MessageView.MessageLIstBox.Items.Add(a);
                if(fileformat==".pdf" || fileformat == ".docx")
                {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filename;
                listBoxItem.HorizontalContentAlignment = HorizontalAlignment.Right;
                listBoxItem.Height = 20;
                listBoxItem.Width = 100;
                listBoxItem.HorizontalAlignment = HorizontalAlignment.Right;
                MessageView.MessageLIstBox.Items.Add(listBoxItem);
                }


            }
        }
    }
}
