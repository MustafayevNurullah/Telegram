using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.ViewModel;

namespace Telegram.View
{
    /// <summary>
    /// Interaction logic for SmileView.xaml
    /// </summary>
    public partial class SmileView : UserControl
    {
        public SmileView(MessageViewModel messageViewModel )
        {
            InitializeComponent();
            DataContext = messageViewModel;
        }
    }
}
