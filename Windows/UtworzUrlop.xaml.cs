using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace EwidencjaUrlopow.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy UtworzUrlop.xaml
    /// </summary>
    public partial class UtworzUrlop : MetroWindow
    {
        public UtworzUrlop()
        {
            InitializeComponent();

            ViewModel.UtworzUrlopVM utworzUrlopVM = new ViewModel.UtworzUrlopVM(this);
            this.DataContext = utworzUrlopVM;
        }
    }
}
