using EwidencjaUrlopow.ViewModel;
using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy DodajPracownika.xaml
    /// </summary>
    public partial class DodajPracownika : MetroWindow
    {
        

        public DodajPracownika()
        {
            InitializeComponent();

            ViewModel.DodajPracownikaVM dodajPracownikaVM = new ViewModel.DodajPracownikaVM(this);
            this.DataContext = dodajPracownikaVM;
        }
    }

}
