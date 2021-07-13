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
    /// Logika interakcji dla klasy EdytujPracownika.xaml
    /// </summary>
    public partial class EdytujPracownika : MetroWindow
    {
        public EdytujPracownika(Pracownik toEdit)
        {
            InitializeComponent();
            ViewModel.EdytujPracownikaVM edytujPracownikaVM = new ViewModel.EdytujPracownikaVM(this, toEdit);
            this.DataContext = edytujPracownikaVM;
        }


    }
}
