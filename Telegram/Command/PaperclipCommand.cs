using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telegram.View;
using Telegram.View.UserControls;
using Telegram.ViewModel;

namespace Telegram.Command
{
   public class PaperclipCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MessageView MessageView;
        MessageViewModel MessageViewModel;
        public PaperclipCommand(MessageView messageView,MessageViewModel messageViewModel)
        {
            MessageViewModel = messageViewModel;
            MessageView = messageView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

                public byte[] ImageToByteArray(System.Drawing.Image imageIn)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageIn.Save(ms, imageIn.RawFormat);
                        return ms.ToArray();
                    }
                }
        public void Execute(object parameter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if(ofd.FileName!=null)
            {
                string filename = Path.GetFileName(ofd.FileName);
                MessageViewModel.IMagePAth = ofd.FileName;
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ofd.FileName);
                System.Drawing.Image image1 = bmp;
               byte[] imagebytes=ImageToByteArray(image1);

                string fileformat = Path.GetExtension(ofd.FileName);
                MessageViewModel.Currentdata = imagebytes;
                //switch(fileformat)
                //{
                //    case  ".pdf":
                //        ofd.FileName = "C:\\Users\\User\\source\\repos\\Telegram2\\Telegram\\Image\\Pdf.png";
                //        break;
                //    case ".docx":
                //        ofd.FileName = "C:\\Users\\User\\source\\repos\\Telegram2\\Telegram\\Image\\Word.png";
                //        break;
                //}
                // Image SendImage = new Image();
        

                //BitmapImage bi = new BitmapImage(new Uri(ofd.FileName));
                //SendImage.Source = bi;
                //ImageBrush imageBrush = new ImageBrush(bi);
                //imageBrush.Stretch = Stretch.Fill;
                //MessageView.MessageLIstBox.Items.Add(SendImage);




                //    if(fileformat==".pdf" || fileformat == ".docx")
                //    {
                //    ListBoxItem listBoxItem = new ListBoxItem();
                //    listBoxItem.Content = filename;
                //    listBoxItem.HorizontalContentAlignment = HorizontalAlignment.Right;
                //    listBoxItem.Height = 20;
                //    listBoxItem.Width = 100;
                //    listBoxItem.HorizontalAlignment = HorizontalAlignment.Right;
                //    MessageView.MessageLIstBox.Items.Add(listBoxItem);
                //    }


            }
        }
    }
}
