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

namespace EwidencjaUrlopow.View
{
    /// <summary>
    /// Logika interakcji dla klasy KalendarzV.xaml
    /// </summary>
    public partial class KalendarzV : UserControl
    {
        public KalendarzV()
        {
            InitializeComponent();
            ViewModel.KalendarzVM kalendarzVM = new ViewModel.KalendarzVM();
            this.DataContext = kalendarzVM;
        }
    }
}
