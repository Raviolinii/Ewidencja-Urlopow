using EwidencjaUrlopow.Model;
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
    /// Logika interakcji dla klasy EdytujUrlop.xaml
    /// </summary>
    public partial class EdytujUrlop : MetroWindow
    {
        public EdytujUrlop(Urlop toEdit)
        {
            InitializeComponent();
            ViewModel.EdytujUrlopVM edytujUrlopVM = new ViewModel.EdytujUrlopVM(this, toEdit);
            this.DataContext = edytujUrlopVM;
        }
    }
}
